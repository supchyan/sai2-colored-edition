namespace YumToolkit.Core.Data {
    public class _Name {
        public static _Name Get;
        public string original { get; private set; } = string.Empty;
        public string tmp { get; private set; } = string.Empty;
        public string old { get; private set; } = string.Empty;
        static _Name() {
            Get = new _Name {
                original = "sai2.exe",
                tmp = "sai2.tmp.exe",
                old = "sai2.old.exe",
            };
            
        }
    }
}