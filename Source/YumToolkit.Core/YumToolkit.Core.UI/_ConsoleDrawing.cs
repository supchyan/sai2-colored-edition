using System.Numerics;
using YumToolkit.Core.Data;

namespace YumToolkit.Core.UI {
    public class _ConsoleDrawing {
        public static _ConsoleDrawing Call;
        int _Choice { get; set; }
        public int Choice => _Choice;
        
        bool _isSelected { get; set; }
        public bool isSelected => _isSelected;
        
        int _MaxListValue { get; set; }
        public int MaxListValue => _MaxListValue;

        List<string> _ThemesList { get; set; } = new List<string>();
        public List<string> ThemesList => _ThemesList;

        Thread? ASCIImation { get; set; }
        // Protects interface from `break lines` when drawing animation
        bool InterfaceHasBeenDrawn { get; set; }
        public void CONSOLE_RESTART() {
            InterfaceHasBeenDrawn = false;
            _isSelected = false;
            _Choice = 0;

            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
        public void CONSOLE_DRAW_MAIN() {

            // ● ○ // ╭─╮ ├ ┤ // │ │ // ╰─╯
            // 28 symbols for theme name is max value!

            _Console.Call.WriteLine("");
            _Console.Call.WriteLine("  ╭─────────────────────────────────╮"); // 1
            _Console.Call.WriteLine("  │ Yum2Tools                       │"); // 2
            _Console.Call.WriteLine("  ╰─────────────────────────────────╯"); // 3
            _Console.Call.WriteLine("  ╭─────────────────────────────────╮"); // 4
            _Console.Call.WriteLine("  │ Select one in list below:       │"); // 5
            _Console.Call.WriteLine("  ├─────────────────────────────────┤"); // 6
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

            _Console.Call.WriteLine($"  │ ○ {line                     }   │"); // 7
            }
            _Console.Call.WriteLine("  │ ○ Restore to default theme      │"); // 8
            _Console.Call.WriteLine("  │ ○ Visit project's GitHub page   │"); // 9
            _Console.Call.WriteLine("  │ ○ Exit Yum2Tools                │"); // 10
            _Console.Call.WriteLine("  ╰─────────────────────────────────╯"); // 11
            _Console.Call.WriteLine("   [ ↑↓ ] and [ Enter ] to navigate. ", ConsoleColor.DarkGray); // 14

            Console.SetCursorPosition(4, 7);
            _Console.Call.Write("●");

            InterfaceHasBeenDrawn = true;

        }
        public void CONSOLE_MENU() {
            var input = Console.ReadKey();

            Console.SetCursorPosition(4, 7 + _Choice); _Console.Call.Write("○");
            if(input.Key == ConsoleKey.UpArrow) {_Choice = _Choice > 0 ? _Choice - 1 : _MaxListValue; }
            if(input.Key == ConsoleKey.DownArrow) {  _Choice = _Choice < _MaxListValue ? _Choice + 1 : 0; }
            Console.SetCursorPosition(4, 7 + _Choice); _Console.Call.Write("●");

            if(input.Key == ConsoleKey.Enter) {
                InterfaceHasBeenDrawn = false;
                _isSelected = true;
                Console.Clear();
            }
        }
        void CONSOLE_ASCIIMATION() {
            while(true) {
                if(InterfaceHasBeenDrawn) {
                    foreach(string frame in _ConsoleAnimator.Call.Emote) {
                        _ConsoleAnimator.Call.SetFrame(frame, InterfaceHasBeenDrawn, new Vector2(29,2), 90);
                        if(!InterfaceHasBeenDrawn) { break; }
                    }
                }
            }
        }
        static _ConsoleDrawing() {
            Call = new _ConsoleDrawing();
            Call._ThemesList = Directory.GetFiles(_Path.Get.ThemesFolder).ToList();
            Call._MaxListValue = Call._ThemesList.Count + 2;
            Call._isSelected = false;
            Call.InterfaceHasBeenDrawn = false;
            Call.ASCIImation = new Thread(Call.CONSOLE_ASCIIMATION) { IsBackground = true };
            Call.ASCIImation.Start();
        }
    }
}