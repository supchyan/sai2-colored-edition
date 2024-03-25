using YumToolkit.Global;

namespace YumToolkit {
    class App : _Globals {
        static void Main(string[] args) {
            
            // Setting Default console props:
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Yum2Tools";
            Console.CursorVisible = false;

            if(!OperatingSystem.IsWindows()) {
                Console.WriteLine($"This program cannot be run on {Environment.OSVersion}... Or can't be :)");
                return;
            }    
            
            InterfaceBegin:

                consoleDrawing.CONSOLE_RESTART();
                consoleDrawing.CONSOLE_DRAW_MAIN();
                while(!consoleDrawing.isSelected) { consoleDrawing.CONSOLE_MENU(); };
                // Running selected ai
                AppHelper.Get._Action();

            goto InterfaceBegin;

        }
    }
}