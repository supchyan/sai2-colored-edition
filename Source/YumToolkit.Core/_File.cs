using YumToolkit.Core.Data;
namespace YumToolkit.Core {
    public class _File {
        public static void CreateDevFile() {
            if(!File.Exists(_Name.GetFileName.Classic)) {
                _Console.WriteLine(_ServiceMessage.GetMessage.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(_Name.GetFileName.Classic, _Name.GetFileName.Dev);
        }
        public static void DeleteDevFile() {
            if(File.Exists(_Name.GetFileName.Dev)) {
                File.Delete(_Name.GetFileName.Dev);
            }
        }

        public static void CreateOldFile() {
            if(!File.Exists(_Name.GetFileName.Classic)) {
                _Console.WriteLine(_ServiceMessage.GetMessage.ClassicFileIsNotExists, ConsoleColor.DarkRed);
                return;
            } File.Copy(_Name.GetFileName.Classic, _Name.GetFileName.Old);
        }
        public static void DeleteOldFile() {
            if(File.Exists(_Name.GetFileName.Old)) {
                File.Delete(_Name.GetFileName.Old);
            }
        }
    }
}