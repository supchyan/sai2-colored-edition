namespace YumToolkit.Core {
    public class _Console {
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
        public class Drawing {
            // TODO:
            // instead of bool exit_proc, add nums array for different ui states.
            // menu should contains:
            // Yum2Tools GUI
            // ---
            // Select one theme in the list below:
            // ● supchyan's Dark
            // ◌ Restore to default theme
            // ---
            // ◌ Exit Yum2Tools
            static bool EXIT_PROC { get; set; }
            public static bool exit_proc => EXIT_PROC;
            public static void CONSOLE_DRAW_MAIN() {
                // ● ○
                // ╭─╮ ├ ┤
                // │ │
                // ╰─╯
                // 28 symbols for theme name is max value.
                WriteLine("");
                WriteLine("   ╭────────────────────────────────╮");
                WriteLine("   │ Yum2Tools                      │");
                WriteLine("   ╰────────────────────────────────╯");
                WriteLine("   ╭────────────────────────────────╮");
                WriteLine("   │ Themes:                        │");
                WriteLine("   ├────────────────────────────────┤");
                WriteLine("   │ ● supchyan's Dark              │");
                WriteLine("   │ ○ Restore to default theme     │");
                WriteLine("   ╰────────────────────────────────╯");
                WriteLine("   ╭────────────────────────────────╮");
                WriteLine("   │ ○ Visit project's GitHub page  │");
                WriteLine("   │ ○ Exit Yum2Tools               │");
                WriteLine("   ╰────────────────────────────────╯");
                WriteLine("    [ ↑↓ ] and [ Enter ] to navigate ", ConsoleColor.DarkGray);

            }
            public Drawing() { EXIT_PROC = true; }

        }
    }
}