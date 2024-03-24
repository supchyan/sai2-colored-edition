using YumToolkit.Core.Interfaces;

namespace YumToolkit.Core.Data {
    class _Name : IName {
        public string original { get; }
        public string tmp { get; }
        public string old { get; }
        public _Name() {
            original = "sai2.exe";
            tmp = "sai2.tmp.exe";
            old = "sai2.old.exe";
            
        }
    }
}