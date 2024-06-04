namespace YumToolkit.Core.Data {
    class _Name {
        string sai2 { get; }
        string exe { get; }
        public string original { get; }
        public string tmp { get; }
        public string old { get; }
        public _Name() {
            sai2 = "sai2";
            exe = ".exe";
            
            original = $"{sai2}{exe}";
            tmp = $"{sai2}.tmp{exe}";
            old = $"{sai2}.old{exe}";
        }
    }
}