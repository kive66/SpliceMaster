using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpliceMaster {
    public class NewSplice {
        private int stdtick;
        private int stdloud;
        private int tracknum;
        private List<MidiFile> midifile;
        private List<List<MidiBar>>[] miditrack;
        private List<TrackCut>[] cutpos;

        public NewSplice(List<MidiFile> midifile, List<TrackCut>[] cutpos) {
            this.midifile = midifile;
            this.cutpos = cutpos;
            stdtick = midifile[0].Quarternote;
            stdloud = midifile[0].Loudness;

            foreach (var cp in cutpos)
                tracknum += cp.Count;
            miditrack = new List<List<MidiBar>>[midifile.Count];

            // cut bar of midi tracks
            for (int i = 0; i < cutpos.Length; i++) {
                miditrack[i] = new List<List<MidiBar>>();
                foreach (var cp in cutpos[i]) {
                    MidiTrack track_ = midifile[i].Tracks[cp.Tracknum];
                    if (cp.Startbar >= cp.Endbar || cp.Startbar > track_.Midibar.Count || cp.Endbar > track_.Midibar.Count)
                        throw new Exception("bar out of range");
                    if (track_.Midibar[0].Notes.Count <= cp.Startnote || track_.Midibar[track_.Midibar.Count - 1].Notes.Count <= cp.Endnote)
                        throw new Exception("note out of range");
                    miditrack[i].Add(track_.Midibar.GetRange(cp.Startbar, cp.Endbar - cp.Startbar));

                    // cut note in the bar
                    int count = 0;
                    if (cp.Startnote != -1) {
                        var startbar = miditrack[i][miditrack[i].Count - 1][0];
                        foreach (var event_ in startbar.Events)
                            if (event_.StartTime < startbar.Notes[cp.Startnote].StartTime)
                                count++;
                            else break;
                        startbar.Events.RemoveRange(0, count);
                    }
                    if (cp.Endnote != -1) {
                        var endbar = miditrack[i][miditrack[i].Count - 1][miditrack[i][miditrack[i].Count - 1].Count - 1];
                        foreach (var event_ in endbar.Events)
                            if (event_.StartTime < endbar.Notes[cp.Endnote].StartTime)
                                count++;
                            else break;
                        endbar.Events.RemoveRange(count, endbar.Events.Count);
                    }
                }
            }
        }

        public void Splice() {
            int deltatime = 0, deltaloud = 0, stdtempo = 0;
            int[] deltapitch = new int[midifile.Count];
            for (int i = 0; i < midifile.Count; i++) {

                deltaloud = stdloud - midifile[i].Loudness;
                if (i < midifile.Count - 1)
                    stdtempo = midifile[i + 1].Time.Tempo * stdtick / midifile[i].Time.Quarter;
                else
                    stdtempo = midifile[i].Time.Tempo * stdtick / midifile[i].Time.Quarter;

                for (int j = 0; j < cutpos[i].Count; j++) {
                    List<MidiBar> midibar = miditrack[i][j];

                    if (j == 0 && i < midifile.Count - 1) {
                        // find all last note of current midifile
                        var prior = FindAllLastNote(cutpos[i][j].Endbar - 1, i);
                        for (int k = 0; k < prior.Count; k++)
                            prior[k] += deltapitch[i];
                        // find the first high note of the next file
                        var next = FindFirstHighNote(cutpos[i + 1][j].Startbar, i + 1);
                        // if the deference between prior[0] and next is not huge(within 4 number)
                        if (Math.Abs(prior[0] % 12 - next % 12) <= 4) {
                            deltapitch[i + 1] = prior[0] % 12 - next % 12;
                        } else if (Math.Abs(prior[0] % 12 - next % 12 + 12) <= 4) {
                            deltapitch[i + 1] = prior[0] % 12 - next % 12 + 12;
                        }
                        /*
                        else { // or add note scale
                            totaltick += mf[i].Quarternote * 2;  //
                            int target = next;
                            int[] cScale = { 0, 2, 4, 5, 7, 9, 11 };
                            if (target > prior[0]) {  // ascend scale
                                while (target - 12 > prior[0])
                                    target -= 12;
                                // insertion
                                int temp = prior[0];
                                for (int k = 0; k < 3; k++) {
                                    while (true) {
                                        temp++;
                                        int p;
                                        for (p = 0; p < cScale.Length; p++)
                                            if (temp % 12 == cScale[p])
                                                break;
                                        if (p != cScale.Length) {
                                            var noteScale = new List<byte>();
                                            for (int q = 0; q < prior.Count; q++)
                                                noteScale.Add((byte)(temp - (prior[0] - prior[q])));
                                            // add note or chord(eighth note)
                                            AddChord(j, ref fragment, ref noteScale, stdloudness, mf[i].Quarternote / 2);
                                            break;
                                        }
                                    }
                                }
                                var lastNote = new List<byte>();
                                for (int k = 0; k < prior.Count; k++)
                                    lastNote.Add((byte)(target - (prior[0] - prior[k])));
                                AddChord(j, ref fragment, ref lastNote, stdloudness, mf[i].Quarternote / 2);
                            } else { // descend scale
                                while (target + 12 < prior[0])
                                    target += 12;
                                // insertion
                                int temp = prior[0];
                                for (int k = 0; k < 3; k++) {
                                    while (true) {
                                        temp--;
                                        int p;
                                        for (p = 0; p < cScale.Length; p++)
                                            if (temp % 12 == cScale[p])
                                                break;
                                        if (p != cScale.Length) {
                                            var noteScale = new List<byte>();
                                            for (int q = 0; q < prior.Count; q++)
                                                noteScale.Add((byte)(temp - (prior[0] - prior[q])));
                                            // add note or chord(eighth note)
                                            AddChord(j, ref fragment, ref noteScale, stdloudness, mf[i].Quarternote / 2);
                                            break;
                                        }
                                    }
                                }
                                var lastNote = new List<byte>();
                                for (int k = 0; k < prior.Count; k++)
                                    lastNote.Add((byte)(target - (prior[0] - prior[k])));
                                AddChord(j, ref fragment, ref lastNote, stdloudness, mf[i].Quarternote / 2);
                            }
                        }
                        */
                    }

                    ChangeStartTime(ref midibar, deltatime);
                    ChangePitch(ref midibar, deltapitch[i]);
                    ChangeLoud(ref midibar, deltaloud);
                    ChangeTempo(ref midibar, stdtempo);
                    /*if (i == 0) {
                        FadeIn(ref midibar);
                    }*/
                    if (i == midifile.Count - 1) {
                        FadeOut(ref midibar);
                    }
                }
                deltatime += miditrack[i][0][miditrack[i][0].Count - 1].Endtick - miditrack[i][0][0].Starttick;
            }
        }
        public void WriteToFile(string name) {
            var fileWriter = new MidiFileWriter(name);
            fileWriter.WriteHead(tracknum, stdtick);
            foreach (var tracks in miditrack)
                for (int i = 0; i < tracks.Count; i++)
                    fileWriter.WriteTrack(tracks[i], i);
            fileWriter.Write();
        }

        public void ChangeStartTime(ref List<MidiBar> midibar, int deltatime) {
            int timeoffset = midibar[0].Events[0].StartTime - midibar[0].Starttick;
            midibar[0].Events[0].DeltaTime = timeoffset;
            midibar[0].Events[0].StartTime = deltatime;
        }

        public void ChangePitch(ref List<MidiBar> midibar, int deltapitch) {
            for (int i = 0; i < midibar.Count; i++) {
                var events = midibar[i].Events;
                for (int j = 0; j < events.Count; j++) {
                    if (events[j].EventFlag == MidiFile.EventNoteOn)
                        events[j].Notenumber += (byte)deltapitch;
                    else if (events[j].EventFlag == MidiFile.EventNoteOff)
                        events[j].Notenumber += (byte)deltapitch;
                }
            }
        }
        public void ChangeLoud(ref List<MidiBar> midibar, int deltaloud) {
            for (int i = 0; i < midibar.Count; i++) {
                var events = midibar[i].Events;
                for (int j = 0; j < events.Count; j++) {
                    if (events[j].EventFlag == MidiFile.EventNoteOn && events[j].Velocity != 0)
                        events[j].Velocity += (byte)deltaloud;
                }
            }
        }

        public void ChangeTempo(ref List<MidiBar> midibar, int stdtempo) {
            int newtempo = midibar[0].Timesig.Tempo * stdtick / midibar[0].Timesig.Quarter;
            midibar[0].Timesig.Tempo = newtempo;

            if (midibar[midibar.Count - 1].Notes.Count != 0) {
                int deltatempo = (stdtempo - newtempo) / midibar[midibar.Count - 1].Notes.Count;
                var events = midibar[midibar.Count - 1].Events;
                int notecount = 0;
                for (int i = 0; i < events.Count; i++) {
                    if (events[i].EventFlag == MidiFile.EventNoteOn && events[i].Velocity != 0) {
                        var event_ = new MidiEvent();
                        event_.DeltaTime = 0;
                        event_.StartTime = events[i].StartTime;
                        event_.EventFlag = MidiFile.MetaEvent;
                        event_.Metaevent = MidiFile.MetaEventTempo;
                        event_.Tempo = newtempo + (++notecount) * deltatempo;
                        events.Insert(i++, event_);
                    }
                }
            }
        }

        public void FadeIn(ref List<MidiBar> midibar) {
            int count = 0, total = 0;
            MidiBar startbar = null;
            for (int i = 0; i < midibar.Count; i++)
                if (midibar[i].Notes.Count >1) {
                    startbar = midibar[i];
                    total = startbar.Notes.Count;
                    break;
                }

            for (int i = 0; i < startbar.Events.Count; i++) {
                var event_ = startbar.Events[i];
                if (event_.EventFlag == MidiFile.EventNoteOn && event_.Velocity != 0)
                    event_.Velocity = (byte)(event_.Velocity * ++count / total);
            }
        }

        public void FadeOut(ref List<MidiBar> midibar) {
            int count = 0, total = 0;
            MidiBar endbar = null;
            for (int i = midibar.Count - 1; i >= 0; i--)
                if (midibar[i].Notes.Count >1 ) {
                    endbar = midibar[i];
                    total = endbar.Notes.Count;
                    break;
                }

            for (int i = 0; i < endbar.Events.Count; i++) {
                var event_ = endbar.Events[i];
                if (event_.EventFlag == MidiFile.EventNoteOn && event_.Velocity != 0)
                    event_.Velocity = (byte)(event_.Velocity * (total - 0.5 * count++) / total);
            }
        }

        /** find all last note in the last bar of midifile, return a list of notenumber(in decrease order) */
        List<int> FindAllLastNote(int barNum, int mfNum) {
            var lastNote = new List<int>();
            var lastBar = new List<MidiBar>();
            for (int i = 0; i < midifile[mfNum].Tracks.Count; i++)
                lastBar.Add(midifile[mfNum].Tracks[i].Midibar[barNum]);
            int lastStartTime = 0;
            for (int i = 0; i < lastBar.Count; i++) {
                if (lastBar[i].Notes.Count == 0) {
                    lastBar[i] = null;
                    continue;
                }
                if (lastBar[i].Notes[lastBar[i].Notes.Count - 1].StartTime > lastStartTime) {
                    for (int j = 0; j < i; j++)
                        lastBar[j] = null;
                    lastStartTime = lastBar[i].Notes[lastBar[i].Notes.Count - 1].StartTime;
                } else if (lastBar[i].Notes[lastBar[i].Notes.Count - 1].StartTime < lastStartTime)
                    lastBar[i] = null;
            }
            for (int i = 0; i < lastBar.Count; i++) {
                if (lastBar[i] == null)
                    continue;
                for (int j = lastBar[i].Notes.Count - 1; j >= 0 && lastBar[i].Notes[j].StartTime == lastStartTime; j--)
                    lastNote.Add(lastBar[i].Notes[j].Number);
            }
            // in decrease order
            lastNote.Sort();
            lastNote.Reverse();
            return lastNote;
        }

        /** find the first highest note of a list of note, return the note number */
        int FindFirstHighNote(int barNum, int mfNum) {
            var firstNote = new List<int>();
            var firstBar = new List<MidiBar>();
            for (int i = 0; i < midifile[mfNum].Tracks.Count; i++)
                firstBar.Add(midifile[mfNum].Tracks[i].Midibar[barNum]);
            int firstStartTime = int.MaxValue;
            for (int i = 0; i < firstBar.Count; i++) {
                if (firstBar[i].Notes.Count == 0) {
                    firstBar[i] = null;
                    continue;
                }
                if (firstBar[i].Notes[0].StartTime < firstStartTime) {
                    for (int j = 0; j < i; j++)
                        firstBar[j] = null;
                    firstStartTime = firstBar[i].Notes[0].StartTime;
                } else if (firstBar[i].Notes[0].StartTime < firstStartTime)
                    firstBar[i] = null;
            }
            for (int i = 0; i < firstBar.Count; i++) {
                if (firstBar[i] == null)
                    continue;
                for (int j = 0; j < firstBar[i].Notes.Count && firstBar[i].Notes[j].StartTime == firstStartTime; j++)
                    firstNote.Add(firstBar[i].Notes[j].Number);
            }
            // in decrease order
            firstNote.Sort();
            firstNote.Reverse();
            return firstNote[0];
        }

        /** add chord(if notenumber.Count == 1, then equals to add note) */
        void AddChord(int trackNum, ref MidiBar lastBar, List<byte> noteNum, int velocity, int delta) {
            for (int i = 0; i < noteNum.Count; i++) {  // add note on
                MidiEvent event_ = new MidiEvent();
                event_.DeltaTime = 0;
                event_.EventFlag = MidiFile.EventNoteOn;
                event_.Channel = (byte)tracknum;
                event_.Notenumber = noteNum[i];
                event_.Velocity = (byte)velocity;
                lastBar.Events.Add(event_);
            }
            for (int i = 0; i < noteNum.Count; i++) {  // add note off
                MidiEvent event_ = new MidiEvent();
                if (i == 0)
                    event_.DeltaTime = delta;
                else
                    event_.DeltaTime = 0;
                event_.EventFlag = MidiFile.EventNoteOff;
                event_.Channel = (byte)tracknum;
                event_.Notenumber = noteNum[i];
                event_.Velocity = 0x00;
                lastBar.Events.Add(event_);
            }
        }
    }
}
