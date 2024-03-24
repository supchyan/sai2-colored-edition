using YumToolkit.Global;

namespace YumToolkit.Core {
    class _Theme : _Globals {
        public byte[] binary { get; set; } = [];
        public byte[] ReadTmpFile(string tmp_file_name) {
            return File.ReadAllBytes(tmp_file_name);
        }
        public void SetElementColor(byte[] color, int color_address) {
            if(!File.Exists(name.tmp)) { console.SendMessage(serviceMessage.TmpFileIsNotExist, ConsoleColor.DarkRed); return; } 
            // Replaces certain color sequence:
            for(int i = 0; i < color.Length; i++) { binary[color_address + i] = color[i]; }
        }
        bool WrongSequence(byte[] bin, int index, byte[] color_to_detect) {
            // Detects bytes in sequence which doesn't equal certain color_to_detect/
            // Skips this sequence and goes to the next one.
            for(int cur_index = 0; cur_index < color_to_detect.Length; cur_index ++) {
                if(bin[index + cur_index] != color_to_detect[cur_index]) { return true; }

            } return false;
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
        /// <param name="isArtifacted">
        /// Set this to true, if you want to check every single byte as independent sequence.
        /// Useful to fix different kind of artifacts. False as default.
        /// </param>
        public void SetElementColorComplicated(byte[] color, int start_index, int end_index, byte[] default_color, bool isArtifacted = false) {
            if(!File.Exists(name.tmp)) { console.SendMessage(serviceMessage.TmpFileIsNotExist, ConsoleColor.DarkRed); return; }
            
            int value = isArtifacted ? 1 : color.Length;
            // Find certain sequence position and move on until the end
            for(int index = start_index; index < end_index; index += value) {
                if(WrongSequence(binary, index, default_color)) { continue; }
                // Change color in certain sequence
                for(int col_index = 0; col_index  < color.Length; col_index++) { binary[index + col_index] = color[col_index]; }
            }
            
        }
        // TODO: Should fix color picker's circle, but doesn't. Thinking on better solution right now.. 
        byte[] col = [0,0,0];
        public void FixColorPicker(int start_index, int end_index, byte[] color) {
            for(byte i = 1; i < 254; i++) {
                col = [i,i,i];
                // Finds certain sequence position and moves on until the end
                for(int index = start_index; index < end_index; index += col.Length) {
                    if(WrongSequence(binary, index, col)) { continue; }
                    for(int col_index = 0; col_index  < color.Length - 1; col_index++) { binary[index + col_index] = color[col_index]; }
                }
            }
        }
        /// <summary>
        /// Saves current theme changes.
        /// </summary>
        public void SaveTheme() {
            try {
                File.WriteAllBytes(name.original, binary);
                console.SendMessage(serviceMessage.ThemeHasBeenApplied, ConsoleColor.DarkGreen);
            } catch { console.SendMessage(serviceMessage.OriginalFileIsBusy,ConsoleColor.DarkRed); }
        }
    }
}