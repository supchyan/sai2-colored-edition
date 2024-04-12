using System.Data;
using System.Runtime.InteropServices;
using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _ConsoleDrawing : _Globals { // , IConsoleDrawing
        static bool _MainLoop { get; set; } = true;
        public bool MainLoop => _MainLoop;

        static int _Selection { get; set; }
        public int Selection => _Selection + minIndex;

        static int _MenuSize { get; set; }

        static string[] Dots = ["⠋","⠙","⠸","⠴","⠦","⠇"];
        static int _DotsPosition;

        static string NextPageOperator { get; set; } = "->";
        string SelectedNextPageOperator { get; set; } = "-->";
        static string Selector { get; set; } = "** ";
        static string EmptySelector { get; set; } = "* ";

        static int Page, MaxPage, minIndex;
        static List<string> oldThemesList { get; set; } = new List<string>();
        static List<string> ThemesList { get; set; } = new List<string>();
        public List<string> pubThemesList => ThemesList;

        static List<string> _MenuContent { get; } = new List<string>();
        public List<string> MenuContent => _MenuContent;

        const int ThemesCap = 5;

        static bool UpdateUI { get; set; }


        #region input logic
        static void EnterPressed() {
            
            var select = _MenuSize - _Selection;
            if(select >= 4) appHelper.SetTheme();
            if(select == 3) GoToNextPage();
            if(select == 2) appHelper.RestoreTheme();
            if(select == 1) appHelper.GitHubLink();
            if(select == 0) appHelper.ExitApplication();

            _MainLoop = false;
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
            Start: while(_MainLoop) {
                var input = Console.ReadKey();
                ChangeState(input.Key);
            } goto Start;
        });
        Thread themesListener = new Thread(() => {
            Start: while (_MainLoop) {
                
                if(Page > MaxPage) { 
                    PageLimitIsReached();
                    InvokeListUpdates(); 
                }

                ThemesList = Directory.GetFiles(path.ThemesFolder).ToList();                
                if(oldThemesList.Count != ThemesList.Count) {
                    InvokeListUpdates();

                } else {
                    for(int i = 0; i < ThemesList.Count; i++) {
                        if(oldThemesList[i] != ThemesList[i]) {
                            InvokeListUpdates();
                        }
                    }
                }
            } goto Start;
        });
        #endregion

        #region draw ui
        void DrawTitle() {
            console.Write($"{DotsHandler()} ", ConsoleColor.DarkGreen); console.Write("Select one in list below", ConsoleColor.DarkGray);
            console.WriteLine();
            console.WriteLine();
            console.WriteLine($"Page [{Page} / {MaxPage}]:");
        }

        void DrawContent() {
            for(int i = 0; i < _MenuContent.Count; i++) {
                if(i == _Selection) {
                    if(_MenuContent[i] != NextPageOperator)
                    console.WriteLine($"{Selector} {_MenuContent[i]}", ConsoleColor.DarkGreen);
                    else console.WriteLine($"{SelectedNextPageOperator}", ConsoleColor.DarkGreen);
                }
                else {
                    if(_MenuContent[i] != NextPageOperator)
                    console.WriteLine($"{EmptySelector} {_MenuContent[i]}");
                    else console.WriteLine($"{_MenuContent[i]}");
                }
            }
        }
        void DrawTips() {
            console.WriteLine();
            console.WriteLine($"   -------------------- {Selection}", ConsoleColor.DarkGray);
            console.WriteLine($"   use [↑↓] and [Enter]", ConsoleColor.DarkGray);
            console.WriteLine($"   to navigate the menu", ConsoleColor.DarkGray);
        }
        static void InvokeListUpdates() {
            UpdatePages();
            UpdateContentMenu();
            oldThemesList = ThemesList;
        }
        static void UpdatePages() {
            MaxPage = -1;
            foreach(var i in ThemesList) {
                if(ThemesList.IndexOf(i) % ThemesCap == 0) { 
                    MaxPage++;
                }
            }
        }
        static void UpdateContentMenu() {
            if(!OperatingSystem.IsWindows()) { return; }
            
            _MenuContent.Clear();

            ThemesList.Sort(); // Sorting themes alphabetically 

            if(ThemesList.Count > minIndex + ThemesCap) {
                for(int i = minIndex; i < minIndex + ThemesCap; i++) {
                    _MenuContent.Add($"{Path.GetFileNameWithoutExtension(ThemesList[i])}");
                }
            } else {
                for(int i = minIndex; i < ThemesList.Count; i++) {
                    _MenuContent.Add($"{Path.GetFileNameWithoutExtension(ThemesList[i])}");
                }
            }
            

            _MenuContent.Add(NextPageOperator);
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
        static void GoToNextPage() {
            if(Page < MaxPage) { Page++; minIndex += ThemesCap;}
            else { Page = 0; minIndex = 0; } 
        }
        static void PageLimitIsReached() {
            Page--;
            minIndex -= ThemesCap;
        }
        static void ChangeState(ConsoleKey key) {
            if(key is ConsoleKey.DownArrow) DownArrowPressed();
            if(key is ConsoleKey.UpArrow) UpArrowPressed();
            if(key is ConsoleKey.Enter) EnterPressed();
            UpdateContentMenu();
        }
        void DrawUI (bool condition) {
            if(!condition) { return; }
            Console.Clear();
            DrawTitle(); DrawContent(); DrawTips();
            UpdateUI = false;
        }
        public void ListenForChanges() { DrawUI(UpdateUI); }
        public void RunThreads() {
            inputListener.Start();
            themesListener.Start();
        }
        public void Begin() {
            _MainLoop = true;
            _Selection = 0;
        }
        string DotsHandler() {
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