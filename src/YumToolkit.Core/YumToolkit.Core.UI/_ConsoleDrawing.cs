using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _ConsoleDrawing : _Globals { // , IConsoleDrawing
        public bool Looping { get; set; } = true;
        public int Selection { get; set; }
        public int MenuSize { get; set; }

        string[] Stick { get; set; } = ["⠋","⠙","⠸","⠴","⠦","⠇"];
        int StickPosition { get; set; } = 0;

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
            StickPosition--;
        }
        void _DownArrowPressed() {
            if(Selection != MenuSize) {
                Selection++;
            } else {
                Selection = 0;
            }
            StickPosition++;
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
            console.WriteLine($"{StickHandler()} Select one in list below:", ConsoleColor.DarkGray);
        }
        void _DrawContent() {
            for(int i = 0; i < MenuContent.Count; i++) {
                if(i == Selection) console.WriteLine($"{MenuContent[i]}", ConsoleColor.DarkYellow);
                else console.WriteLine($"{MenuContent[i]}");
            }
        }
        void _DrawTips() {
            console.WriteLine();
            console.WriteLine("[ ↑↓ ] and [ Enter ] to navigate.", ConsoleColor.DarkGray);
        }
        void _LoadContentToMenu() {
            if(!OperatingSystem.IsWindows()) { return; }

            foreach(var theme_title in ThemesList) {
                MenuContent.Add($"{Path.GetFileNameWithoutExtension(theme_title)}");
            }
            MenuContent.Add("Restore theme to default");
            MenuContent.Add("Visit project's GitHub page");
            MenuContent.Add($"Exit {Console.Title}");

            MenuSize = MenuContent.Count - 1;
        }
        #endregion

        #region drawing
        public void Begin() { Looping = true; Selection = 0; }
        public void UI() {
            Draw_Title.Invoke();
            Draw_Content.Invoke();
            Draw_Tips.Invoke();
            Listen_User_Input.Invoke();

            Console.Clear();
        }
        #endregion

        string StickHandler() {
            if(StickPosition > Stick.Length - 1) StickPosition = 0;
            else if(StickPosition < 0) StickPosition = Stick.Length - 1;
            return Stick[StickPosition];
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