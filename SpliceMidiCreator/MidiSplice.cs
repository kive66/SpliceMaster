using System;
using System.Collections.Generic;
using System.IO;

namespace SpliceMaster {

    public struct TrackCut {
        private int tracknum;//the No of track should be cut in the origin midi file
        private int startbar;
        private int endbar;
        private int startnote;
        private int endnote;

        public int Tracknum { get => tracknum; set => tracknum = value; }
        public int Startbar { get => startbar; set => startbar = value; }
        public int Endbar { get => endbar; set => endbar = value; }
        public int Startnote { get => startnote; set => startnote = value; }
        public int Endnote { get => endnote; set => endnote = value; }

        public TrackCut(int tracknum, int startbar, int endbar, int startnote = -1, int endnote = -1) {
            this.tracknum = tracknum;
            this.startbar = startbar;
            this.endbar = endbar;
            this.startnote = startnote;
            this.endnote = endnote;
        }
    }

    public class MidiSplice {
        /* The list of Midi Events */
        public const int EventNoteOff = 0x80;
        public const int EventNoteOn = 0x90;
        public const int EventKeyPressure = 0xA0;
        public const int EventControlChange = 0xB0;
        public const int EventProgramChange = 0xC0;
        public const int EventChannelPressure = 0xD0;
        public const int EventPitchBend = 0xE0;
        public const int SysexEvent1 = 0xF0;
        public const int SysexEvent2 = 0xF7;
        public const int MetaEvent = 0xFF;

        /* The list of Meta Events */
        public const int MetaEventSequence = 0x0;
        public const int MetaEventText = 0x1;
        public const int MetaEventCopyright = 0x2;
        public const int MetaEventSequenceName = 0x3;
        public const int MetaEventInstrument = 0x4;
        public const int MetaEventLyric = 0x5;
        public const int MetaEventMarker = 0x6;
        public const int MetaEventEndOfTrack = 0x2F;
        public const int MetaEventTempo = 0x51;
        public const int MetaEventSMPTEOffset = 0x54;
        public const int MetaEventTimeSignature = 0x58;
        public const int MetaEventKeySignature = 0x59;
        private List<MidiFile> mf;

        /*
         * Store cut mode, store the cut start and end measures of the corresponding numbered track of the file
         */
        private List<TrackCut>[] cutpos;

