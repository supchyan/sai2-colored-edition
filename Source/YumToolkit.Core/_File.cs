using YumToolkit.Core.Data;
namespace YumToolkit.Core {
    public class _File {
        public static void ReplaceOriginalFile() {
            if(File.Exists(_Name.old)) { File.Copy(_Name.old, _Name.original); } 
        }
        public static void CreateTmpFile() {
            if(!File.Exists(_Name.original)) {
                _Console.SendMessage(_ServiceMessage.OriginalFileIsNotExist, ConsoleColor.DarkRed);
                return;
            } File.Copy(_Name.original, _Name.tmp);
        }
        public static void DeleteTmpFile() {
            if(File.Exists(_Name.tmp)) { File.Delete(_Name.tmp); }
        }
        public static void CreateOldFile() {
            if(!File.Exists(_Name.original)) {
                _Console.SendMessage(_ServiceMessage.OriginalFileIsNotExist, ConsoleColor.DarkRed);
                return;
            } File.Copy(_Name.original, _Name.old);
        }
        public static void DeleteOldFile() {
            if(File.Exists(_Name.old)) { File.Delete(_Name.old); }
        }
    }
}