using System.Text;
using YumToolkit.Data;

namespace YumToolkit {
    public class _YumTools {
        static _ServiceMessages serviceMessages = new _ServiceMessages();
        public static _File YumFile = new _File();
        public static _Color GetColor = new _Color();
        public static _Address GetAddress = new _Address();
        public static void SetElementColor(byte[] color, int color_address) {

            if(!File.Exists(_File.GetName.Dev)) {
                Console.Clear();
                _Console.WriteLine(serviceMessages.DevFileIsNotExists, ConsoleColor.DarkRed);
                return;
            }

            byte[] binary = File.ReadAllBytes(_File.GetName.Dev);
            
            // RGBA in SAI2 is BGRA. Live your life with that.
            (color[0], color[2]) = (color[2], color[0]);
            //

            for(int i = 0; i < color.Length; i++) { binary[color_address + i] = color[i]; }

            try {
                File.WriteAllBytes(_File.GetName.Classic, binary);
                Console.Clear();
                _Console.Write($"Binary data overwritten!", ConsoleColor.Blue);

            } catch (Exception e) {
                Console.Clear();
                _Console.WriteLine($"{e}",ConsoleColor.DarkRed);
                
            }
        }
    }
}