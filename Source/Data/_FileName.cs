namespace YumToolkit.Data {
    /// <summary>
    /// You can edit this class to add branch of a new colors,
    /// but make sure, it has 4 RGBA channels [ 0 - 255 ]
    /// Alpha channel [ A ] is for bytes separation, but highly necessary.
    /// Be sure to make it always equal to 0.
    /// </summary>
    public class _FileName {
        public string classic { get; }
        public string dev { get; }
        public string old { get; }
        public _FileName() {
            classic = "sai2.exe";
            dev = "sai2.dev.exe";
            old = "sai2.old.exe";
        }
    }
}