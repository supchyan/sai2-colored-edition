namespace YumToolkit.Core {
    public class _File : _YumTools {
        public static void CreateDevFile() {
            if(!File.Exists(GetFileName.Classic)) {
                _Console.WriteLine(ServiceMessage.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(GetFileName.Classic, GetFileName.Dev);
        }
        public static void DeleteDevFile() {
            if(File.Exists(GetFileName.Dev)) {
                File.Delete(GetFileName.Dev);
            }
        }

        public static void CreateOldFile() {
            if(!File.Exists(GetFileName.Classic)) {
                _Console.WriteLine(ServiceMessage.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(GetFileName.Classic, GetFileName.Old);
        }
        public static void DeleteOldFile() {
            if(File.Exists(GetFileName.Old)) {
                File.Delete(GetFileName.Old);
            }
        }
    }
}