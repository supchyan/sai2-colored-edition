namespace drak_mode_sai2 {
    public static class _File {
        public static void DeleteOldFile(string old_sai, string sai) {
            
            if(File.Exists(old_sai)) {
                
                if(File.Exists(sai)) File.Delete(sai);

                File.Copy(old_sai, sai);
                File.Delete(old_sai);
           
            }
        }
    }
}