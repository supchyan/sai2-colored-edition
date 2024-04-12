using System.Data;
using System.Runtime.InteropServices;
using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _ConsoleDrawing : _Globals { // , IConsoleDrawing
        static bool _Looping { get; set; } = true;
        public bool Looping => _Looping;

        static int _Selection { get; set; }
        public int Selection => _Selection;

        static int _MenuSize { get; set; }
        public int MenuSize => _MenuSize;

        static string[] Dots { get; set; } = ["⠋","⠙","⠸","⠴","⠦","⠇"];
        static int _DotsPosition { get; set; } = 0;

        static string Separator { get; set; } = "-";
        static string Selector { get; set; } = "** ";
        static string EmptySelector { get; set; } = "* ";

        static List<string> oldThemesList { get; set; } = new List<string>();
        static List<string> ThemesList { get; set; } = new List<string>();
        public List<string> pubThemesList => ThemesList;

        static List<string> _MenuContent { get; } = new List<string>();
        public List<string> MenuContent => _MenuContent;

        const int MenuCap = 10;
        static bool MenuCapIsReached { get; set; }

        static bool UpdateUI { get; set; }

        #region events
        static event Action<ConsoleKey> ChangeState = key => {
            if(key is ConsoleKey.DownArrow) DownArrowPressed();
            if(key is ConsoleKey.UpArrow) UpArrowPressed();
            if(key is ConsoleKey.Enter) EnterPressed();
            UpdateContentMenu();
        };
        event Action<bool> DrawUI = condition => {
            if(!condition) { return; }
            Console.Clear();
            DrawTitle(); DrawContent(); DrawTips();
            UpdateUI = false;
        };
        #endregion

        #region input logic
        static void EnterPressed() {
            _Looping = false;
        }
        static void UpArrowPressed() {
            _Selection--;
            _DotsPosition--;
        }
        static void DownArrowPressed() {
            _Selection++;
            _DotsPosition++;
        }
        #endregion
        
        #region threads
        Thread inputListener = new Thread(() => {
            Start: while(_Looping) {
                var input = Console.ReadKey();
                ChangeState(input.Key);
            } goto Start;
        });
        Thread themesListener = new Thread(() => {
            Start: while (_Looping) {
                ThemesList = Directory.GetFiles(path.ThemesFolder).ToList();
                if(oldThemesList.Count != ThemesList.Count) {
                    oldThemesList = ThemesList;
                    UpdateContentMenu();
                }
            } goto Start;
        });
        #endregion

        #region draw ui
        static void DrawTitle() {
            // console.WriteLine();
            console.Write($"{DotsHandler()} ", ConsoleColor.DarkGreen); console.Write("Select one in list below", ConsoleColor.DarkGray);
            console.WriteLine();
            console.WriteLine();
            if(!MenuCapIsReached) { console.Write("["); console.Write($"{ThemesList.Count}", ConsoleColor.DarkGreen); console.WriteLine($"/{10}] Themes: "); }
            else { console.Write("["); console.Write($"{ThemesList.Count}", ConsoleColor.DarkRed); console.WriteLine($"/{MenuCap}] Themes: "); } 
        }
        static void DrawContent() {
            for(int i = 0; i < _MenuContent.Count; i++) {
                if(i == _Selection) {
                    if(_MenuContent[i] != Separator)
                    console.WriteLine($"{Selector} {_MenuContent[i]}", ConsoleColor.DarkGreen);
                    else console.WriteLine($"{Separator}{Separator}", ConsoleColor.DarkGreen);
                }
                else {
                    if(_MenuContent[i] != Separator)
                    console.WriteLine($"{EmptySelector} {_MenuContent[i]}");
                    else console.WriteLine($"{_MenuContent[i]}");
                }
            }
        }
        static void DrawTips() {
            console.WriteLine();
            console.WriteLine($"   --------------------", ConsoleColor.DarkGray);
            console.WriteLine($"   use [↑↓] and [Enter]", ConsoleColor.DarkGray);
            console.WriteLine($"   to navigate the menu", ConsoleColor.DarkGray);
        }
        static void UpdateContentMenu() {
            if(!OperatingSystem.IsWindows()) { return; }
            
            _MenuContent.Clear();

            foreach(var theme_title in ThemesList) {
                if(_MenuContent.Count >= MenuCap) { MenuCapIsReached = true; break; }
                else MenuCapIsReached = false;
                _MenuContent.Add($"{Path.GetFileNameWithoutExtension(theme_title)}");
            }
            _MenuContent.Add(Separator);
            _MenuContent.Add("Restore theme to 'default'");
            _MenuContent.Add("Visit project's GitHub page");
            _MenuContent.Add($"Exit {Console.Title}");

            _MenuSize = _MenuContent.Count - 1;

            if(_Selection < 0) _Selection = _MenuSize;
            if(_Selection > _MenuSize) _Selection = 0;

            UpdateUI = true;
        }
        #endregion

        #region services
        public void ListenForChanges() { DrawUI(UpdateUI); }
        public void RunThreads() {
            inputListener.Start();
            themesListener.Start();
        }
        public void Begin() {
            _Looping = true;
            _Selection = 0;
        }
        static string DotsHandler() {
            if(_DotsPosition > Dots.Length - 1) _DotsPosition = 0;
            else if(_DotsPosition < 0) _DotsPosition = Dots.Length - 1;
            return Dots[_DotsPosition];
        }
        #endregion
        public _ConsoleDrawing() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "yum-toolkit";
            Console.CursorVisible = false;
            if(OperatingSystem.IsWindows()) { 
                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            }
        }
    }
}