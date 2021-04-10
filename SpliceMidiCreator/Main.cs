using System;
using SpliceMaster;
using System.Collections.Generic;

public class MainClass {

	[STAThread]
	public static void Main(string[] argv) {
		// receive path of several midifile
		// "1安静.mid", "1彩虹.mid", "1稻香.mid", "1青花瓷.mid"
		// "2Lemon.mid", "2白金disco.mid", "2千本樱.mid", "2天之弱.mid"
		// "3judgelight.mid", "3打上花火.mid", "3青鸟.mid", "3月光传说.mid"
		// "4Mojito.mid", "4不能说的秘密.mid", "4晴天.mid", "4夜曲.mid"
		// "5龙卷风.mid", "5蒲公英的约定.mid", "5说了再见.mid", "5听妈妈的话.mid"
		//var test=new MidiFile("test.mid");
		string[] path = { "5龙卷风.mid", "5蒲公英的约定.mid", "5说了再见.mid", "5听妈妈的话.mid" };

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
