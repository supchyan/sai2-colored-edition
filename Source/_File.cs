using YumToolkit.Data;

namespace YumToolkit {
    public static class _File {
        static _FileName sai_FileName = new _FileName();
        static _ServiceMessages serviceMessages = new _ServiceMessages();
        public static void CreateDevFile() {
            if(!File.Exists(sai_FileName.classic)) {
                _Console.WriteLine(serviceMessages.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(sai_FileName.classic, sai_FileName.dev);
        }
        public static void DeleteDevFile() {
            if(File.Exists(sai_FileName.dev)) {
                File.Delete(sai_FileName.dev);
            }
        }

        public static void CreateOldFile() {
            if(!File.Exists(sai_FileName.classic)) {
                _Console.WriteLine(serviceMessages.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(sai_FileName.classic, sai_FileName.old);
        }
        public static void DeleteOldFile() {
            if(File.Exists(sai_FileName.old)) {
                File.Delete(sai_FileName.old);
            }
        }
        
    }
}