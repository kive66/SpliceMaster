using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpliceMaster {
    class MidiFileWriter {
        private FileStream file;
        private List<byte> data;
        public MidiFileWriter(string filename) {
            try {
                file = File.Create(filename + ".mid");
            }catch(Exception e) {
                
            }
            data = new List<byte>();
        }

        public void Write() {
            file.Write(data.ToArray(), 0, data.Count);
            file.Close();
        }

        /** Write midi head */
        public void WriteHead(int tracknum, int stdtick) {
            data.AddRange(new byte[] { 0x4d, 0x54, 0x68, 0x64 });
            data.AddRange(new byte[] { 0x00, 0x00, 0x00, 0x06 });
            data.AddRange(ShortToBytes(1));
            data.AddRange(ShortToBytes(tracknum));
            data.AddRange(ShortToBytes(stdtick));
        }

        /** Write track with parameters */
        public void WriteTrack(List<MidiBar> midibar, int tracknum) {
            data.AddRange(new byte[] { 0x4d, 0x54, 0x72, 0x6b });
            int len1 = data.Count;
            int len2 = 0;

            data.AddRange(IntToVarlen(midibar[0].Events[0].StartTime, true));
            data.AddRange(new byte[] { (byte)(0xC0 | (0x0f & tracknum)), (byte)(0xff & midibar[0].Instrument) });
            data.AddRange(new byte[] { 0x00, 0xFF, 0x58, 0x04, (byte)(0xff & midibar[0].Timesig.Numerator), (byte)(0xff & (int)Math.Log(midibar[0].Timesig.Denominator, 2)), 0x00, 0x00 });
            data.AddRange(new byte[] { 0x00, 0xff, 0x51 });
            data.AddRange(IntToVarlen(midibar[0].Timesig.Tempo));
            data.AddRange(new byte[] { 0x00, 0xff, 0x59, 0x02, midibar[0].Keysignature, 0x00 });

            foreach (var bar in midibar)
                foreach (var event_ in bar.Events)
                    WriteEvent(event_);

            data.AddRange(new byte[] { 0x00, 0xff, 0x2f, 0x00 });

            len2 = data.Count;
            data.InsertRange(len1, IntToBytes(len2 - len1));
        }

        /** Write midi events to bytes */
        public void WriteEvent(MidiEvent event_) {
            switch (event_.EventFlag) {
                case MidiFile.EventNoteOn:
                    data.AddRange(IntToVarlen(event_.DeltaTime, true));
                    data.Add((byte)(0x90 | event_.Channel));
                    data.Add(event_.Notenumber);
                    data.Add(event_.Velocity);
                    break;
                case MidiFile.EventNoteOff:
                    data.AddRange(IntToVarlen(event_.DeltaTime, true));
                    data.Add((byte)(0x80 | event_.Channel));
                    data.Add(event_.Notenumber);
                    data.Add(event_.Velocity);
                    break;
                case MidiFile.EventKeyPressure:
                    data.AddRange(IntToVarlen(event_.DeltaTime, true));
                    data.Add((byte)(0xA0 | event_.Channel));
                    data.Add(event_.Notenumber);
                    data.Add(event_.KeyPressure);
                    break;
                case MidiFile.EventControlChange:
                    data.AddRange(IntToVarlen(event_.DeltaTime, true));
                    data.Add((byte)(0xB0 | event_.Channel));
                    data.Add(event_.ControlNum);
                    data.Add(event_.ControlValue);
                    break;
                case MidiFile.EventProgramChange:
                    data.AddRange(IntToVarlen(event_.DeltaTime, true));
                    data.Add((byte)(0xC0 | event_.Channel));
                    data.Add(event_.Instrument);
                    break;
                case MidiFile.EventChannelPressure:
                    data.AddRange(IntToVarlen(event_.DeltaTime, true));
                    data.Add((byte)(0xD0 | event_.Channel));
                    data.Add(event_.ChanPressure);
                    break;
                case MidiFile.EventPitchBend:
                    data.AddRange(IntToVarlen(event_.DeltaTime, true));
                    data.Add((byte)(0xE0 | event_.Channel));
                    data.Add((byte)(event_.PitchBend >> 8));
                    data.Add((byte)(event_.PitchBend));
                    break;
                case MidiFile.MetaEvent:
                    switch (event_.Metaevent) {
                        case MidiFile.MetaEventTempo:
                            data.AddRange(IntToVarlen(event_.DeltaTime, true));
                            data.Add(0xff);
                            data.Add(0x51);
                            data.AddRange(IntToVarlen(event_.Tempo));
                            break;
                        case MidiFile.MetaEventTimeSignature:
                            data.AddRange(IntToVarlen(event_.DeltaTime, true));
                            data.Add(0xff);
                            data.Add(0x58);
                            data.AddRange(new byte[] { 0x04, event_.Numerator, (byte)(int)Math.Log(event_.Denominator,2), 0x00, 0x00 });
                            break;
                        case MidiFile.MetaEventKeySignature:
                            data.AddRange(IntToVarlen(event_.DeltaTime, true));
                            data.Add(0xff);
                            data.Add(0x59);
                            data.AddRange(new byte[] { 0x02, event_.KeySignature, 0x00 });
                            break;
                        case MidiFile.MetaEventEndOfTrack:
                            data.AddRange(IntToVarlen(event_.DeltaTime, true));
                            data.Add(0xff);
                            data.Add(0x2f);
                            data.Add(0x00);
                            break;
                    }
                    break;
            }
        }

        /**Convert int to 4 byte*/
        public byte[] IntToBytes(int i) {
            byte[] result = new byte[4];
            result[0] = (byte)(i >> 24);
            result[1] = (byte)(i >> 16);
            result[2] = (byte)(i >> 8);
            result[3] = (byte)(i);
            return result;
        }

        /**Convert short to 2 byte*/
        public byte[] ShortToBytes(int i) {
            byte[] result = new byte[2];
            result[0] = (byte)(i >> 8);
            result[1] = (byte)(i);
            return result;
        }

        /** Read variable length bytes with flag */
        public int ReadVarlen(List<byte> data, ref int offset) {
            uint result = 0;
            byte b = data[offset++];
            result = (uint)(b & 0x7f);

            for (int i = 0; i < 3; i++)
                if ((b & 0x80) != 0) {
                    b = data[offset++];
                    result = (uint)((result << 7) + (b & 0x7f));
                } else
                    break;

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
    }

}
