using DMSkin.Core.MVVM;
using SpliceMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static DMSkin.CloudMusic.ViewModel.PageLocalMusicViewModel;
namespace DMSkin.CloudMusic.ViewModel {
    class EditViewModel : MusicViewModelBase {
        private int startbar;
        private int endbar;
        private int startnote;
        private int endnote;
        public EditViewModel () {
            if (TrackCuts.ContainsKey(SelectNum)) {
                StartBar = ((TrackCut)TrackCuts[SelectNum]).Startbar;
                EndBar = ((TrackCut)TrackCuts[SelectNum]).Endbar;
                StartNote = ((TrackCut)TrackCuts[SelectNum]).Startnote;
                EndNote = ((TrackCut)TrackCuts[SelectNum]).Endnote;
            }

        }

        public ICommand Confirm {
            get {
                return new DelegateCommand(obj => {
                    if (TrackCuts.ContainsKey(SelectNum))
                        TrackCuts[SelectNum] = (new TrackCut(SelectNum, StartBar, EndBar, StartNote, EndNote));
                    else
                        TrackCuts.Add(SelectNum, new TrackCut(SelectNum, StartBar, EndBar, StartNote, EndNote));
                });
            }
        }
        public int StartBar { get => startbar; set { startbar = value; OnPropertyChanged("StartBar"); } }
        public int EndBar { get => endbar; set { endbar = value; OnPropertyChanged("EndBar"); } }
        public int StartNote { get => startnote; set { startnote = value; OnPropertyChanged("StartNote"); } }
        public int EndNote { get => endnote; set { endnote = value; OnPropertyChanged("EndNote"); } }
    }
}
