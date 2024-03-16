using YumToolkit.Data;

namespace YumToolkit {
    public class _File {
        public static _Name GetName = new _Name();
        static _ServiceMessages serviceMessages = new _ServiceMessages();
        public static void CreateDevFile() {
            if(!File.Exists(GetName.Classic)) {
                _Console.WriteLine(serviceMessages.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(GetName.Classic, GetName.Dev);
        }
        public static void DeleteDevFile() {
            if(File.Exists(GetName.Dev)) {
                File.Delete(GetName.Dev);
            }
        }

        public static void CreateOldFile() {
            if(!File.Exists(GetName.Classic)) {
                _Console.WriteLine(serviceMessages.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(GetName.Classic, GetName.Old);
        }
        public static void DeleteOldFile() {
            if(File.Exists(GetName.Old)) {
                File.Delete(GetName.Old);
            }
        }
        public class _Name {
            public string Classic { get; }
            public string Dev { get; }
            public string Old { get; }
            public _Name() {
                Classic = "sai2.exe";
                Dev = "sai2.dev.exe";
                Old = "sai2.old.exe";
            }
        }
    }
}