using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _Drawing : _Globals {
        public bool MainLoop { get; set; }
        public bool UpdateUI { get; set; }

        #region draw ui
        void DrawTitle() {
            console.Write($"{DotsHandler()} ", ConsoleColor.DarkGreen);
            console.Write("Select one in list below", ConsoleColor.DarkGray);
            console.WriteLine();
            console.WriteLine();
            console.WriteLine($"Page [{content.Page} / {content.MaxPage}]:");
        }
        void DrawContent() {
            for(int i = 0; i < content.MenuContent.Count; i++) {
                if(i == content.Selection) {
                    if(content.MenuContent[i] != content.NextPageOperator)
                        console.WriteLine($"{content.Selector} {content.MenuContent[i]}", ConsoleColor.DarkGreen);
                    else console.WriteLine($"{content.SelectedNextPageOperator}", ConsoleColor.DarkGreen);
                
                } else {
                    if(content.MenuContent[i] != content.NextPageOperator)
                        console.WriteLine($"{content.EmptySelector} {content.MenuContent[i]}");
                    else console.WriteLine($"{content.NextPageOperator}");
                }
            }
        }
        void DrawTips() {
            console.WriteLine();
            console.WriteLine($"   --------------------", ConsoleColor.DarkGray);
            console.WriteLine($"   use [↑↓] and [Enter]", ConsoleColor.DarkGray);
            console.WriteLine($"   to navigate the menu", ConsoleColor.DarkGray);
        }
        #endregion

        #region services
        void DrawUI (bool condition) {
            if(!condition) { return; }
            Console.Clear();
            DrawTitle(); DrawContent(); DrawTips();
            UpdateUI = false;
        }
        public void ListenForChanges() { DrawUI(UpdateUI); }
        public void Begin() {
            MainLoop = true;
        }
        string DotsHandler() {
            if(content.DotsPosition > content.Dots.Length - 1) content.DotsPosition = 0;
            else if(content.DotsPosition < 0) content.DotsPosition = content.Dots.Length - 1;
            return content.Dots[content.DotsPosition];
        }
        #endregion
        public _Drawing() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "yum-toolkit";
            Console.CursorVisible = false;
            if(OperatingSystem.IsWindows()) Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }
    }
}