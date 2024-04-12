using YumToolkit.Global;

namespace YumToolkit {
    class App : _Globals {
        static void Main(string[] args) {
            consoleDrawing.RunThreads();
            AppBegin:
            consoleDrawing.Begin();
                while(consoleDrawing.Looping) { 
                    consoleDrawing.ListenForChanges(); 
                };
                // selected ai implementation
                appHelper._Action();
            goto AppBegin;
        }
    }
}