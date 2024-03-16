using YumToolkit.Data;

namespace YumToolkit {
    public static class _File {
        static _FileName fileName = new _FileName();
        static _ServiceMessages serviceMessages = new _ServiceMessages();
        public static void CreateDevFile() {
            if(!File.Exists(fileName.classic)) {
                _Console.WriteLine(serviceMessages.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(fileName.classic, fileName.dev);
        }
        public static void DeleteDevFile() {
            if(File.Exists(fileName.dev)) {
                File.Delete(fileName.dev);
            }
        }

        public static void CreateOldFile() {
            if(!File.Exists(fileName.classic)) {
                _Console.WriteLine(serviceMessages.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(fileName.classic, fileName.old);
        }
        public static void DeleteOldFile() {
            if(File.Exists(fileName.old)) {
                File.Delete(fileName.old);
            }
        }
        
    }
}