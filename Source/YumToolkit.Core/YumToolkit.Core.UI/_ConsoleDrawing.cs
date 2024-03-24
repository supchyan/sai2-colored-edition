using System.Numerics;
using YumToolkit.Core.Data;

namespace YumToolkit.Core.UI {
    class _ConsoleDrawing {
        public static _ConsoleDrawing Get { get; private set; }
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

            _Console.Get.WriteLine("");
            _Console.Get.WriteLine("  ╭─────────────────────────────────╮"); // 1
            _Console.Get.WriteLine("  │ Yum2Tools                       │"); // 2
            _Console.Get.WriteLine("  ╰─────────────────────────────────╯"); // 3
            _Console.Get.WriteLine("  ╭─────────────────────────────────╮"); // 4
            _Console.Get.WriteLine("  │ Select one in list below:       │"); // 5
            _Console.Get.WriteLine("  ├─────────────────────────────────┤"); // 6
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

            _Console.Get.WriteLine($"  │ ○ {line                     }   │"); // 7
            }
            _Console.Get.WriteLine("  │ ○ Restore to default theme      │"); // 8
            _Console.Get.WriteLine("  │ ○ Visit project's GitHub page   │"); // 9
            _Console.Get.WriteLine("  │ ○ Exit Yum2Tools                │"); // 10
            _Console.Get.WriteLine("  ╰─────────────────────────────────╯"); // 11
            _Console.Get.WriteLine("   [ ↑↓ ] and [ Enter ] to navigate. ", ConsoleColor.DarkGray); // 14

            Console.SetCursorPosition(4, 7);
            _Console.Get.Write("●");

            InterfaceHasBeenDrawn = true;

        }
        public void CONSOLE_MENU() {
            var input = Console.ReadKey();

            Console.SetCursorPosition(4, 7 + Choice); _Console.Get.Write("○");
            if(input.Key == ConsoleKey.UpArrow) { Choice = Choice > 0 ? Choice - 1 : MaxListValue; }
            if(input.Key == ConsoleKey.DownArrow) {  Choice = Choice < MaxListValue ? Choice + 1 : 0; }
            Console.SetCursorPosition(4, 7 + Choice); _Console.Get.Write("●");

            if(input.Key == ConsoleKey.Enter) {
                InterfaceHasBeenDrawn = false;
                isSelected = true;
                Console.Clear();
            }
        }
        void CONSOLE_ASCIIMATION() {
            while(true) {
                if(InterfaceHasBeenDrawn) {
                    foreach(string frame in _ConsoleAnimator.Get.Emote) {
                        _ConsoleAnimator.Get.SetFrame(frame, InterfaceHasBeenDrawn, new Vector2(29,2), 90);
                        if(!InterfaceHasBeenDrawn) { break; }
                    }
                }
            }
        }
        static _ConsoleDrawing() {
            Get = new _ConsoleDrawing();
            Get.ThemesList = Directory.GetFiles(_Path.Get.ThemesFolder).ToList();
            Get.MaxListValue = Get.ThemesList.Count + 2;
            Get.isSelected = false;
            Get.InterfaceHasBeenDrawn = false;
            Get.ASCIImation = new Thread(Get.CONSOLE_ASCIIMATION) { IsBackground = true };
            Get.ASCIImation.Start();
        }
    }
}