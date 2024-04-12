using YumToolkit.Global;

namespace YumToolkit {
    class App : _Globals {
        static void Main(string[] args) {
            consoleDrawing.RunThreads();
            AppBegin:
            consoleDrawing.Begin();
                while(consoleDrawing.MainLoop) { 
                    consoleDrawing.ListenForChanges(); 
                };
            goto AppBegin;
        }
    }
}