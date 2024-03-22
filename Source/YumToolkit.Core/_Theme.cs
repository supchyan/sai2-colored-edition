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
        static bool WrongSequence(byte[] bin, int index, byte[] color_to_detect) {
            // If some bytes in sequence doesn't equal certain color_to_detect -> skip this sequence and go to next one.
            // Useful to replace huge sequence arrays.
            for(int cur_index = 0; cur_index < color_to_detect.Length; cur_index ++) {
                if(bin[index + cur_index] != color_to_detect[cur_index]) {
                    return true;
                }
            }
            return false;
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
        /// /// <param name="isArtifacted">Condition for semi colors replacer behavior. False as default</param>
        public static void SetElementColorComplicated(byte[] color, int start_index, int end_index, byte[] default_color, bool isArtifacted = false) {
            if(!File.Exists(_Name.tmp)) {
                Console.Clear();
                _Console.WriteLine(_ServiceMessage.TmpFileIsNotExists, ConsoleColor.DarkRed);
                return;
            }

            // RGBA in SAI2 is BGRA. Live your life with that.
            (color[0], color[2]) = (color[2], color[0]);
            
            int value = isArtifacted ? 1 : color.Length;
            // Find certain sequence position and move on until the end
            for(int index = start_index; index < end_index; index += value) {
                
                if(WrongSequence(binary, index, default_color)) { continue; }

                // Change color in certain sequence
                for(int col_index = 0; col_index  < color.Length; col_index++) {
                    binary[index + col_index] = color[col_index];
                }
                
            }
            
        }

        // ??? Should fix color picker circle, but doesn't. I'm blind to fix it, so anybody will, someday. 
        static byte[] col = [0,0,0];
        public static void FixColorPicker(int start_index, int end_index, byte[] color) {
            for(byte i = 1; i < 254; i++) {
                col = [i,i,i];
                // Find certain sequence position and move on until the end
                for(int index = start_index; index < end_index; index += col.Length) {
                    if(WrongSequence(binary, index, col)) { continue; }

                    // _Console.WriteLine($"Current sequence is {binary[index]} {binary[index+1]} {binary[index+2]}.", ConsoleColor.DarkYellow);
                    
                    for(int col_index = 0; col_index  < color.Length - 1; col_index++) {
                        binary[index + col_index] = color[col_index];
                    }
                    
                }

            }
            
        }

        /// <summary>
        /// Saves current theme changes.
        /// </summary>
        public static void SaveTheme() {
            try {
                File.WriteAllBytes(_Name.original, binary);
                Console.Clear();
                _Console.Write(_ServiceMessage.ThemeHasBeenApplied, ConsoleColor.DarkGreen);

            } catch (Exception e) {
                _Console.WriteLine($"{e}",ConsoleColor.DarkRed);
                
            }
        }
    }
}