        public MidiSplice(List<MidiFile> mf, List<TrackCut>[] cp) {
            this.mf = mf;
            cutpos = cp;
        }
        public byte[] Splice() {

            List<byte> result = new List<byte>();

            // Take the tick of the first file as a benchmark
            result.AddRange(CutArray(mf[0].File.GetData(), 0, 13));

            int basetick = mf[0].Time.Quarter;

            // 取第一个文件的平均力度为标准力度
            int stdloudness = mf[0].Loudness;

            // change the total number of audio tracks
            int totalTrackNum = 0;
            foreach (var cp in cutpos) {
                totalTrackNum += cp.Count;
            }
            result[10] = (byte)(0xff00 & totalTrackNum >> 8);
            result[11] = (byte)(0xff & totalTrackNum);


            // whether this midifile need to change pitch
            int[] pitchDelta = new int[mf.Count];
            for (int j = 0; j < pitchDelta.Length; j++)
                pitchDelta[j] = 0;

            int deltatime = 0;
            for (int i = 0; i < mf.Count; i++) {
                // 力度的变化
                int deltaloudness = stdloudness - mf[i].Loudness;

                // delta time between different tracks
                int totaltick = 0;

                // All bytes of the file being operated on
                byte[] data = mf[i].File.GetData();

                for (int j = 0; j < cutpos[i].Count; j++) {
                    // operated audio track
                    MidiTrack track = mf[i].Tracks[cutpos[i][j].Tracknum];

                    // Calculate the offset corresponding to tick
                    var startbar = track.Midibar[cutpos[i][j].Startbar];
                    var endbar = track.Midibar[cutpos[i][j].Endbar - 1];
                    int timeoffset = startbar.Events[0].StartTime - startbar.Starttick;
                    totaltick = endbar.Endtick - startbar.Starttick;
                    // Cut fragment
                    List<byte> fragment = new List<byte>(CutArray(data, startbar.Startoffset, endbar.Endoffset));

                    // Add event flags for events that omit event flags
                    AddNoteOn(ref fragment, cutpos[i][j].Tracknum, timeoffset);


                    // Change pitch or add scale
                    if (j == 0 && i < mf.Count - 1) {
                        // find all last note of current midifile
                        var prior = FindAllLastNote(cutpos[i][j].Endbar - 1, i);
                        for (int k = 0; k < prior.Count; k++)
                            prior[k] += pitchDelta[i];
                        // find the first high note of the next file
                        var next = FindFirstHighNote(cutpos[i + 1][j].Startbar, i + 1);
                        // if the deference between prior[0] and next is not huge(within 4 number)
                        if (Math.Abs(prior[0] % 12 - next % 12) <= 4) {
                            pitchDelta[i + 1] = prior[0] % 12 - next % 12;
                        } else if (Math.Abs(prior[0] % 12 - next % 12 + 12) <= 4) {
                            pitchDelta[i + 1] = prior[0] % 12 - next % 12 + 12;
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

                    // Change pitch
                    if (pitchDelta[i] != 0)
                        ChangePitch(ref fragment, pitchDelta[i]);

                    // Change the velocity of all sounds in the track
                    ChangeLoud(ref fragment, deltaloudness);

                    // Change the tempo of the last bar of the track, tempo is the tempo that should gradually approach
                    if (i < mf.Count - 1)
                        ChangeTempo(mf[i], basetick, mf[i + 1].Time.Tempo * basetick / mf[i].Time.Quarter, endbar.Starttick - startbar.Starttick, ref fragment);
                    // ChangeTempo(mf[i], basetick, mf[i + 1].Time.Tempo*basetick/mf[i+1].Time.Quarter , lastbartick, ref fragment);

                    // add track head
                    int cutlen = fragment.Count;//The total number of bytes of the fragment
                    result.AddRange(GetTrackHead(startbar, cutpos[i][j], basetick, deltatime, cutlen));

                    // add track fragment
                    result.AddRange(fragment);

                    // add track end
                    result.AddRange(new byte[] { 0x00, 0xff, 0x2f, 0x00 });

                }
                deltatime += totaltick;
            }
            return result.ToArray();
        }

        /** write bytes to file */
        public void Write(string filename, byte[] data) {
            FileStream fs = File.Create(filename + ".mid");
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        /** find all last note in the last bar of midifile, return a list of notenumber(in decrease order) */
        List<int> FindAllLastNote(int barNum, int mfNum) {
            var lastNote = new List<int>();
            var lastBar = new List<MidiBar>();
            for (int i = 0; i < mf[mfNum].Tracks.Count; i++)
                lastBar.Add(mf[mfNum].Tracks[i].Midibar[barNum]);
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
            for (int i = 0; i < mf[mfNum].Tracks.Count; i++)
                firstBar.Add(mf[mfNum].Tracks[i].Midibar[barNum]);
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
        void AddChord(int trackNum, ref List<byte> fragment, ref List<byte> noteNum, int velocity, int delta) {
            var noteOnEvent = (byte)(0x90 + trackNum);
            for (int i = 0; i < noteNum.Count; i++) {  // add note on
                fragment.Add(0x00);
                fragment.Add(noteOnEvent);
                fragment.Add(noteNum[i]);
                fragment.Add((byte)velocity);
            }
            for (int i = 0; i < noteNum.Count; i++) {  // add note off
                if (i == 0)
                    fragment.AddRange(IntToVarlen(delta, true));
                else
                    fragment.Add(0x00);
                fragment.Add(noteOnEvent);
                fragment.Add(noteNum[i]);
                fragment.Add(0x00);
            }
        }

        /** change tempo of the last bar */
        public void ChangeTempo(MidiFile mf, int stdTicks, int stdTempo, int lastbartick, ref List<byte> fragment) {
            int tempo = mf.Time.Tempo * stdTicks / mf.Quarternote;
            int offset = 0, lastbaroffset = 0;
            int eventflag = 0;
            int notecount = 0;
            int deltatime = 0;
            while (offset < fragment.Count) {
                deltatime += ReadVarlen(fragment, ref offset);
                if (offset >= fragment.Count) break;


                byte peekevent = fragment[offset];

                if (peekevent >= EventNoteOff)
                    eventflag = fragment[offset++];
                if (eventflag >= MidiFile.EventNoteOn && eventflag < MidiFile.EventNoteOn + 16) {
                    if (deltatime >= lastbartick) {
                        if (lastbaroffset == 0)
                            lastbaroffset = offset - 2;
                        notecount++;
                    }
                    offset++;  // notenumber
                    offset++; // velocity
                } else if (eventflag >= MidiFile.EventNoteOff && eventflag < MidiFile.EventNoteOff + 16) {
                    offset++;  // notenumber
                    offset++;  // velocity
                } else if (eventflag >= MidiFile.EventKeyPressure &&
                           eventflag < MidiFile.EventKeyPressure + 16) {
                    offset++; // motenumber
                    offset++;  // pressure
                } else if (eventflag >= MidiFile.EventControlChange &&
                           eventflag < MidiFile.EventControlChange + 16) {
                    offset++;  // controlNum
                    offset++; // controlValue
                } else if (eventflag >= MidiFile.EventProgramChange &&
                           eventflag < MidiFile.EventProgramChange + 16)
                    offset++; // instrument
                else if (eventflag >= MidiFile.EventChannelPressure &&
                         eventflag < MidiFile.EventChannelPressure + 16)
                    offset++;  // chanPressure
                else if (eventflag >= MidiFile.EventPitchBend &&
                         eventflag < MidiFile.EventPitchBend + 16)
                    offset++; // pitchBend
                else if (eventflag == SysexEvent1) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == SysexEvent2) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == MetaEvent) {
                    int Metaevent = fragment[offset++];  // metaEvent
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                    if (Metaevent == MetaEventEndOfTrack)
                        break;
                }
            }

            offset = lastbaroffset;
            int count = 0;
            while (offset < fragment.Count && notecount != 0) {
                int temp = offset;
                ReadVarlen(fragment, ref offset);
                if (offset >= fragment.Count) break;
                byte peekevent = fragment[offset];

                if (peekevent >= EventNoteOff)
                    eventflag = fragment[offset++];
                if (eventflag >= MidiFile.EventNoteOn && eventflag < MidiFile.EventNoteOn + 16) {
                    count++;
                    byte[] data = IntToVarlen(tempo + (stdTempo - tempo) * count / notecount);
                    fragment.InsertRange(temp, new byte[] { 0x00, 0xff, 0x51 });
                    fragment.InsertRange(temp + 3, data);
                    //Console.WriteLine("deltatime:"+delta);
                    //Console.WriteLine("tempo:"+(tempo + (stdTempo - tempo) * count1 / count).ToString("x"));
                    //for (int j = i - delta; j <= i + 7; j++) Console.Write(fragment[j].ToString("x"));
                    //Console.Write("\n");
                    offset += (3 + data.Length);
                    offset++;  // notenumber
                    offset++; // velocity
                } else if (eventflag >= MidiFile.EventNoteOff && eventflag < MidiFile.EventNoteOff + 16) {
                    offset++;  // notenumber
                    offset++;  // velocity
                } else if (eventflag >= MidiFile.EventKeyPressure &&
                           eventflag < MidiFile.EventKeyPressure + 16) {
                    offset++; // motenumber
                    offset++;  // pressure
                } else if (eventflag >= MidiFile.EventControlChange &&
                           eventflag < MidiFile.EventControlChange + 16) {
                    offset++;  // controlNum
                    offset++; // controlValue
                } else if (eventflag >= MidiFile.EventProgramChange &&
                           eventflag < MidiFile.EventProgramChange + 16)
                    offset++; // instrument
                else if (eventflag >= MidiFile.EventChannelPressure &&
                         eventflag < MidiFile.EventChannelPressure + 16)
                    offset++;  // chanPressure
                else if (eventflag >= MidiFile.EventPitchBend &&
                         eventflag < MidiFile.EventPitchBend + 16)
                    offset++; // pitchBend
                else if (eventflag == SysexEvent1) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == SysexEvent2) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == MetaEvent) {
                    int Metaevent = fragment[offset++];  // metaEvent
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                    if (Metaevent == MetaEventEndOfTrack)
                        break;
                }
            }
            //Console.WriteLine(BitConverter.ToString(result.ToArray()));
        }

