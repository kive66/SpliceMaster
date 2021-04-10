using System;
using System.Collections.Generic;


namespace SpliceMaster {
    /** @class SpliceAlgorithm
     * This class recieve several MidiFile.
     * Then, by using one or more splice algorithm,
     * this class find the cutting number of the bar and stored it.
     */
    public class SpliceAlgorithm {
        private readonly List<MidiFile> mf;  /** to store the midifile going to be splice */

        public SpliceAlgorithm(List<MidiFile> mf) {
            this.mf = mf;
            ScanMidiFile();
        }

        private void ScanMidiFile() {
            for (int i = 0; i < mf.Count; i++) {  // all midifile
                var sameBar = new List<List<int>>();
                for (int j = 0; j < mf[i].Tracks[0].Midibar.Count; j++) {  // all bar
                    // find if the bar has already been added in the List sameBar
                    bool haveAdd = false;
                    foreach (var barList in sameBar)
                        if (barList.Contains(j)) {
                            haveAdd = true;
                            break;
                        }
                    if (haveAdd)
                        continue;
                    sameBar.Add(new List<int> { j });
                    var firstBar = ReserveHighNote(j, i);
                    for (int k = j + 1; k < mf[i].Tracks[0].Midibar.Count; k++) {
                        var secondBar = ReserveHighNote(k, i);
                        int pitch = 0, rhythm = 0, prop = 60, ticksDiff = secondBar.Starttick - firstBar.Starttick;
                        for (int a = 0, b = 0; a < firstBar.Notes.Count && b < secondBar.Notes.Count;) {
                            if (firstBar.Notes[a].StartTime < secondBar.Notes[b].StartTime - ticksDiff)
                                a++;
                            else if (firstBar.Notes[a].StartTime > secondBar.Notes[b].StartTime - ticksDiff)
                                b++;
                            else {
                                if (firstBar.Notes[a].Number == secondBar.Notes[b].Number)
                                    pitch++;
                                if (firstBar.Notes[a].Duration == secondBar.Notes[b].Duration)
                                    rhythm++;
                                a++;
                                b++;
                            }
                        }
                        // to prevent the huge differents of the number of the notes in two bars
                        if (Math.Abs((double)(firstBar.Notes.Count) / secondBar.Notes.Count - 1) > 0.5)
                            continue;
                        int temp = Math.Min(firstBar.Notes.Count, secondBar.Notes.Count);
                        //  || rhythm * 100 / temp > prop
                        if (temp != 0 && (pitch * 100 / temp >= prop && rhythm * 100 / temp >= prop))
                            sameBar[sameBar.Count - 1].Add(k);
                    }
                }
                // skip the intro part if this midi have(4 bars or 8 bars)
                int introEndBar = 0, introEndIndex;
                for (introEndIndex = 0; introEndIndex < sameBar.Count; introEndIndex++) {
                    /*
                    if (introEndBar > 0 && introEndBar < 4)
                        introEndBar = 3;
                    else if (introEndBar >= 4 && introEndBar < 8)
                        introEndBar = 7;
                    */
                    if (sameBar[introEndIndex].Count == 1) {
                        introEndBar = introEndBar > sameBar[introEndIndex][0] ? introEndBar : sameBar[introEndIndex][0];
                    } else if (sameBar[introEndIndex][0] < introEndBar) {
                        for (int j = 0; j < sameBar[introEndIndex].Count && sameBar[introEndIndex][j] < 8; j++)
                            introEndBar = introEndBar > sameBar[introEndIndex][j] ? introEndBar : sameBar[introEndIndex][j];
                    } else if (sameBar[introEndIndex][sameBar[introEndIndex].Count - 1] >= 8) {
                        break;
                    } else if (sameBar[introEndIndex][sameBar[introEndIndex].Count - 1] < 8) {
                        introEndBar = sameBar[introEndIndex][sameBar[introEndIndex].Count - 1];
                    }
                }
                // store three part at most
                int partEndBar = introEndBar;
                for (int j = introEndIndex; j < sameBar.Count && mf[i].PartNum.Count < 3; j++) {
                    if (sameBar[j][0] < partEndBar || sameBar[j].Count == 1) {
                        continue;
                    }
                    var partBar = new List<int> { sameBar[j][0], sameBar[j][0] + 8 };
                    for (int k = 1; k < sameBar[j].Count; k++) {
                        if (sameBar[j][k] < partBar[1])
                            continue;
                        else if (sameBar[j][k] <= partBar[1] + 8) {
                            partBar[1] += 8;
                            if (partBar[1] - partBar[0] == 16)
                                break;
                        } else
                            break;

                    }
                    partEndBar = partBar[1];
                    mf[i].PartNum.Add(partBar);
                }
                // exception handling
                if (mf[i].PartNum.Count == 0) {
                    Console.WriteLine("can find even one part int midifile {0}", i);
                    Environment.Exit(0);
                }
            }
            // store the cutting position(select part alternately)
            int lastPart = -1;
            for (int i = 0; i < mf.Count; i++) {
                if (lastPart + 1 < mf[i].PartNum.Count)
                    lastPart++;
                else
                    lastPart = 0;
                mf[i].CutPos[0] = mf[i].PartNum[lastPart][0];
                mf[i].CutPos[1] = mf[i].PartNum[lastPart][1];
                if (mf[i].CutPos[1] - mf[i].CutPos[0] < 16 && mf[i].PartNum.Count > lastPart + 1
                    && mf[i].PartNum[lastPart + 1][0] == mf[i].PartNum[lastPart][1])
                    mf[i].CutPos[1] = mf[i].PartNum[++lastPart][1];
            }
        }

        /** only reserve the highest pitch note in the same time
         * barNum is the start bar number, mfNum is the midifile number
         */
        public MidiBar ReserveHighNote(int barNum, int mfNum) {
            var bar = mf[mfNum].Tracks[0].Midibar[barNum];
            bar.Notes.Sort();
            for (int i = 0; i < bar.Notes.Count - 1; i++) {  // reserve high note
                while (i + 1 < bar.Notes.Count && bar.Notes[i].StartTime == bar.Notes[i + 1].StartTime)
                    bar.Notes.RemoveAt(i + 1);
            }
            return bar;
        }

    }
}