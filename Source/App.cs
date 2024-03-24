using System.Dynamic;
using YumToolkit.Core;
using YumToolkit.Core.UI;
namespace YumToolkit {
    class App {
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

                _ConsoleDrawing.Get.CONSOLE_RESTART();
                _ConsoleDrawing.Get.CONSOLE_DRAW_MAIN();
                while(!_ConsoleDrawing.Get.isSelected) { _ConsoleDrawing.Get.CONSOLE_MENU(); };
                // Running selected ai
                AppHelper.Get._Action();

            goto InterfaceBegin;

        }
    }
}