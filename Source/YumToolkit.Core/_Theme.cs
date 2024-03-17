using YumToolkit.Core.Data;
namespace YumToolkit.Core {
    public class _Theme {
        public static void SetElementColor(byte[] color, int color_address) {
            if(!File.Exists(_Name.GetFileName.Dev)) {
                Console.Clear();
                _Console.WriteLine(_ServiceMessage.GetMessage.DevFileIsNotExists, ConsoleColor.DarkRed);
                return;
            }

            byte[] binary = File.ReadAllBytes(_Name.GetFileName.Dev);
            
            // RGBA in SAI2 is BGRA. Live your life with that.
            (color[0], color[2]) = (color[2], color[0]);

            for(int i = 0; i < color.Length; i++) { binary[color_address + i] = color[i]; }

            try {
                File.WriteAllBytes(_Name.GetFileName.Classic, binary);
                Console.Clear();
                _Console.Write($"Binary data overwritten!", ConsoleColor.DarkGreen);

            } catch (Exception e) {
                Console.Clear();
                _Console.WriteLine($"{e}",ConsoleColor.DarkRed);
                
            }
        }
    }
}