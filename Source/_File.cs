using YumToolkit.Data;

namespace YumToolkit {
    public class _File {
        public static _Name GetName = new _Name();
        static _ServiceMessages serviceMessages = new _ServiceMessages();
        public static void CreateDevFile() {
            if(!File.Exists(GetName.classic)) {
                _Console.WriteLine(serviceMessages.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(GetName.classic, GetName.dev);
        }
        public static void DeleteDevFile() {
            if(File.Exists(GetName.dev)) {
                File.Delete(GetName.dev);
            }
        }

        public static void CreateOldFile() {
            if(!File.Exists(GetName.classic)) {
                _Console.WriteLine(serviceMessages.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(GetName.classic, GetName.old);
        }
        public static void DeleteOldFile() {
            if(File.Exists(GetName.old)) {
                File.Delete(GetName.old);
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