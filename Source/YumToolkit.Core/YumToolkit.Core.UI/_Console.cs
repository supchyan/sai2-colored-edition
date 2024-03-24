using YumToolkit.Core.Interfaces.UI;
using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _Console : _Globals, IConsole {

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
        public void CloseConsole() {
            Environment.Exit(0);
        }
        public _Console() {
            if(!Directory.Exists(path.ThemesFolder)) { SendMessage(serviceMessage.ThemeFolderIsNotExist, ConsoleColor.DarkRed); CloseConsole(); }
        }
    }
}