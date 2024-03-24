using YumToolkit.Core.Data;
namespace YumToolkit.Core.UI {
    class _Console {
        public static _Console Get { get; private set; }

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
            Get = new _Console();
            if(!Directory.Exists(_Path.Get.ThemesFolder)) { Get.SendMessage(_ServiceMessage.Get.ThemeFolderIsNotExist, ConsoleColor.DarkRed); Environment.Exit(0); }
            
        }
    }
}