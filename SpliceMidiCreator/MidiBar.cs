using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpliceMaster {
    public class MidiBar {
        private int startoffset;
        private int endoffset;
        private int starttick;
        private int endtick;
        private int instrument;
        private byte keysignature;
        private List<MidiNote> notes;
        private List<MidiEvent> events;
        private TimeSignature timesig;

        public int Startoffset { get => startoffset; set => startoffset = value; }
        public int Endoffset { get => endoffset; set => endoffset = value; }
        public int Starttick { get => starttick; set => starttick = value; }
        public int Endtick { get => endtick; set => endtick = value; }
        public int Instrument { get => instrument; set => instrument = value; }
        public byte Keysignature { get => keysignature; set => keysignature = value; }
        public List<MidiNote> Notes { get => notes; set => notes = value; }
        public TimeSignature Timesig { get => timesig; set => timesig = value; }
        public List<MidiEvent> Events { get => events; set => events = value; }

        public MidiBar() { notes = new List<MidiNote>();timesig = new TimeSignature();events = new List<MidiEvent>(); }

        public MidiBar(int startoffset, int endoffset, int starttick, int endtick,
            byte keysignature, List<MidiNote> notes,List<MidiEvent> events, TimeSignature timesig){
            this.startoffset = startoffset;
            this.endoffset = endoffset;
            this.starttick = starttick;
            this.endtick = endtick;
            this.keysignature = keysignature;
            this.timesig = timesig;
            this.notes = notes;
            this.events = events;
        }
        
        public override
        string ToString() {
            return string.Format("TimeSignature={0}/{1} quarter={2} tempo={3} instrument={4} tick({5},{6}) offset({7},{8})",
                                 timesig.Numerator, timesig.Denominator, timesig.Quarter, timesig.Tempo,
                                 instrument,starttick,endtick,startoffset,endoffset);
        }
    }
}
