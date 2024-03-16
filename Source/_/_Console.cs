using System.Diagnostics;
using System.Numerics;

namespace YumToolkit {
    public static class _Console {
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
    }
}