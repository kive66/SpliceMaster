using DMSkin.CloudMusic.Model;
using DMSkin.Core.Common;
using DMSkin.Core.MVVM;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SpliceMaster;
using DMSkin.CloudMusic.View;
using System;
using System.Text;
using System.Collections;
using System.Windows;
using System.Windows.Forms;

namespace DMSkin.CloudMusic.ViewModel {
    public class PageLocalMusicViewModel : MusicViewModelBase {
        public PageLocalMusicViewModel () {
            // Read();
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public void Read () {
            if (File.Exists("LocalMusic.json")) {
                //尝试从 配置文件中读取 上次 增加的 播放列表
                string json = File.ReadAllText("LocalMusic.json");
                if (!string.IsNullOrEmpty(json)) {
                    List<Music> list = JsonConvert.DeserializeObject<List<Music>>(json);
                    foreach (var item in list) {
                        if (File.Exists(item.Url))
                            MusicList.Add(item);
                    }
                    //显示歌曲列表
                    ShowMusicList();
                }
            }
        }

        /// <summary>
        /// 写入配置
        /// </summary>
        public void Save () {

            string json = JsonConvert.SerializeObject(MusicList);
            File.WriteAllText("LocalMusic.json", json);
        }


        /// <summary>
        /// 新增文件夹
        /// </summary>
        public ICommand AddFileCommand {
            get {
                return new DelegateCommand(obj => {
                    var path = SelectFileWpf();
                    if (path != null) {
                        var file = new FileInfo(path);
                        var midi = new MP3Info();
                        midi.GetMP3Info(file.DirectoryName, file.Name);
                        if (file.Extension.Contains(".mid")) {
                            MusicList.Add(new Music() {
                                Title = file.Name,
                                Size = file.Length,
                                Index = (MusicList.Count + 1).ToString(),
                                Url = file.FullName,
                                Album = midi.Album,
                                Artist = midi.Artist,
                                TimeStr = midi.time
                            });
                        }
                        // 显示歌曲列表
                        ShowMusicList();
                    }
                });
            }
        }

        /** select file */
        public string SelectFileWpf () {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog() {
                Filter = "Midi文件 (.mid)|*.mid"
            };
            var result = openFileDialog.ShowDialog();
            if (result == true) {
                return openFileDialog.FileName;
            }
            else {
                return null;
            }
        }

        private void FindMusic (List<string> filelist) {
            int index = 1;
            List<Music> TempList = new List<Music>();
            foreach (var item in filelist) {
                FileInfo file = new FileInfo(item);

                MP3Info m = new MP3Info();
                m.GetMP3Info(file.DirectoryName, file.Name);

                if (file.Extension.Contains(".mid") || file.Extension.Contains(".mp3")) {
                    TempList.Add(new Music() {
                        Title = file.Name,
                        Size = file.Length,
                        Index = index.ToString(),
                        Url = file.FullName,
                        Album = m.Album,
                        Artist = m.Artist,
                        TimeStr = m.time
                    });
                    index++;
                }
            }
            if (TempList.Count > 0) {
                Execute.OnUIThread(() => {
                    foreach (var item in TempList) {
                        if (MusicList.Where(p => p.Title == item.Title).Count() == 0) {
                            MusicList.Add(item);
                        }
                    }
                    // 显示歌曲列表
                    ShowMusicList();
                    // 保存找到的歌曲
                    Save();
                });
            }
        }
        private static Hashtable trackCuts = new Hashtable();//musicNo,cutPos
        public static Hashtable TrackCuts { get => trackCuts; set => trackCuts = value; }
        public ICommand EditCommand => new DelegateCommand(obj => {
            EditWindow editWindow = new EditWindow();
            editWindow.ShowDialog();
        });

        public ICommand Delete => new DelegateCommand(obj => {
            MusicList.RemoveAt(SelectNum);
        });

        private string outputName = "\\test";
        public string OutputName { get => outputName; set => outputName = value; }
        public ICommand StartCreation {
            get {
                return new DelegateCommand(obj => {
                    // open folder browser
                    System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();

                    // if click ok
                    string outputPath = "";
                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        outputPath = openFileDialog.SelectedPath;

                        // create the list of midifile
                        var mf = new List<MidiFile>();
                        for (int i = 0; i < MusicList.Count; i++)
                            mf.Add(new MidiFile(MusicList[i].Url));

                        // find the cut position of every midifile
                        var sa = new SpliceAlgorithm(mf);

                        // transfer the cut position to midisplice
                        List<TrackCut>[] cutpos;

                        cutpos = new List<TrackCut>[mf.Count];
                        for (int i = 0; i < cutpos.Length; i++) {
                            cutpos[i] = new List<TrackCut>();
                            for (int j = 0; j < mf[i].Tracks.Count; j++) {
                                if (TrackCuts.ContainsKey(i))
                                    cutpos[i].Add(new TrackCut(j, ((TrackCut)TrackCuts[i]).Startbar, ((TrackCut)TrackCuts[i]).Endbar));
                                else
                                    cutpos[i].Add(new TrackCut(j, mf[i].CutPos[0], mf[i].CutPos[1]));
                            }
                        }


                        // cut the midifile according to the cutpos
                        // MidiSplice ms = new MidiSplice(mf, cutpos,sp);
                        // ms.Write("test", ms.Splice());
                        try {
                            NewSplice ms = new NewSplice(mf, cutpos);
                            ms.Splice();
                            ms.WriteToFile(outputPath + outputName);
                            FileInfo file = new FileInfo(outputPath + outputName + ".mid");
                            MP3Info m = new MP3Info();
                            m.GetMP3Info(file.DirectoryName, file.Name);
                            MusicList.Add(new Music() {
                                Title = outputName,
                                Size = file.Length,
                                Url = file.FullName,
                                Album = m.Album,
                                Artist = m.Artist,
                                TimeStr = m.time
                            });
                        }
                        catch (Exception e) {
                            string str = GetExceptionMsg(e, string.Empty);
                            System.Windows.Forms.MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        // remind the user that midi creation is finished
                    }
                });
            }
        }


        static string GetExceptionMsg (Exception ex, string backStr) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            if (ex != null) {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
                sb.AppendLine("【异常方法】：" + ex.TargetSite);
            }
            else {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");

            return sb.ToString();
        }
    }
}
