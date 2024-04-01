using YumToolkit.Global;

namespace YumToolkit {
    class App : _Globals {
        static void Main(string[] args) {
            
            // Setting Default console props:
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "yum-toolkit";
            Console.CursorVisible = false;
            // Console.SetBufferSize(Console); // buffer size todo to fix huge theme amount glitch
            // TODO: SET LIMITS TO MAX THEMES DRAWING AT ONCE.
            InterfaceBegin:

                consoleDrawing.Begin();
                while(consoleDrawing.Looping) { consoleDrawing.UI(); };

                // Running selected ai
                appHelper._Action();

            goto InterfaceBegin;

        }
    }
}