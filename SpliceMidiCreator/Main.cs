using System;
using SpliceMaster;
using System.Collections.Generic;

public class MainClass {

	[STAThread]
	public static void Main(string[] argv) {
		// receive path of several midifile
		// "1����.mid", "1�ʺ�.mid", "1����.mid", "1�໨��.mid"
		// "2Lemon.mid", "2�׽�disco.mid", "2ǧ��ӣ.mid", "2��֮��.mid"
		// "3judgelight.mid", "3���ϻ���.mid", "3����.mid", "3�¹⴫˵.mid"
		// "4Mojito.mid", "4����˵������.mid", "4����.mid", "4ҹ��.mid"
		// "5�����.mid", "5�ѹ�Ӣ��Լ��.mid", "5˵���ټ�.mid", "5������Ļ�.mid"
		//var test=new MidiFile("test.mid");
		string[] path = { "5�����.mid", "5�ѹ�Ӣ��Լ��.mid", "5˵���ټ�.mid", "5������Ļ�.mid" };

		// create the list of midifile
		var mf = new List<MidiFile>();
		for (int i = 0; i < path.Length; i++)
			mf.Add(new MidiFile(path[i]));

		// find the cut position of every midifile
		var sa = new SpliceAlgorithm(mf);

		// transfer the cut position to midisplice
		List<TrackCut>[] cutpos = new List<TrackCut>[mf.Count];
		for (int i = 0; i < cutpos.Length; i++) {
			cutpos[i] = new List<TrackCut>();
			for (int j = 0; j < mf[i].Tracks.Count; j++)
				// cutpos[i].Add(new TrackCut(j, 0, 0));
				cutpos[i].Add(new TrackCut(j, mf[i].CutPos[0], mf[i].CutPos[1]));
		}

		// cut the midifile according to the cutpos
		//MidiSplice ms = new MidiSplice(mf, cutpos,sp);
		//ms.Write("test", ms.Splice());
		NewSplice ms = new NewSplice(mf, cutpos);
		ms.Splice();
		ms.WriteToFile("test");
	}
}
