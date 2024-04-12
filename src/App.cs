using YumToolkit.Global;

namespace YumToolkit {
    class App : _Globals {
        static void Main(string[] args) {
            input.listener.Start();
            AppBegin:
            drawing.Begin();
            while(drawing.MainLoop) { 
                drawing.ListenForChanges(); 
            };
            goto AppBegin;
        }
    }
}