/*
 * Copyright (c) 2007-2012 Madhav Vaidyanathan
 *
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License version 2.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;


namespace SpliceMaster {

    /** @class MidiTrack
     * The MidiTrack takes as input the raw MidiEvents for the track, and gets:
     * - The list of midi notes in the track.
     * - The first instrument used in the track.
     *
     * For each NoteOn event in the midi file, a new MidiNote is created
     * and added to the track, using the AddNote() method.
     *
     * The NoteOff() method is called when a NoteOff event is encountered,
     * in order to update the duration of the MidiNote.
     */
    public class MidiTrack {
        private int tracknum;             /** The track number */
        private List<MidiNote> notes;     /** List of Midi notes */
        private int instrument;           /** Instrument for this track */
        private List<MidiEvent> lyrics;   /** The lyrics in this track */
        private int trackstart;            /** 音轨的起始字节 */
        private int tracklen;               /** 音轨的总字节数 */
        private int trackpulses;            /** 音轨的时长ticks */
        private List<int> cutbarnum;      /** 进行剪切的位置 */
        private List<MidiEvent> events;
        private List<MidiBar> midibar;

        /** Create an empty MidiTrack.  Used by the Clone method */
        public MidiTrack(int tracknum) {
            this.tracknum = tracknum;
            notes = new List<MidiNote>(20);
            instrument = 0;
        }

        /** Create a MidiTrack based on the Midi events.  Extract the NoteOn/NoteOff
         *  events to gather the list of MidiNotes.
         */
        public MidiTrack(List<MidiEvent> events, int tracknum, TimeSignature timesig) {
            this.events = events;
            this.tracknum = tracknum;
            notes = new List<MidiNote>(events.Count);
            midibar = new List<MidiBar>();
            instrument = 0;

            int startoffset = 0, starttick = 0, endoffset = 0, endtick = 0;

            midibar.Add(new MidiBar());
            midibar[0].Timesig = timesig.Clone();
            midibar[0].Startoffset = events[0].StartOffset;
            midibar[0].Starttick = 0;
            endtick = starttick + midibar[midibar.Count - 1].Timesig.GetMeasure();

            //translate midi event into midinote and midibar
            foreach (MidiEvent mevent in events) {
                while ((mevent.StartTime >= endtick) || mevent.Metaevent == MidiFile.MetaEventEndOfTrack) {

                    midibar[midibar.Count - 1].Endoffset = mevent.StartOffset - 1;
                    midibar[midibar.Count - 1].Endtick = endtick;

                    starttick = endtick;
                    endtick = starttick + midibar[midibar.Count - 1].Timesig.GetMeasure();
                    startoffset = mevent.StartOffset;
                    if (mevent.Metaevent != MidiFile.MetaEventEndOfTrack) {
                        midibar.Add(new MidiBar());
                        midibar[midibar.Count - 1].Timesig = midibar[midibar.Count - 2].Timesig.Clone();
                        midibar[midibar.Count - 1].Startoffset = startoffset;
                        midibar[midibar.Count - 1].Starttick = starttick;
                    }
                    else
                        break;
                }
                midibar[midibar.Count - 1].Events.Add(mevent);

                if (mevent.EventFlag == MidiFile.EventNoteOn && mevent.Velocity > 0) {
                    MidiNote note = new MidiNote(mevent.StartOffset, mevent.StartTime, mevent.Channel, mevent.Notenumber, 0);
                    AddNote(note);
                }
                else if (mevent.EventFlag == MidiFile.EventNoteOn && mevent.Velocity == 0) {
                    NoteOff(mevent.Channel, mevent.Notenumber, mevent.StartTime);
                }
                else if (mevent.EventFlag == MidiFile.EventNoteOff) {
                    NoteOff(mevent.Channel, mevent.Notenumber, mevent.StartTime);
                }
                else if (mevent.EventFlag == MidiFile.EventProgramChange) {
                    instrument = mevent.Instrument;
                    midibar[midibar.Count - 1].Instrument = mevent.Instrument;
                }
                else if (mevent.Metaevent == MidiFile.MetaEventKeySignature) {
                    midibar[midibar.Count - 1].Keysignature = mevent.KeySignature;
                }
                else if (mevent.Metaevent == MidiFile.MetaEventTimeSignature) {
                    midibar[midibar.Count - 1].Timesig.Numerator = mevent.Numerator;
                    midibar[midibar.Count - 1].Timesig.Denominator = mevent.Denominator;
                    endtick = starttick + midibar[midibar.Count - 1].Timesig.GetMeasure();
                }
                else if (mevent.Metaevent == MidiFile.MetaEventTempo) {
                    midibar[midibar.Count - 1].Timesig.Tempo = mevent.Tempo;
                    endtick = starttick + midibar[midibar.Count - 1].Timesig.GetMeasure();
                }
                else if (mevent.Metaevent == MidiFile.MetaEventLyric) {
                    if (lyrics == null) {
                        lyrics = new List<MidiEvent>();
                    }
                    lyrics.Add(mevent);
                }
            }

            //add midinote to midibar
            int j = 0;
            for (int i = 0; i < notes.Count;) {
                if (notes[i].StartTime < midibar[j].Endtick)
                    midibar[j].Notes.Add(notes[i++]);
                else
                    j++;
            }

            if (notes.Count > 0 && notes[0].Channel == 9) {
                instrument = 128;  /* Percussion */
            }
            int lyriccount = 0;
            if (lyrics != null) { lyriccount = lyrics.Count; }
        }

        public int Number {
            get { return tracknum; }
        }

        public List<MidiNote> Notes {
            get { return notes; }
        }

        public int Instrument {
            get { return instrument; }
            set { instrument = value; }
        }

        public string InstrumentName {
            get {
                if (instrument >= 0 && instrument <= 128)
                    return MidiFile.Instruments[instrument];
                else
                    return "";
            }
        }

        public List<MidiEvent> Lyrics {
            get { return lyrics; }
            set { lyrics = value; }
        }

        public void addCutPos(int barnum) {
            cutbarnum.Add(barnum);
        }
        public List<int> getCutPos() {
            return cutbarnum;
        }

        public int TrackStart { get => trackstart; set => trackstart = value; }
        public int TrackLen { get => tracklen; set => tracklen = value; }
        public int TrackPulses { get => trackpulses; set => trackpulses = value; }
        public List<MidiEvent> Events { get => events; set => events = value; }
        internal List<MidiBar> Midibar { get => midibar; set => midibar = value; }

        /** Add a MidiNote to this track.  This is called for each NoteOn event */
        public void AddNote(MidiNote m) {
            notes.Add(m);
        }

        /** A NoteOff event occured.  Find the MidiNote of the corresponding
         * NoteOn event, and update the duration of the MidiNote.
         */
        public void NoteOff(int channel, int notenumber, int endtime) {
            for (int i = notes.Count - 1; i >= 0; i--) {
                MidiNote note = notes[i];
                if (note.Channel == channel && note.Number == notenumber &&
                    note.Duration == 0) {
                    note.NoteOff(endtime);
                    return;
                }
            }
        }

        /** Return a deep copy clone of this MidiTrack. */
        public MidiTrack Clone() {
            MidiTrack track = new MidiTrack(Number);
            track.instrument = instrument;
            foreach (MidiNote note in notes) {
                track.notes.Add(note.Clone());
            }
            if (lyrics != null) {
                track.lyrics = new List<MidiEvent>();
                foreach (MidiEvent ev in lyrics) {
                    track.lyrics.Add(ev);
                }
            }
            return track;
        }
        public override string ToString() {
            string result = "Track number=" + tracknum + " instrument=" + instrument + "\n";
            foreach (MidiNote n in notes) {
                result = result + n + "\n";
            }
            result += "End Track\n";
            return result;
        }
    }

}

