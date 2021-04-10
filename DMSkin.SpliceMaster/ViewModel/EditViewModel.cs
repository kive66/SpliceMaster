using DMSkin.Core.MVVM;
using SpliceMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMSkin.CloudMusic.ViewModel {
    class EditViewModel :MusicViewModelBase{
        private int startbar;
        private int endbar;
        private int startnote;
        private int endnote;
        public EditViewModel() {
        }

        public ICommand Confirm {
            get {
                return new DelegateCommand(obj => {
                    PageLocalMusicViewModel.TrackCuts.Add(new TrackCut(SelectNum,StartBar,EndBar,StartNote,EndNote));
                });
            }
        }
        public int StartBar { get => startbar; set => startbar = value; }
        public int EndBar { get => endbar; set => endbar = value; }
        public int StartNote { get => startnote; set => startnote = value; }
        public int EndNote { get => endnote; set => endnote = value; }
    }
}
