namespace YumToolkit.Core {
    public class _Theme : _YumTools {
        public static void SetElementColor(byte[] color, int color_address) {
            if(!File.Exists(GetFileName.Dev)) {
                Console.Clear();
                _Console.WriteLine(ServiceMessage.DevFileIsNotExists, ConsoleColor.DarkRed);
                return;
            }

            byte[] binary = File.ReadAllBytes(GetFileName.Dev);
            
            // RGBA in SAI2 is BGRA. Live your life with that.
            (color[0], color[2]) = (color[2], color[0]);

            for(int i = 0; i < color.Length; i++) { binary[color_address + i] = color[i]; }

            try {
                File.WriteAllBytes(GetFileName.Classic, binary);
                Console.Clear();
                _Console.Write($"Binary data overwritten!", ConsoleColor.Blue);

            } catch (Exception e) {
                Console.Clear();
                _Console.WriteLine($"{e}",ConsoleColor.DarkRed);
                
            }
        }
    }
}