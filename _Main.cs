using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace drak_mode_sai2 {
    class _Main {
        static string? old_sai = "sai2.old";
        static string? sai = "sai2.exe";
        static string? tmp;
        static bool exit_proc = true;
        static void Main(string[] args) {

            if(old_sai is null || sai is null) return;
            if(!OperatingSystem.IsWindows()) {
                Console.WriteLine($"This application can't be run on {Environment.OSVersion}, I'm sorry");
                return;
            }

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Title = "Do you like a whales?!";
            
            Console.CursorVisible = false;
            Console.SetWindowSize(_Console.Size[0],_Console.Size[1]);
            Console.SetBufferSize(_Console.Size[0],_Console.Size[1]);

            CONSOLE_DRAW_HEADER();

            CONSOLE_SELECT_START();

            while(true) {
                var current_key = Console.ReadKey().Key;
                if(current_key is ConsoleKey.DownArrow) CONSOLE_SELECT_EXIT();
                if(current_key is ConsoleKey.UpArrow) CONSOLE_SELECT_START();
                if(current_key is ConsoleKey.Enter) {
                    if(!exit_proc) {
                        CONSOLE_DRAW_INFO();
                        break;
                    } else Environment.Exit(0);
                }
            }
            // return;

            List<_Replacer> val = [
                // new _Replacer("f8f8f8", "424242"),
                // new _Replacer("ffffff", "424242"),
                // new _Replacer("c5c5c5", "212121"),
                // new _Replacer("000000", "E0E0E0")
            ];
            
            // _HexEditor.EditHEX(old_sai, sai, val);
            Process sai_proc = Process.Start("sai2.exe");
            if (sai_proc != null) {
                sai_proc.EnableRaisingEvents = true;
                sai_proc.Exited += SAI_EXITED;
            }
            Process.GetCurrentProcess().WaitForExit();
        }

        static void SAI_EXITED(object? sender, EventArgs e) { 
            Environment.Exit(0);
        }
        static void CONSOLE_DRAW_HEADER() {
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
        static void CONSOLE_SELECT_START() { 
            if(!exit_proc) return;

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

            exit_proc = false;
        }
        static void CONSOLE_SELECT_EXIT() { 
            if(exit_proc) return;

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

            exit_proc = true;
        }
        static void CONSOLE_DRAW_INFO() {
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
        static void TEST(string msg) {
            Console.SetCursorPosition( 0, 0);
            Console.Write(msg);
        }
    }
}