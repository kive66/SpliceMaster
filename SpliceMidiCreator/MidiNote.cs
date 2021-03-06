using System;
using System.Collections.Generic;

namespace SpliceMaster {

    /** @class MidiNote
     * A MidiNote contains
     *
     * starttime - The time (measured in pulses) when the note is pressed.
     * channel   - The channel the note is from.  This is used when matching
     *             NoteOff events with the corresponding NoteOn event.
     *             The channels for the NoteOn and NoteOff events must be
     *             the same.
     * notenumber - The note number, from 0 to 127.  Middle C is 60.
     * duration  - The time duration (measured in pulses) after which the
     *             note is released.
     *
     * A MidiNote is created when we encounter a NoteOff event.  The duration
     * is initially unknown (set to 0).  When the corresponding NoteOff event
     * is found, the duration is set by the method NoteOff().
     */
    public class MidiNote : IComparer<MidiNote>, IComparable<MidiNote> {
        private int startoffset;
        private int starttime;   /** The start time, in pulses */
        private int channel;     /** The channel */
        private int notenumber;  /** The note, from 0 to 127. Middle C is 60 */
        private int duration;    /** The duration, in pulses */


        /** Create a new MidiNote.  This is called when a NoteOn event is
         * encountered in the MidiFile.
         */
        public MidiNote(int startoffset, int starttime, int channel, int notenumber, int duration) {
            this.startoffset = startoffset;
            this.starttime = starttime;
            this.channel = channel;
            this.notenumber = notenumber;
            this.duration = duration;
        }


        public int StartTime {
            get { return starttime; }
            set { starttime = value; }
        }

        public int EndTime {
            get { return starttime + duration; }
        }

        public int Channel {
            get { return channel; }
            set { channel = value; }
        }

        public int Number {
            get { return notenumber; }
            set { notenumber = value; }
        }

        public int Duration {
            get { return duration; }
            set { duration = value; }
        }

        public int Startoffset { get => startoffset; set => startoffset = value; }

        /* A NoteOff event occurs for this note at the given time.
         * Calculate the note duration based on the noteoff event.
         */
        public void NoteOff(int endtime) {
            duration = endtime - starttime;
        }

        /** Compare two MidiNotes based on their start times.
         *  If the start times are equal, compare by their numbers.
         */
        public int Compare(MidiNote x, MidiNote y) {
            if (x.StartTime == y.StartTime)
                return x.Number - y.Number;
            else
                return x.StartTime - y.StartTime;
        }

        /** Sort first based on start time(ascend) then based on note number(descend) */
        public int CompareTo(MidiNote m) {
            if (StartTime == m.StartTime)
                return m.Number - Number;
            return StartTime - m.StartTime;
        }

        public MidiNote Clone() {
            return new MidiNote(startoffset, starttime, channel, notenumber, duration);
        }

        public override
        string ToString() {
            string[] scale = { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
            return string.Format("MidiNote channel={0} number={1} {2} start={3} duration={4}",
                                 channel, notenumber, scale[(notenumber + 3) % 12], starttime, duration);

        }

    }


}  /* End namespace MidiSheetMusic */