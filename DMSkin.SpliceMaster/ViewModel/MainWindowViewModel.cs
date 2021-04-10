using DMSkin.CloudMusic.API;
using DMSkin.CloudMusic.Model;
using DMSkin.CloudMusic.View;
using DMSkin.Core.Common;
using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DMSkin.CloudMusic.ViewModel {
    public class MainWindowViewModel : ViewModelBase {
        #region 初始化
        public MainWindowViewModel() {
            //初始化播放器
            PlayManager.player = Player;
            //Player.Position

            //Player.NaturalDuration.TimeSpan.TotalSeconds

            Task.Run(async () => {
                while (true) {
                    //每隔900 毫秒更新 一次 播放数据
                    await Task.Delay(900);
                    if (PlayManager.State == PlayState.Play) {
                        Execute.OnUIThread(() => {
                            //获取当前进度
                            Position = Player.Position;
                            mediaPosition = (double)Position.Ticks / 10000000;
                            OnPropertyChanged("MediaPosition");
                            if (Player.NaturalDuration.HasTimeSpan) {
                                Duration = Player.NaturalDuration.TimeSpan;
                            }
                        });
                    }
                }
            });
        }
        #endregion

        #region 页面切换
        private Page currentPage = PageManager.commonMode;

        /// <summary>
        /// 当前页面
        /// </summary>
        public Page CurrentPage {
            get { return currentPage; }
            set {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public ICommand PageSheetMusic => new DelegateCommand(obj => {
            CurrentPage = new PageSheetMusic();
        });
        private LeftMenu selectMenu;
        /// <summary>
        /// 选中的菜单
        /// </summary>
        public LeftMenu SelectMenu {
            get { return selectMenu; }
            set {
                selectMenu = value;
                switch (selectMenu) {
                    case LeftMenu.Home:
                        CurrentPage = PageManager.commonMode;
                        break;
                    //跳转到本地音乐
                    case LeftMenu.LocalMusic:
                        CurrentPage = PageManager.PageLocalMusic;
                        break;
                    
                }
                OnPropertyChanged("SelectMenu");
            }
        }

        #endregion

        #region 音乐播放器控制
        private MediaPlayer player = new MediaPlayer();
        /// <summary>
        /// 播放器
        /// </summary>
        public MediaPlayer Player {
            get {

                return player;
            }
            set {
                player = value;
                OnPropertyChanged("Player");
            }
        }

        private bool isPlaying = true;
        /// <summary>
        /// 暂停继续
        /// </summary>
        public ICommand Pause {
            get {
                return new DelegateCommand(obj => {
                    if (isPlaying)
                        player.Pause();
                    else
                        player.Play();
                    isPlaying = !isPlaying;
                });
            }
        }

        private double volume=50;
        /// <summary>
        /// 静音
        /// </summary>
        public ICommand Mute {
            get {
                return new DelegateCommand(obj => {
                    if (player.IsMuted)
                        player.IsMuted = false;
                    else
                        player.IsMuted = true;
                });
            }
        }
        public double Volume {
            get { return volume; }
            set {
                volume = value;
                player.Volume = volume/100;
            }
        }


        public ICommand NextMusic {
            get {
                return new DelegateCommand(obj => {
                    if (MusicViewModelBase.MusicList.Count > 0)
                        if (MusicViewModelBase.selectNum == MusicViewModelBase.MusicList.Count - 1) {
                            MusicViewModelBase.selectNum = 0;
                            PlayManager.Play(MusicViewModelBase.MusicList[0]);
                        } else
                            PlayManager.Play(MusicViewModelBase.MusicList[++MusicViewModelBase.selectNum]);

                });
            }
        }

        public ICommand PriorMusic {
            get {
                return new DelegateCommand(obj => {
                    if (MusicViewModelBase.MusicList.Count > 0)
                        if (MusicViewModelBase.selectNum == 0) {
                            MusicViewModelBase.selectNum = MusicViewModelBase.MusicList.Count - 1;
                            PlayManager.Play(MusicViewModelBase.MusicList[MusicViewModelBase.selectNum]);
                        } else
                            PlayManager.Play(MusicViewModelBase.MusicList[--MusicViewModelBase.selectNum]);

                });
            }
        }
        private TimeSpan position;
        private double mediaPosition=0;
        /// <summary>
        /// 播放进度
        /// </summary>
        public TimeSpan Position {
            get { return position; }
            set {
                position = value;
                OnPropertyChanged("Position");
            }
        }
        public double MediaPosition {
            get { return mediaPosition; }
            set {
                mediaPosition = value;
                var pos = player.Position;
                player.Position = new TimeSpan((long)(value * 10000000));
                OnPropertyChanged("MediaPosition");
            }
        }


        private TimeSpan duration;

        /// <summary>
        /// 长度
        /// </summary>
        public TimeSpan Duration {
            get { return duration; }
            set {
                duration = value;
                OnPropertyChanged("Duration");
            }
        }

        #endregion
    }
}
