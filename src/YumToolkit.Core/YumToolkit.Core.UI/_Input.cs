using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _Input : _Globals {
        static void EnterPressed() {
            var select = content.MenuSize - content.Selection;

            if(select >= 4) appHelper.SetTheme();
            if(select == 3) content.GoToNextPage();
            if(select == 2) appHelper.RestoreTheme();
            if(select == 1) appHelper.GitHubLink();
            if(select == 0) appHelper.ExitApplication();

            drawing.MainLoop = false;
        }
        static void UpArrowPressed() {
            content.Selection--;
            content.DotsPosition--;
        }
        static void DownArrowPressed() {
            content.Selection++;
            content.DotsPosition++;
        }
        static void ChangeState(ConsoleKey key) {
            if(key is ConsoleKey.DownArrow) DownArrowPressed();
            if(key is ConsoleKey.UpArrow) UpArrowPressed();
            if(key is ConsoleKey.Enter) EnterPressed();
            content.UpdateContentMenu();
        }
        public Thread listener = new Thread(() => {
            Start: while(drawing.MainLoop) {
                var input = Console.ReadKey();
                ChangeState(input.Key);
            } goto Start;
        });
    }
}
