using YumToolkit.Global;

namespace YumToolkit.Core {
    class _File : _Globals {
        public void ReplaceOriginalFile() {
            if(IsOldFileExists()) { File.Delete(name.original); File.Copy(name.old, name.original); } 
        }
        public void CreateTmpFile() {
            if(!IsOriginalFileExists()) { console.SendMessage(message.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }
            File.Copy(name.original, name.tmp);
        }
        public void DeleteTmpFile() {
            if(File.Exists(name.tmp)) { File.Delete(name.tmp); }
        }
        public void CreateOldFile() {
            if(!IsOriginalFileExists()) { console.SendMessage(message.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }
            File.Copy(name.original, name.old);
        }
        public void DeleteOldFile() {
            if(File.Exists(name.old)) { File.Delete(name.old); }
        }
        public bool IsOriginalFileExists(bool with_msg = false) {
            if(with_msg && !File.Exists(name.original)) console.SendMessage(message.OriginalFileIsNotExist, ConsoleColor.DarkRed);
            return File.Exists(name.original);
        }
        public bool IsOldFileExists(bool with_msg = false) {
            if(with_msg && !File.Exists(name.old)) console.SendMessage(message.OldFileIsNotExist, ConsoleColor.DarkRed);
            return File.Exists(name.old);
        
        }

        // TODO: Works bad, can't handle it normally lol. I just've no idea, how to say is file is busy actually.
        public bool IsFileBusy(bool with_msg = false) {
            try {
                if(!IsOriginalFileExists()) { return false; }
                File.WriteAllBytes(name.original, File.ReadAllBytes(name.original));
                return false;
            } catch { 
                if(with_msg) console.SendMessage(message.OriginalFileIsBusy, ConsoleColor.DarkRed);
                return true;
            }
            
        }
        public _File() { }
    }
}