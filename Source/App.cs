using System.Diagnostics;
using System.Drawing;
using System.Text;
using YumToolkit.Data;

namespace YumToolkit {
    class App : _YumTools {
        static void Main(string[] args) {
            if(!OperatingSystem.IsWindows()) {
                Console.WriteLine($"This program cannot be run on {Environment.OSVersion}.");
                return;
            }

            SetElementColor(GetColor.Secondary, GetAddress.TopBar);

            // console preparations
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Do you like a whales?!";
            Console.CursorVisible = false;
            Console.SetWindowSize(_Console.Size[0],_Console.Size[1]);
            Console.SetBufferSize(_Console.Size[0],_Console.Size[1]);

            // ui
            _Interface.CONSOLE_DRAW_MAIN();
            _Interface.CONSOLE_SELECT_START();
            while(true) {
                var current_key = Console.ReadKey().Key;
                if(current_key is ConsoleKey.DownArrow) _Interface.CONSOLE_SELECT_EXIT();
                if(current_key is ConsoleKey.UpArrow) _Interface.CONSOLE_SELECT_START();
                if(current_key is ConsoleKey.Enter) {
                    if(!_Interface.EXIT_PROC) {
                        break;

                    } else Environment.Exit(0);
                }
            }
        }
    }
}