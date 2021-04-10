namespace SpliceMaster {

    /** @class MidiFileException
     * A MidiFileException is thrown when an error occurs
     * while parsing the Midi File.  The constructor takes
     * the file offset (in bytes) where the error occurred,
     * and a string describing the error.
     */
    public class MidiFileException : System.Exception {
        public MidiFileException(string s, int offset) :
            base(s + " at offset " + offset) {
        }
    }
}