using YumToolkit.Global;

namespace YumToolkit.Core {
    class _File : _Globals {
        public void ReplaceOriginalFile() {
            if(File.Exists(name.old)) { File.Copy(name.old, name.original); } 
        }
        public void CreateTmpFile() {
            if(!File.Exists(name.original)) { console.SendMessage(message.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }
            File.Copy(name.original, name.tmp);
        }
        public void DeleteTmpFile() {
            if(File.Exists(name.tmp)) { File.Delete(name.tmp); }
        }
        public void CreateOldFile() {
            if(!File.Exists(name.original)) { console.SendMessage(message.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }
            File.Copy(name.original, name.old);
        }
        public void DeleteOldFile() {
            if(File.Exists(name.old)) { File.Delete(name.old); }
        }
        public bool IsOriginalFileExists() {
            if(!File.Exists(name.original)) {
                console.SendMessage(message.OriginalFileIsNotExist,ConsoleColor.DarkRed);
            }
            return File.Exists(name.original);
        }
        public bool IsOldFileExists() {
            if(!File.Exists(name.old)) { 
                console.SendMessage(message.OldFileIsNotExist, ConsoleColor.DarkRed); 
            }
            return File.Exists(name.old);
        }
        // TODO: Works bad, can't handle it normally lol. I just've no idea, how to say is file is busy actually.
        public bool IsFileBusy() {
            try { 
                File.WriteAllBytes(name.original, File.ReadAllBytes(name.original));
                return false;
            
            } catch {
                console.SendMessage(message.OriginalFileIsBusy, ConsoleColor.DarkRed);
                return true;
            }
            
        }
        public _File() { }
    }
}