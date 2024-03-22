using System.Numerics;
using YumToolkit.Core.Data;
namespace YumToolkit.Core {
    public class _Console {
        static int _Choice { get; set; }
        public static int Choice => _Choice;
        
        static bool _isSelected { get; set; }
        public static bool isSelected => _isSelected;
        
        static int _MaxListValue { get; set; }
        public static int MaxListValue => _MaxListValue;

        static List<string> _ThemesList { get; set; }
        public static List<string> ThemesList => _ThemesList;
        
        static Thread ASCIImation = new Thread(() => {});
        // Protects interface from `break lines` when drawing animation
        static bool InterfaceHasBeenDrawn { get; set; }

        public static void Write(string line, ConsoleColor  text_color = ConsoleColor.White, ConsoleColor bg_color = ConsoleColor.Black) {
            Console.ForegroundColor = text_color;
            Console.BackgroundColor = bg_color;
            Console.Write(line); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void WriteLine(string line, ConsoleColor text_color = ConsoleColor.White, ConsoleColor bg_color = ConsoleColor.Black) {
            Console.ForegroundColor = text_color;
            Console.BackgroundColor = bg_color;
            Console.WriteLine(line); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void SendMessage(string msg, ConsoleColor color) {
            Console.Clear();
            WriteLine(msg, color);
            Console.ReadKey();
        }
        public class Drawing {
            public static void CONSOLE_RESTART() {
                InterfaceHasBeenDrawn = false;
                _isSelected = false;
                _Choice = 0;

                Console.Clear();
                Console.SetCursorPosition(0, 0);
            }
            public static void CONSOLE_DRAW_MAIN() {

                // ● ○ // ╭─╮ ├ ┤ // │ │ // ╰─╯

                // 28 symbols for theme name is max value!

                WriteLine("");
                WriteLine("  ╭─────────────────────────────────╮"); // 1
                WriteLine("  │ Yum2Tools                       │"); // 2
                WriteLine("  ╰─────────────────────────────────╯"); // 3
                WriteLine("  ╭─────────────────────────────────╮"); // 4
                WriteLine("  │ Select one in list below:       │"); // 5
                WriteLine("  ├─────────────────────────────────┤"); // 6
                foreach(string theme in _ThemesList)
                {
                    var line = $"{Path.GetFileNameWithoutExtension(theme)}";
                    if(line.Length <= 27) {
                        // Fill free space with spaces [ space with spaces lol kek ]
                        while(line.Length < 27) {
                            line += ' ';
                        }

                    } else {
                        line = $"{line.Substring(0, 24)}...";
                    }

               WriteLine($"  │ ○ {line                     }   │"); // 7
                }
                WriteLine("  │ ○ Restore to default theme      │"); // 8
                WriteLine("  │ ○ Visit project's GitHub page   │"); // 9
                WriteLine("  │ ○ Exit Yum2Tools                │"); // 10
                WriteLine("  ╰─────────────────────────────────╯"); // 11
                WriteLine("   [ ↑↓ ] and [ Enter ] to navigate. ", ConsoleColor.DarkGray); // 14

                Console.SetCursorPosition(4, 7);
                Write("●");

                InterfaceHasBeenDrawn = true;

            }
            public static void CONSOLE_MENU() {
                var input = Console.ReadKey();

                Console.SetCursorPosition(4, 7 + _Choice); Write("○");
                if(input.Key == ConsoleKey.UpArrow) { _Choice = _Choice > 0 ? _Choice - 1 : _MaxListValue; }
                if(input.Key == ConsoleKey.DownArrow) {  _Choice = _Choice < _MaxListValue ? _Choice + 1 : 0; }
                Console.SetCursorPosition(4, 7 + _Choice); Write("●");

                if(input.Key == ConsoleKey.Enter) {
                    InterfaceHasBeenDrawn = false;
                    _isSelected = true;
                    Console.Clear();
                }
            }
            public static void CONSOLE_ASCIIMATION() {
                while(true) {
                    if(InterfaceHasBeenDrawn) {
                        foreach(string frame in Animator.Emote) {
                            Animator.SetFrame(frame, InterfaceHasBeenDrawn, new Vector2(29,2), 90);
                            if(!InterfaceHasBeenDrawn) { break; }
                        }
                    }
                }
            }
            static Drawing() {
                ASCIImation = new Thread(CONSOLE_ASCIIMATION);
                ASCIImation.IsBackground = true;
                ASCIImation.Start();
            }
        }
        class Animator {
            public static readonly string[] Stick = [ "\\","|","/","-" ];
            public static readonly string[] Emote = [ "<.<  ","<.<  ","-.-  "," -.- ","  -.-","  >.>","  >.>","  -.-"," -.- ","-.-  " ];
            public static void SetFrame(string frame, bool safe_drawing, Vector2 sprite_pos, int delay) {
                if(safe_drawing) {
                    Console.SetCursorPosition((int)sprite_pos.X, (int)sprite_pos.Y);
                    Write(frame);
                    Thread.Sleep(delay);
                }
            }
        }
        static _Console() {
            if(!Directory.Exists(_Path.ThemesFolder)) { SendMessage(_ServiceMessage.ThemeFolderIsNotExist, ConsoleColor.DarkRed); Environment.Exit(0); }

            _ThemesList = Directory.GetFiles(_Path.ThemesFolder).ToList();
            _MaxListValue = _ThemesList.Count + 2;
            _isSelected = false;
            InterfaceHasBeenDrawn = false;
        }
    }
}