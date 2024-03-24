using System.Numerics;
using YumToolkit.Core.Interfaces.UI;
using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _ConsoleAnimator : _Globals, IConsoleAnimator {
        public string[] Stick { get; }
        public string[] Emote { get; }
        public void SetFrame(string frame, bool safe_drawing, Vector2 sprite_pos, int delay) {
            if(safe_drawing) {
                Console.SetCursorPosition((int)sprite_pos.X, (int)sprite_pos.Y);
                console.Write(frame);
                Thread.Sleep(delay);
            }
        }
        public _ConsoleAnimator() {
            Stick = [ "\\","|","/","-" ];
            Emote = [ "<.<  ","<.<  ","-.-  "," -.- ","  -.-","  >.>","  >.>","  -.-"," -.- ","-.-  " ];
        }
    }
}