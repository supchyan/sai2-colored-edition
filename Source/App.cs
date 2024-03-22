using YumToolkit.Core;
namespace YumToolkit {
    class App : AppHelper {
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

                _Console.Drawing.CONSOLE_RESTART();
                _Console.Drawing.CONSOLE_DRAW_MAIN();
                while(!_Console.isSelected) { _Console.Drawing.CONSOLE_MENU(); };
                // run selected ai
                _Action();

            goto InterfaceBegin;

        }
    }
}