using System.Numerics;
using YumToolkit.Core.Interfaces.UI;
using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _ConsoleDrawing : _Globals, IConsoleDrawing {
        public int Choice { get; set; }
        public bool isSelected { get; set; }
        public int MaxListValue { get; }
        public List<string> ThemesList { get; }

        public Thread ASCIImation { get; }
        // Protects interface from `break lines` when drawing animation
        public bool InterfaceHasBeenDrawn { get; set; }

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

            console.WriteLine("");
            console.WriteLine("  ╭─────────────────────────────────╮"); // 1
            console.WriteLine("  │ Yum2Tools                       │"); // 2
            console.WriteLine("  ╰─────────────────────────────────╯"); // 3
            console.WriteLine("  ╭─────────────────────────────────╮"); // 4
            console.WriteLine("  │ Select one in list below:       │"); // 5
            console.WriteLine("  ├─────────────────────────────────┤"); // 6
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

            console.WriteLine($"  │ ○ {line                     }   │"); // 7
            }
            console.WriteLine("  │ ○ Restore to default theme      │"); // 8
            console.WriteLine("  │ ○ Visit project's GitHub page   │"); // 9
            console.WriteLine("  │ ○ Exit Yum2Tools                │"); // 10
            console.WriteLine("  ╰─────────────────────────────────╯"); // 11
            console.WriteLine("   [ ↑↓ ] and [ Enter ] to navigate. ", ConsoleColor.DarkGray); // 14

            Console.SetCursorPosition(4, 7);
            console.Write("●");

            InterfaceHasBeenDrawn = true;

        }
        public void CONSOLE_MENU() {
            var input = Console.ReadKey();

            Console.SetCursorPosition(4, 7 + Choice); console.Write("○");
            if(input.Key == ConsoleKey.UpArrow) { Choice = Choice > 0 ? Choice - 1 : MaxListValue; }
            if(input.Key == ConsoleKey.DownArrow) {  Choice = Choice < MaxListValue ? Choice + 1 : 0; }
            Console.SetCursorPosition(4, 7 + Choice); console.Write("●");

            if(input.Key == ConsoleKey.Enter) {
                InterfaceHasBeenDrawn = false;
                isSelected = true;
                Console.Clear();
            }
        }
        void CONSOLE_ASCIIMATION() {
            while(true) {
                if(InterfaceHasBeenDrawn) {
                    foreach(string frame in consoleAnimator.Emote) {
                        consoleAnimator.SetFrame(frame, InterfaceHasBeenDrawn, new Vector2(29,2), 90);
                        if(!InterfaceHasBeenDrawn) { break; }
                    }
                }
            }
        }
        public _ConsoleDrawing() {
            ThemesList = Directory.GetFiles(path.ThemesFolder).ToList();
            MaxListValue = ThemesList.Count + 2;
            isSelected = false;
            InterfaceHasBeenDrawn = false;
            ASCIImation = new Thread(CONSOLE_ASCIIMATION) { IsBackground = true };
            ASCIImation.Start();
        }
    }
}