        /** change loud of the fragment */
        public void ChangeLoud(ref List<byte> fragment, int delta) {
            int offset = 0;
            int eventflag = 0;

            while (offset < fragment.Count) {

                ReadVarlen(fragment, ref offset);  // deltatime
                if (offset >= fragment.Count) {
                    break;
                }
                byte peekevent = fragment[offset];

                if (peekevent >= EventNoteOff)
                    eventflag = fragment[offset++];

                if (eventflag >= EventNoteOn && eventflag < EventNoteOn + 16) {
                    offset++;  // notenumber
                    if (fragment[offset] != 0) {
                        fragment[offset] += (byte)delta;
                    }
                    offset++;  // velocity
                } else if (eventflag >= EventNoteOff && eventflag < EventNoteOff + 16) {
                    offset++;  // notenumber
                    offset++;  // velocity
                } else if (eventflag >= EventKeyPressure &&
                           eventflag < EventKeyPressure + 16) {
                    offset++;  // motenumber
                    offset++;  // pressure
                } else if (eventflag >= EventControlChange &&
                           eventflag < EventControlChange + 16) {
                    offset++;  // controlNum
                    offset++;  // controlValue
                } else if (eventflag >= EventProgramChange &&
                           eventflag < EventProgramChange + 16)
                    offset++;  // instrument
                else if (eventflag >= EventChannelPressure &&
                         eventflag < EventChannelPressure + 16)
                    offset++;  // chanPressure
                else if (eventflag >= EventPitchBend &&
                         eventflag < EventPitchBend + 16)
                    offset++;  // pitchBend
                else if (eventflag == SysexEvent1) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == SysexEvent2) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == MetaEvent) {
                    int Metaevent = fragment[offset++];  // metaEvent
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                    if (Metaevent == MetaEventEndOfTrack)
                        break;
                }
            }
        }

        /** change pitch of the fragment */
        public void ChangePitch(ref List<byte> fragment, int delta) {
            int offset = 0;
            int eventflag = 0;

            while (offset < fragment.Count) {

                ReadVarlen(fragment, ref offset);  // deltatime
                if (offset >= fragment.Count) {
                    break;
                }
                byte peekevent = fragment[offset];

                if (peekevent >= EventNoteOff)
                    eventflag = fragment[offset++];

                if (eventflag >= EventNoteOn && eventflag < EventNoteOn + 16) {
                    fragment[offset] += (byte)delta;
                    offset++;  // notenumber
                    offset++;  // velocity
                } else if (eventflag >= EventNoteOff && eventflag < EventNoteOff + 16) {
                    fragment[offset] += (byte)delta;
                    offset++;  // notenumber
                    offset++;  // velocity
                } else if (eventflag >= EventKeyPressure &&
                           eventflag < EventKeyPressure + 16) {
                    offset++;  // motenumber
                    offset++;  // pressure
                } else if (eventflag >= EventControlChange &&
                           eventflag < EventControlChange + 16) {
                    offset++;  // controlNum
                    offset++;  // controlValue
                } else if (eventflag >= EventProgramChange &&
                           eventflag < EventProgramChange + 16)
                    offset++;  // instrument
                else if (eventflag >= EventChannelPressure &&
                         eventflag < EventChannelPressure + 16)
                    offset++;  // chanPressure
                else if (eventflag >= EventPitchBend &&
                         eventflag < EventPitchBend + 16)
                    offset++;  // pitchBend
                else if (eventflag == SysexEvent1) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == SysexEvent2) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == MetaEvent) {
                    int Metaevent = fragment[offset++];  // metaEvent
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                    if (Metaevent == MetaEventEndOfTrack)
                        break;
                }
            }
        }

        /** Add key press to fragment */
        public void AddNoteOn(ref List<byte> fragment, int tracknum, int timeoffset) {
            int eventflag, offset = 0;

            ReadVarlen(fragment, ref offset);  // deltatime
            for (int i = 0; i < offset; i++)
                fragment.RemoveAt(0);
            fragment.InsertRange(0, IntToVarlen(timeoffset, true));
            offset = 0;

            ReadVarlen(fragment, ref offset);  // deltatime
            eventflag = fragment[offset++];

            if (eventflag < 0x80) {
                while (offset < fragment.Count) {
                    fragment.Insert(offset - 1, (byte)(0x90 | (byte)tracknum));
                    offset++;   // notenumber
                    offset++;   // velocity
                    if (offset >= fragment.Count)
                        break;
                    ReadVarlen(fragment, ref offset);
                    eventflag = fragment[offset++];
                    if (eventflag >= 0x80)
                        break;
                }
            }
        }

        /**get track head*/
        public byte[] GetTrackHead(MidiBar startbar, TrackCut cp, int basetick, int deltatime, int cutlen) {
            List<byte> result = new List<byte>();

            //mtrk
            result.AddRange(new byte[] { 0x4D, 0x54, 0x72, 0x6B });

            //deltatime
            result.AddRange(IntToVarlen(deltatime, true));

            //instrument
            result.AddRange(new byte[] { (byte)(0xC0 | (0x0f & cp.Tracknum)), (byte)(0xff & startbar.Instrument) });

            //beat
            result.AddRange(new byte[] { 0x00, 0xFF, 0x58, 0x04, (byte)(0xff & startbar.Timesig.Numerator), (byte)(0xff & (int)Math.Log(startbar.Timesig.Denominator, 2)), 0x00, 0x00 });

            //tempo（microseconds/beat）
            int newTempo = startbar.Timesig.Tempo * basetick / startbar.Timesig.Quarter;
            result.AddRange(new byte[] { 0x00, 0xff, 0x51 });
            result.AddRange(IntToVarlen(newTempo));

            //key signature
            result.AddRange(new byte[] { 0x00, 0xff, 0x59, 0x02, startbar.Keysignature, 0x00 });

            //total bytes of the track
            cutlen += result.Count - 4 + 4;//-4=mtrk，+4=00 ff 2f 00
            byte[] len = BitConverter.GetBytes(cutlen);
            Array.Reverse(len);
            result.InsertRange(4, len);

            return result.ToArray();
        }

        /**Cut the array according to the start and end positions*/
        public byte[] CutArray(byte[] data, int start, int end) {
            if (start > data.Length || end > data.Length)
                throw new Exception();
            int len = end - start + 1;
            byte[] result = new byte[len];
            Array.Copy(data, start, result, 0, len);
            return result;
        }

        /** Read variable length bytes with flag */
        public int ReadVarlen(List<byte> data, ref int offset) {
            uint result = 0;
            byte b = data[offset++];
            result = (uint)(b & 0x7f);

            for (int i = 0; i < 3; i++) {
                if ((b & 0x80) != 0) {
                    b = data[offset++];
                    result = (uint)((result << 7) + (b & 0x7f));
                } else {
                    break;
                }
            }
            return (int)result;
        }

        /**Convert int to variable length byte array, the first is the array length*/
        public byte[] IntToVarlen(int i) {
            byte[] temp = System.BitConverter.GetBytes(i);
            Array.Reverse(temp);
            temp[0] = 0x03;
            return temp;
        }

        /**Convert int to variable length byte array with flag*/
        public byte[] IntToVarlen(int i, bool flag) {
            List<byte> result = new List<byte>();
            List<int> temp = new List<int>();
            if (i == 0)
                return new byte[] { 0 };
            while (i != 0) {
                temp.Add(i % 128);
                i /= 128;
            }
            for (int j = temp.Count - 1; j > 0; j--) {
                result.Add((byte)(temp[j] | 0x80));
            }
            result.Add((byte)temp[0]);
            return result.ToArray();
        }

        public void FadeIn(ref List<byte> fragment, int n) //fade-in & fade-out
        {
            if (fragment.Count <= 2 * n) return;
            int offset = 0;
            int eventflag = 0;
            int count = 0;
            Queue<int> temp = new Queue<int>();

            while (offset < fragment.Count) {
                ReadVarlen(fragment, ref offset);  // deltatime
                if (offset >= fragment.Count) {
                    break;
                }
                byte peekevent = fragment[offset];

                if (peekevent >= EventNoteOff)
                    eventflag = fragment[offset++];

                if (eventflag >= EventNoteOn && eventflag < EventNoteOn + 16) {
                    offset++;  // notenumber
                    count++;

                    if (count <= n) {
                        //Console.WriteLine();
                        fragment[offset] = (byte)(fragment[offset] * count / n);
                    } else break;
                    offset++;  // velocity
                } else if (eventflag >= EventNoteOff && eventflag < EventNoteOff + 16) {
                    offset++;  // notenumber
                    offset++;  // velocity
                } else if (eventflag >= EventKeyPressure &&
                           eventflag < EventKeyPressure + 16) {
                    offset++;  // motenumber
                    offset++;  // pressure
                } else if (eventflag >= EventControlChange &&
                           eventflag < EventControlChange + 16) {
                    offset++;  // controlNum
                    offset++;  // controlValue
                } else if (eventflag >= EventProgramChange &&
                           eventflag < EventProgramChange + 16)
                    offset++;  // instrument
                else if (eventflag >= EventChannelPressure &&
                         eventflag < EventChannelPressure + 16)
                    offset++;  // chanPressure
                else if (eventflag >= EventPitchBend &&
                         eventflag < EventPitchBend + 16)
                    offset++;  // pitchBend
                else if (eventflag == SysexEvent1) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == SysexEvent2) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == MetaEvent) {
                    int Metaevent = fragment[offset++];  // metaEvent
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                    if (Metaevent == MetaEventEndOfTrack)
                        break;
                }
            }
        }
        public void FadeOut(ref List<byte> fragment, int n) //fade-in & fade-out
        {
            if (fragment.Count <= 2 * n) return;
            int offset = 0;
            int eventflag = 0;
            int count = 0;
            Queue<int> temp = new Queue<int>();

            while (offset < fragment.Count) {
                ReadVarlen(fragment, ref offset);  // deltatime
                if (offset >= fragment.Count) {
                    break;
                }
                byte peekevent = fragment[offset];

                if (peekevent >= EventNoteOff)
                    eventflag = fragment[offset++];

                if (eventflag >= EventNoteOn && eventflag < EventNoteOn + 16) {
                    offset++;  // notenumber
                    if (temp.Count == n) {
                        temp.Dequeue();
                        temp.Enqueue(offset);
                    } else temp.Enqueue(offset);
                    offset++;  // velocity
                } else if (eventflag >= EventNoteOff && eventflag < EventNoteOff + 16) {
                    offset++;  // notenumber
                    offset++;  // velocity
                } else if (eventflag >= EventKeyPressure &&
                           eventflag < EventKeyPressure + 16) {
                    offset++;  // motenumber
                    offset++;  // pressure
                } else if (eventflag >= EventControlChange &&
                           eventflag < EventControlChange + 16) {
                    offset++;  // controlNum
                    offset++;  // controlValue
                } else if (eventflag >= EventProgramChange &&
                           eventflag < EventProgramChange + 16)
                    offset++;  // instrument
                else if (eventflag >= EventChannelPressure &&
                         eventflag < EventChannelPressure + 16)
                    offset++;  // chanPressure
                else if (eventflag >= EventPitchBend &&
                         eventflag < EventPitchBend + 16)
                    offset++;  // pitchBend
                else if (eventflag == SysexEvent1) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == SysexEvent2) {
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                } else if (eventflag == MetaEvent) {
                    int Metaevent = fragment[offset++];  // metaEvent
                    int metaLength = fragment[offset++];  // metaLength
                    offset += metaLength;  // value
                    if (Metaevent == MetaEventEndOfTrack)
                        break;
                }
            }
            for (int i = 0; i < n; i++) {
                if (temp.Count != 0) {
                    fragment[temp.Peek()] = (byte)(fragment[temp.Peek()] * (n - i) / n);
                    temp.Dequeue();
                }
            }
            Console.WriteLine(BitConverter.ToString(fragment.ToArray()));
        }
    }
}
