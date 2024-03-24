using YumToolkit.Global;

namespace YumToolkit.Core {
    class _File : _Globals {
        public static _File Get { get; private set; }
        public void ReplaceOriginalFile() {
            if(File.Exists(name.old)) { File.Copy(name.old, name.original); } 
        }
        public void CreateTmpFile() {
            if(!File.Exists(name.original)) { console.SendMessage(serviceMessage.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }
            File.Copy(name.original, name.tmp);
        }
        public void DeleteTmpFile() {
            if(File.Exists(name.tmp)) { File.Delete(name.tmp); }
        }
        public void CreateOldFile() {
            if(!File.Exists(name.original)) { console.SendMessage(serviceMessage.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }
            File.Copy(name.original, name.old);
        }
        public void DeleteOldFile() {
            if(File.Exists(name.old)) { File.Delete(name.old); }
        }
        static _File() {
            Get = new _File();
        }
    }
}