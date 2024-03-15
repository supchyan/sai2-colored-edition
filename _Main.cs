using System.Diagnostics;

namespace yum2_theme_toolkit {
    class _Main {
        static string? old_sai = "sai2.old.exe";
        static string? sai = "sai2.exe";
        static void Main(string[] args) {

            if(old_sai is null || sai is null) return;
            if(!OperatingSystem.IsWindows()) {
                Console.WriteLine($"This application can't be run on {Environment.OSVersion}, I'm sorry.");
                return;
            }

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

            // proc
            List<_Replacer> colors = [
                new _Replacer("E0E0E0", "424242"),
                new _Replacer("F8F8F8", "424242"),
                new _Replacer("C0C0C0", "424242"),

                new _Replacer("FF3050", "424242"),

                new _Replacer("90B0E8", "424242"),
                new _Replacer("204080", "424242")
            ];
            
            // _HexEditor.EditHEX(colors, 0, 1024);
            try {
                _Interface.CONSOLE_DRAW_WARNING();
                Process sai_proc = Process.Start("sai2.exe");

                if (sai_proc != null) {
                    sai_proc.EnableRaisingEvents = true;
                    sai_proc.Exited += _Exited;
                }
                Process.GetCurrentProcess().WaitForExit();
                
            } catch {
                _Interface.CONSOLE_DRAW_ERROR();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        static void _Exited(object? sender, EventArgs e) { 
            Environment.Exit(0);
        }
    }
}