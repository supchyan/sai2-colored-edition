using YumToolkit.Global;

namespace YumToolkit {
    class App : _Globals {
        static void Main(string[] args) {
            
            AppBegin:

                consoleDrawing.Begin();
                while(consoleDrawing.Looping) { consoleDrawing.UI(); };

                // selected ai implementation
                appHelper._Action();

            goto AppBegin;

        }
    }
}