using YumToolkit.Core.Data;
namespace YumToolkit.Core.UI {
    public class _Console {
        public static _Console Call = new _Console();

        public void Write(string line, ConsoleColor  text_color = ConsoleColor.White, ConsoleColor bg_color = ConsoleColor.Black) {
            Console.ForegroundColor = text_color;
            Console.BackgroundColor = bg_color;
            Console.Write(line); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void WriteLine(string line, ConsoleColor text_color = ConsoleColor.White, ConsoleColor bg_color = ConsoleColor.Black) {
            Console.ForegroundColor = text_color;
            Console.BackgroundColor = bg_color;
            Console.WriteLine(line); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void SendMessage(string msg, ConsoleColor color) {
            Console.Clear();
            WriteLine(msg, color);
            Console.ReadKey();
        }
        static _Console() {
            
            if(!Directory.Exists(_Path.Get.ThemesFolder)) { Call.SendMessage(_ServiceMessage.Get.ThemeFolderIsNotExist, ConsoleColor.DarkRed); Environment.Exit(0); }
            
        }
    }
}