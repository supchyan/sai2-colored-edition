using YumToolkit.Core.Data;
using YumToolkit.Core.UI;
namespace YumToolkit.Core {
    public class _File {
        public static _File Call;
        public void ReplaceOriginalFile() {
            if(File.Exists(_Name.Get.old)) { File.Copy(_Name.Get.old, _Name.Get.original); } 
        }
        public void CreateTmpFile() {
            if(!File.Exists(_Name.Get.original)) { _Console.Call.SendMessage(_ServiceMessage.Get.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }
            File.Copy(_Name.Get.original, _Name.Get.tmp);
        }
        public void DeleteTmpFile() {
            if(File.Exists(_Name.Get.tmp)) { File.Delete(_Name.Get.tmp); }
        }
        public void CreateOldFile() {
            if(!File.Exists(_Name.Get.original)) { _Console.Call.SendMessage(_ServiceMessage.Get.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }
            File.Copy(_Name.Get.original, _Name.Get.old);
        }
        public void DeleteOldFile() {
            if(File.Exists(_Name.Get.old)) { File.Delete(_Name.Get.old); }
        }
        static _File() {
            Call = new _File();
        }
    }
}