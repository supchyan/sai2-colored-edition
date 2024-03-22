using System.Drawing;
using YumToolkit.Core;
using YumToolkit.Core.Data;

namespace YumToolkit {
    class App : AppHelper {
        static void Main(string[] args) {
            
            // Setting Default console props:
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Yum2Tools";
            Console.CursorVisible = false;

            if(!OperatingSystem.IsWindows()) {
                Console.WriteLine($"This program cannot be run on {Environment.OSVersion}... Or can't be :)");
                return;
            }

            if(!File.Exists(_Name.original)) {
                _Console.WriteLine(_ServiceMessage.OriginalFileIsNotExists, ConsoleColor.DarkRed);
                Console.ReadKey();
                return;
            }

            Begin:

                _Console.Drawing.CONSOLE_RESTART();

                // ui
                _Console.Drawing.CONSOLE_DRAW_MAIN();

                while(!_Console.isSelected) { _Console.Drawing.CONSOLE_MENU(); }

                // ai
                ShowTime();

            goto Begin;

        }
    }
}