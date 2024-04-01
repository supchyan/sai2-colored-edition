using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _ConsoleDrawing : _Globals { // , IConsoleDrawing
        public bool Looping { get; set; } = true;
        public int Selection { get; set; }
        public int MenuSize { get; set; }

        string[] Dots { get; set; } = ["⠋","⠙","⠸","⠴","⠦","⠇"];
        int DotsPosition { get; set; } = 0;

        string Separator { get; set; } = "-";
        string Selector { get; set; } = "◉ ";
        string EmptySelector { get; set; } = "○";

        public List<string> ThemesList { get; }
        public List<string> MenuContent { get; } = new List<string>();

        #region input events
        public delegate void EnterPressed();
        event EnterPressed Enter_Pressed;

        public delegate void UpArrowPressed();
        event UpArrowPressed Up_Pressed;

        public delegate void DownArrowPressed();
        event DownArrowPressed Down_Pressed;
        public delegate void ListenUserInput();
        event ListenUserInput Listen_User_Input;
        #endregion

        #region ui events
        public delegate void LoadContentToMenu();
        event LoadContentToMenu Load_Content_To_Menu;

        public delegate void DrawTitle();
        event DrawTitle Draw_Title;

        public delegate void DrawContent();
        event DrawContent Draw_Content;

        public delegate void DrawTips();
        event DrawTips Draw_Tips;
        #endregion

        #region input logic
        void _EnterPressed() { Looping = false; }
        void _UpArrowPressed() {
            if(Selection != 0) {
                Selection--;
            } else {
                Selection = MenuSize;
            }
            DotsPosition--;
        }
        void _DownArrowPressed() {
            if(Selection != MenuSize) {
                Selection++;
            } else {
                Selection = 0;
            }
            DotsPosition++;
        }
        void _ListenUserInput() {
            var input = Console.ReadKey();

            if(input.Key == ConsoleKey.UpArrow) { Up_Pressed.Invoke(); }
            if(input.Key == ConsoleKey.DownArrow) { Down_Pressed.Invoke(); }
            if(input.Key == ConsoleKey.Enter) { Enter_Pressed.Invoke(); }
        }
        #endregion

        #region ui logic
        void _DrawTitle() {
            console.WriteLine();
            console.Write($"{DotsHandler()} ", ConsoleColor.DarkGreen); console.Write("Select one in list below", ConsoleColor.DarkGray);
            console.WriteLine();
            console.WriteLine();
            console.WriteLine("Themes:");
        }
        void _DrawContent() {
            for(int i = 0; i < MenuContent.Count; i++) {
                if(i == Selection) {
                    if(MenuContent[i] != Separator)
                    console.WriteLine($"{Selector} {MenuContent[i]}", ConsoleColor.DarkGreen);
                    else console.WriteLine($"{Separator}{Separator}", ConsoleColor.DarkGreen);
                }
                else {
                    if(MenuContent[i] != Separator)
                    console.WriteLine($"{EmptySelector} {MenuContent[i]}");
                    else console.WriteLine($"{MenuContent[i]}");
                }
            }
        }
        void _DrawTips() {
            console.WriteLine();
            console.WriteLine("[ ↑↓ ] and [ Enter ]", ConsoleColor.DarkGray);
            console.WriteLine("   to navigate ☶", ConsoleColor.DarkGray);
            
        }
        void _LoadContentToMenu() {
            if(!OperatingSystem.IsWindows()) { return; }

            foreach(var theme_title in ThemesList) {
                MenuContent.Add($"{Path.GetFileNameWithoutExtension(theme_title)}");
            }
            MenuContent.Add(Separator);
            MenuContent.Add("Restore theme to 'default'");
            MenuContent.Add("Visit project's GitHub page");
            MenuContent.Add($"Exit {Console.Title}");

            MenuSize = MenuContent.Count - 1;
        }
        #endregion

        #region drawing
        public void Begin() { Looping = true; Selection = 0; }
        public void UI() {
            Console.Clear();
            Draw_Title.Invoke();
            Draw_Content.Invoke();
            Draw_Tips.Invoke();
            Listen_User_Input.Invoke();
        }
        #endregion

        string DotsHandler() {
            if(DotsPosition > Dots.Length - 1) DotsPosition = 0;
            else if(DotsPosition < 0) DotsPosition = Dots.Length - 1;
            return Dots[DotsPosition];
        }
        
        public _ConsoleDrawing() {

            Load_Content_To_Menu += _LoadContentToMenu;

            Enter_Pressed += _EnterPressed;
            Up_Pressed += _UpArrowPressed;
            Down_Pressed += _DownArrowPressed;

            Draw_Title += _DrawTitle;
            Draw_Content += _DrawContent;
            Draw_Tips += _DrawTips;

            Listen_User_Input += _ListenUserInput;

            ThemesList = Directory.GetFiles(path.ThemesFolder).ToList();
            Load_Content_To_Menu.Invoke();
        }
    }
}