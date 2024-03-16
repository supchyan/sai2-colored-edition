namespace YumToolkit._ {
    public static class _Interface {
        public static bool EXIT_PROC = true;
        public static void CONSOLE_DRAW_MAIN() {
            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 9,
                _Console.Size[1] / 2 - 3
            );

            _Console.Write($"Dark SAI2 Project");

            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 9,
                _Console.Size[1] / 2 - 2
            );

            _Console.Write($"supchyan_", ConsoleColor.DarkYellow);

            Console.SetCursorPosition(
                _Console.Size[0]/2-20,
                0
            );

            _Console.Write($"use [ Arrows ] and [ Enter ] to navigate", ConsoleColor.DarkGray);
        }
        public static void CONSOLE_SELECT_START() { 
            if(!EXIT_PROC) return;

            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 6,
                _Console.Size[1] / 2 + 1
            );

            _Console.WriteLine($"> Run DaS2 <", ConsoleColor.DarkYellow);

            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 4,
                _Console.Size[1] / 2 + 2
            );

            _Console.Write($"  Exit  ");

            EXIT_PROC = false;
        }
        public static void CONSOLE_SELECT_EXIT() { 
            if(EXIT_PROC) return;

            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 6,
                _Console.Size[1] / 2 + 1
            );

            _Console.WriteLine($"  Run DaS2  ");

            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 4,
                _Console.Size[1] / 2 + 2
            );

            _Console.Write($"> Exit <", ConsoleColor.DarkYellow);

            EXIT_PROC = true;
        }
        public static void CONSOLE_DRAW_WARNING() {
            Console.Clear();
            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 15,
                _Console.Size[1] / 2 - 2
            );
            _Console.Write($"sai2.exe IS CURRENTLY RUNNING.", ConsoleColor.DarkYellow);
            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 15,
                _Console.Size[1] / 2 - 1
            );
            _Console.Write($" DO NOT CLOSE THIS TERMINAL!", ConsoleColor.Yellow);
            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 16,
                _Console.Size[1] / 2
            );
            _Console.Write($"IT WILL BE CLOSED AUTOMATICALLY,", ConsoleColor.DarkYellow);
            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 11,
                _Console.Size[1] / 2 + 1
            );
            _Console.Write($"AFTER SAI2's EXITING.", ConsoleColor.DarkYellow);
        }
        public static void CONSOLE_DRAW_ERROR() {
            Console.Clear();
            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 3,
                _Console.Size[1] / 2 - 2
            );
            _Console.Write($"ERROR:", ConsoleColor.DarkRed);
            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 13,
                _Console.Size[1] / 2 - 1
            );
            _Console.Write($"sai2.exe HAS NOT DETECTED!", ConsoleColor.Red);
            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 15,
                _Console.Size[1] / 2
            );
            _Console.Write($"MAKE SURE,  THIS EXECUTABLE IN", ConsoleColor.Red);
            Console.SetCursorPosition(
                _Console.Size[0] / 2 - 15,
                _Console.Size[1] / 2 + 1
            );
            _Console.Write($"THE SAME FOLDER WITH sai2.exe!", ConsoleColor.Red);
        }
        public static void CONSOLE_TEST(string msg) {
            Console.SetCursorPosition( 0, 0);
            Console.Write(msg);
        }
    }
}