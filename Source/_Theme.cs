using System.Text;
using YumToolkit.Data;

namespace YumToolkit {
    public static class _Theme {
        static _ServiceMessages serviceMessages = new _ServiceMessages();
        public static byte[] GetByteArray(string str) {
            return Enumerable.Range(0, str.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(str.Substring(x, 2), 16)).ToArray();
        }
        public static void SetColor(byte[] color, int color_address) {

            if(!File.Exists("sai.dev.exe")) {
                Console.Clear();
                _Console.WriteLine(serviceMessages.DevFileIsNotExists, ConsoleColor.DarkRed);
                return;
            }

            byte[] binary = File.ReadAllBytes("sai.dev.exe");
            
            // RGBA in SAI2 is BGRA. Live your life with that.
            (color[0], color[2]) = (color[2], color[0]);
            //

            for(int i = 0; i < color.Length; i++)  { binary[color_address + i] = color[i]; }

            try {
                File.WriteAllBytes("sai2.exe", binary);
                Console.Clear();
                _Console.Write($"Binary data overwritten!", ConsoleColor.Blue);

            } catch (Exception e) {
                Console.Clear();
                _Console.WriteLine($"{e}",ConsoleColor.DarkRed);
                
            }
            
        }
        public static int GetDecimalAddress(this string hex_address) {
            return int.Parse(hex_address.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);
        }
    }
}