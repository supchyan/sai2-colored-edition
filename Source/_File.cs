using YumToolkit.Data;

namespace YumToolkit {
    public class _File {
        public static _Name Name = new _Name();
        static _ServiceMessages serviceMessages = new _ServiceMessages();
        public static void CreateDevFile() {
            if(!File.Exists(Name.classic)) {
                _Console.WriteLine(serviceMessages.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(Name.classic, Name.dev);
        }
        public static void DeleteDevFile() {
            if(File.Exists(Name.dev)) {
                File.Delete(Name.dev);
            }
        }

        public static void CreateOldFile() {
            if(!File.Exists(Name.classic)) {
                _Console.WriteLine(serviceMessages.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(Name.classic, Name.old);
        }
        public static void DeleteOldFile() {
            if(File.Exists(Name.old)) {
                File.Delete(Name.old);
            }
        }
        public class _Name {
            public string classic { get; }
            public string dev { get; }
            public string old { get; }
            public _Name() {
                classic = "sai2.exe";
                dev = "sai2.dev.exe";
                old = "sai2.old.exe";
            }
        }
    }
}