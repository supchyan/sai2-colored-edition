using System.Numerics;
namespace YumToolkit.Core.UI {
    class _ConsoleAnimator {
        public static _ConsoleAnimator Call { get; private set; }
        public string[] Stick { get; private set; } = [];
        public string[] Emote { get; private set; } = [];
        public void SetFrame(string frame, bool safe_drawing, Vector2 sprite_pos, int delay) {
            if(safe_drawing) {
                Console.SetCursorPosition((int)sprite_pos.X, (int)sprite_pos.Y);
                _Console.Call.Write(frame);
                Thread.Sleep(delay);
            }
        }
        static _ConsoleAnimator() {
            Call = new _ConsoleAnimator {
                Stick = [ "\\","|","/","-" ],
                Emote = [ "<.<  ","<.<  ","-.-  "," -.- ","  -.-","  >.>","  >.>","  -.-"," -.- ","-.-  " ],
            };
        }
    }
}