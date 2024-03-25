using YumToolkit.Global;

namespace YumToolkit.Core {
    class _File : _Globals {
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
        public bool IsOriginalFileExists() {
            if(!File.Exists(name.original)) {
                console.SendMessage(serviceMessage.OriginalFileIsNotExist,ConsoleColor.DarkRed);
            }
            return File.Exists(name.original);
        }
        public bool IsOldFileExists() {
            if(!File.Exists(name.old)) { 
                console.SendMessage(serviceMessage.OldFileIsNotExist, ConsoleColor.DarkRed); 
            }
            return File.Exists(name.old);
        }
        public bool IsFileBusy() {
            try { 
                File.ReadAllBytes(name.original);
                return false;
            
            } catch {
                console.SendMessage(serviceMessage.OriginalFileIsBusy, ConsoleColor.DarkRed);
                return true;
            }
            
        }
        public _File() { }
    }
}