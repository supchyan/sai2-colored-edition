namespace drak_mode_sai2 {
    public static class _File {
        public static string FixName(string name) {
            if(!name.Contains(".exe"))
            { name += ".exe"; }
            
            return name;
        }
        public static void ClearBackup(string old_sai, string sai) {

            string old = FixName(old_sai);
            
            if(File.Exists(old)) {
                
                if(File.Exists(sai)) File.Delete(sai);

                File.Copy(old, sai);
                File.Delete(old);
           
            }
        }
    }
}