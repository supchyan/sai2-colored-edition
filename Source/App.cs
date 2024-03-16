using YumToolkit.Core;
using YumToolkit.Core.Data;

namespace YumToolkit {
    class App : _YumTools {
        static void Main(string[] args) {
            if(!OperatingSystem.IsWindows()) {
                Console.WriteLine($"This program cannot be run on {Environment.OSVersion}.");
                return;
            }

            // SetElementColor(GetColor.Secondary, GetAddress.TopBar);

            // console preparations
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Console";
            Console.CursorVisible = false;
            Console.SetWindowSize(_Console.Size[0], _Console.Size[1]);
            Console.SetBufferSize(_Console.Size[0], _Console.Size[1]);

            // ui
            _Console.Drawing.CONSOLE_DRAW_MAIN();

            // while(true) {
            //     var current_key = Console.ReadKey().Key;
            //     if(current_key is ConsoleKey.DownArrow) _Console.Drawing.CONSOLE_SELECT_EXIT();
            //     if(current_key is ConsoleKey.UpArrow) _Console.Drawing.CONSOLE_SELECT_START();
            //     if(current_key is ConsoleKey.Enter) {
            //         if(!_Console.Drawing.exit_proc) {
            //             break;

            //         } else Environment.Exit(0);
            //     }
            // }

            Console.ReadKey();
        }
    }
}