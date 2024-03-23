using System.Numerics;
using YumToolkit.Core.Data;

namespace YumToolkit.Core.UI {
    public class _ConsoleDrawing {
        public static _ConsoleDrawing Call;
        public int Choice { get; private set; }
        public bool isSelected { get; private set; }
        public int MaxListValue { get; private set; }
        public List<string> ThemesList { get; private set; } = new List<string>();

        Thread? ASCIImation { get; set; }
        // Protects interface from `break lines` when drawing animation
        bool InterfaceHasBeenDrawn { get; set; }

        public void CONSOLE_RESTART() {
            InterfaceHasBeenDrawn = false;
            isSelected = false;
            Choice = 0;

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
            foreach(string theme in ThemesList)
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

            Console.SetCursorPosition(4, 7 + Choice); _Console.Call.Write("○");
            if(input.Key == ConsoleKey.UpArrow) { Choice = Choice > 0 ? Choice - 1 : MaxListValue; }
            if(input.Key == ConsoleKey.DownArrow) {  Choice = Choice < MaxListValue ? Choice + 1 : 0; }
            Console.SetCursorPosition(4, 7 + Choice); _Console.Call.Write("●");

            if(input.Key == ConsoleKey.Enter) {
                InterfaceHasBeenDrawn = false;
                isSelected = true;
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
            Call.ThemesList = Directory.GetFiles(_Path.Get.ThemesFolder).ToList();
            Call.MaxListValue = Call.ThemesList.Count + 2;
            Call.isSelected = false;
            Call.InterfaceHasBeenDrawn = false;
            Call.ASCIImation = new Thread(Call.CONSOLE_ASCIIMATION) { IsBackground = true };
            Call.ASCIImation.Start();
        }
    }
}