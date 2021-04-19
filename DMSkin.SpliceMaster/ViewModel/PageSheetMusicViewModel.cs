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
using System.Windows;
using System.Windows.Forms;
using DMSkin.CloudMusic.ViewModel;
using MidiSheetMusic;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace DMSkin.CloudMusic.ViewModel {
    public class PageSheetMusicViewModel : MusicViewModelBase {
        public int page_num;
        public int total_page;
        private BitmapImage page=null;

        public BitmapImage Page {
            get { return page; }
            set { page = value; OnPropertyChanged("Page"); }
        }
        public PageSheetMusicViewModel () {
            page_num = 1;
            total_page = 1;
            showPage();
        }

        public void showPage () {
            if (MusicList.Count() == 0||selectNum<0)
                return;
            string filename = MusicList[selectNum].Url;
            SheetMusic sheet = new SheetMusic(filename, null);

            total_page = sheet.GetTotalPages();
            Bitmap bitmap = new Bitmap(840, 1090);
            Graphics g = Graphics.FromImage(bitmap);
            sheet.DoPrint(g, page_num);
            /*bitmap.Save( "_" + page + ".png",
                        System.Drawing.Imaging.ImageFormat.Png);*/
            Page = BitmapToBitmapImage(bitmap);
            g.Dispose();
            bitmap.Dispose();
        }
        public ICommand NextPage => new DelegateCommand(obj => {
            if (page_num < total_page) {
                page_num++;
                showPage();
            }
        });
        public ICommand PriorPage => new DelegateCommand(obj => {
            if (page_num > 1) {
                page_num--;
                showPage();
            }
        });
        private BitmapImage BitmapToBitmapImage (System.Drawing.Bitmap bitmap) {
            using (System.IO.MemoryStream memory = new System.IO.MemoryStream()) {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }
    }
}
