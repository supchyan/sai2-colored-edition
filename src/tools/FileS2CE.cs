using System.IO;

namespace S2CE.Tools
{
    class FileS2CE {
        public void UpdateOriginalFile() {
            
            if(IsOldFileExists()) { File.Delete(PathS2CE.sai2); File.Copy(PathS2CE.oldSai2, PathS2CE.sai2); } 
        }
        public void CreateOldFile() {
            if(!IsOriginalFileExists()) { return; }
            File.Copy(PathS2CE.sai2, PathS2CE.oldSai2);
        }
        public void DeleteOldFile() {
            if(File.Exists(PathS2CE.oldSai2)) { File.Delete(PathS2CE.oldSai2); }
        }
        public bool IsOriginalFileExists(bool with_msg = false) {
            return File.Exists(PathS2CE.sai2);
        }
        public bool IsOldFileExists(bool with_msg = false) {
            return File.Exists(PathS2CE.oldSai2);
        
        }

        // TODO: Works bad, can't handle it normally lol. I just've no idea, how to say is file is busy actually.
        public bool IsFileBusy(bool with_msg = false) {
            try {
                if(!IsOriginalFileExists()) { return false; }
                File.WriteAllBytes(PathS2CE.sai2, File.ReadAllBytes(PathS2CE.sai2));
                return false;
            } catch { 
                return true;
            }
        }
    }
}