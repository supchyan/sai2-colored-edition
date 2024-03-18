using YumToolkit.Core.Data;
namespace YumToolkit.Core {
    public class _Theme {
        static byte[] binary = File.ReadAllBytes(_Name.tmp);
        public static void SetElementColor(byte[] color, int color_address) {
            if(!File.Exists(_Name.tmp)) {
                Console.Clear();
                _Console.WriteLine(_ServiceMessage.TmpFileIsNotExists, ConsoleColor.DarkRed);
                return;
            }

            // RGBA in SAI2 is BGRA. Live your life with that.
            (color[0], color[2]) = (color[2], color[0]);

            for(int i = 0; i < color.Length; i++) { binary[color_address + i] = color[i]; }
            
        }
        /// <summary>
        /// Searches sequences in certain byte's range and replaces pack of the colors. 
        /// P.S. Some parts of the SAI2 contains long byte sequences, which is hard to debug, so I decided to replace it at one try,
        /// thinking, thats all color sequences.
        /// P.P.S. I didn't find any issues in sai2's workflow after that.
        /// </summary>
        /// <param name="color">Custom theme color</param>
        /// <param name="start_index">Beggining of byte sequence</param>
        /// <param name="end_index">End of byte sequence</param>
        /// <param name="default_color">Color, which should be replaced</param>
        public static void SetElementColorComplicated(byte[] color, int start_index, int end_index, byte[] default_color) {
            // if(!File.Exists(_Name.tmp)) {
            //     Console.Clear();
            //     _Console.WriteLine(_ServiceMessage.TmpFileIsNotExists, ConsoleColor.DarkRed);
            //     return;
            // }

            // TODO замена только нужных цветов в огромном массиве последовательностей

            byte[] tmp = 
            [   0,0,0,0,
                0,0,0,0,
                1,1,1,1,
                2,2,2,2,
                0,0,0,0,
                0,0,0,0,
                1,1,1,1,
                2,2,2,2
            ];

            // RGBA in SAI2 is BGRA. Live your life with that.
            (color[0], color[2]) = (color[2], color[0]);

            // Find certain sequence position and move on until the end
            for(int index = start_index; index < end_index; index += 4) {
                
                // If some bytes in sequence isn't equals certain default_color -> skip this sequence and go to next one.
                for(int cur_index = 0; cur_index  < 4; cur_index++) {
                    if(tmp[index + cur_index] != default_color[cur_index]) {
                        break;
                    }
                }

                // Change color in certain sequence
                for(int col_index = 0; col_index  < color.Length; col_index++) {
                    tmp[index + col_index] = color[col_index];
                }
                
            }

            Console.WriteLine("[{0}]", string.Join(", ", tmp));
            
        }
        public static void SaveTheme() {
            try {
                File.WriteAllBytes(_Name.original, binary);
                Console.Clear();
                _Console.Write($"Binary data overwritten!", ConsoleColor.DarkGreen);

            } catch (Exception e) {
                Console.Clear();
                _Console.WriteLine($"{e}",ConsoleColor.DarkRed);
                
            }
        }
    }
}