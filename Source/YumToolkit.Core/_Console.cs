using System.Diagnostics;
using System.Numerics;

namespace YumToolkit.Core {
    public class _Console {
        public const string exit_message = "Press any key to exit...";
        public static readonly int[] Size = {44,12};
        public static void Write(string line, ConsoleColor ch_color = ConsoleColor.White, ConsoleColor bg_color = ConsoleColor.Black) {
            Console.ForegroundColor = ch_color;
            Console.BackgroundColor = bg_color;
            Console.Write(line); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void WriteLine(string line, ConsoleColor ch_color = ConsoleColor.White, ConsoleColor bg_color = ConsoleColor.Black) {
            Console.ForegroundColor = ch_color;
            Console.BackgroundColor = bg_color;
            Console.WriteLine(line); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public class Drawing {
            static bool EXIT_PROC { get; set; }
            public static bool exit_proc => EXIT_PROC;
            public static void CONSOLE_DRAW_MAIN() {
                Console.SetCursorPosition(
                    Size[0] / 2 - 9,
                    Size[1] / 2 - 3
                );

                Write($"Dark SAI2 Project");

                Console.SetCursorPosition(
                    Size[0] / 2 - 9,
                    Size[1] / 2 - 2
                );

                Write($"supchyan_", ConsoleColor.DarkYellow);

                Console.SetCursorPosition(
                    Size[0]/2-20,
                    0
                );

                Write($"use [ Arrows ] and [ Enter ] to navigate", ConsoleColor.DarkGray);

                CONSOLE_SELECT_EXIT();
                CONSOLE_SELECT_START();
            }
            public static void CONSOLE_SELECT_START() { 
                if(!EXIT_PROC) return;

                Console.SetCursorPosition(
                    Size[0] / 2 - 6,
                    Size[1] / 2 + 1
                );

                WriteLine($"> Run DaS2 <", ConsoleColor.DarkYellow);

                Console.SetCursorPosition(
                    Size[0] / 2 - 4,
                    Size[1] / 2 + 2
                );

                Write($"  Exit  ");

                EXIT_PROC = false;
            }
            public static void CONSOLE_SELECT_EXIT() { 
                if(EXIT_PROC) return;

                Console.SetCursorPosition(
                    Size[0] / 2 - 6,
                    Size[1] / 2 + 1
                );

                WriteLine($"  Run DaS2  ");

                Console.SetCursorPosition(
                    Size[0] / 2 - 4,
                    Size[1] / 2 + 2
                );

                Write($"> Exit <", ConsoleColor.DarkYellow);

                EXIT_PROC = true;
            }
            public static void CONSOLE_DRAW_WARNING() {
                Console.Clear();
                Console.SetCursorPosition(
                    Size[0] / 2 - 15,
                    Size[1] / 2 - 2
                );
                Write($"sai2.exe IS CURRENTLY RUNNING.", ConsoleColor.DarkYellow);
                Console.SetCursorPosition(
                    Size[0] / 2 - 15,
                    Size[1] / 2 - 1
                );
                Write($" DO NOT CLOSE THIS TERMINAL!", ConsoleColor.Yellow);
                Console.SetCursorPosition(
                    Size[0] / 2 - 16,
                    Size[1] / 2
                );
                Write($"IT WILL BE CLOSED AUTOMATICALLY,", ConsoleColor.DarkYellow);
                Console.SetCursorPosition(
                    Size[0] / 2 - 11,
                    Size[1] / 2 + 1
                );
                Write($"AFTER SAI2's EXITING.", ConsoleColor.DarkYellow);
            }
            public static void CONSOLE_DRAW_ERROR() {
                Console.Clear();
                Console.SetCursorPosition(
                    Size[0] / 2 - 3,
                    Size[1] / 2 - 2
                );
                Write($"ERROR:", ConsoleColor.DarkRed);
                Console.SetCursorPosition(
                    Size[0] / 2 - 13,
                    Size[1] / 2 - 1
                );
                Write($"sai2.exe HAS NOT DETECTED!", ConsoleColor.Red);
                Console.SetCursorPosition(
                    Size[0] / 2 - 15,
                    Size[1] / 2
                );
                Write($"MAKE SURE,  THIS EXECUTABLE IN", ConsoleColor.Red);
                Console.SetCursorPosition(
                    Size[0] / 2 - 15,
                    Size[1] / 2 + 1
                );
                Write($"THE SAME FOLDER WITH sai2.exe!", ConsoleColor.Red);
            }
            public static void CONSOLE_TEST(string msg) {
                Console.SetCursorPosition( 0, 0);
                Console.Write(msg);
            }
            public Drawing() {
                EXIT_PROC = true;
            }
        }
    }
}