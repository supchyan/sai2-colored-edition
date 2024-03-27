using YumToolkit.Global;

namespace YumToolkit.Core {
    class _Theme : _Globals {
        public byte[] binary { get; set; } = [];
        public byte[] ReadTmpFile(string tmp_file_name) {
            return File.ReadAllBytes(tmp_file_name);
        }
        public void SetElementColor(byte[] to_color, int color_address) {
            if(!File.Exists(name.tmp)) { console.SendMessage(serviceMessage.TmpFileIsNotExist, ConsoleColor.DarkRed); return; } 
            // Replaces certain color sequence:
            for(int i = 0; i < to_color.Length; i++) { binary[color_address + i] = to_color[i]; }
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
        /// Some parts of the SAI2 contains long byte sequences, which is hard to debug, so temporary solution is what you see.
        /// </summary>
        /// <param name="to_color">Custom theme color you want to replace to</param>
        /// <param name="start_index">Beggining of byte sequence</param>
        /// <param name="end_index">End of byte sequence</param>
        /// <param name="from_color">Color, which should be replaced</param>
        /// <param name="isArtifacted">
        /// Set this to true, if you want to check every single byte as independent sequence.
        /// Useful to fix different kind of artifacts. False as default.
        /// </param>
        public void SetElementColorComplicated(byte[] from_color, byte[] to_color, int start_index, int end_index, bool isArtifacted = false) {
            if(!File.Exists(name.tmp)) { console.SendMessage(serviceMessage.TmpFileIsNotExist, ConsoleColor.DarkRed); return; }
            
            int value = isArtifacted ? 1 : to_color.Length;
            // Find certain sequence position and move on until the end
            for(int index = start_index; index < end_index; index += value) {
                if(WrongSequence(binary, index, from_color)) { continue; }
                // Change color in certain sequence
                for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[index + col_index] = to_color[col_index]; }
            }
            
        }
        public void SetElementColorWithTotalReplacment(byte[] to_color, int start_index, int end_index) {
            if(!File.Exists(name.tmp)) { console.SendMessage(serviceMessage.TmpFileIsNotExist, ConsoleColor.DarkRed); return; }
            
            int value = to_color.Length;
            // Find sequence position and move on until the end
            for(int index = start_index; index < end_index; index += value) {
                // Change color in sequence
                for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[index + col_index] = to_color[col_index]; }
            }
            
        }
        // TODO: Should fix color picker's circle, but doesn't. Thinking on better solution right now.. 
        public void FixColorPicker(byte[] to_color, int start_index, int end_index) {
            string channel = string.Empty;
            string chArr = "ABCDEF";
            string numArr = "0123456789";
            byte[] circleColor = [];
            for(int ch = 0; ch < 6; ch++) {
                for(int num = 0; num < 10; num++) {
                    channel = $"{chArr[ch]}{numArr[num]}";
                    circleColor = $"#00{channel}{channel}{channel}".toByteColor().NoAlpha();
                    // Finds certain sequence position and moves on until the end
                    int value = 1;
                    // Find certain sequence position and move on until the end
                    for(int index = start_index; index < end_index; index += value) {
                        if(WrongSequence(binary, index, circleColor)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[index + col_index] = to_color[col_index]; }
                    }
                }
            }
            for(int ch = 0; ch < 6; ch++) {
                for(int ch2 = 0; ch2 < 6; ch2++) {
                    channel = $"{chArr[ch]}{chArr[ch2]}";
                    circleColor = $"#00{channel}{channel}{channel}".toByteColor().NoAlpha();
                    // Finds certain sequence position and moves on until the end
                    int value = 1;
                    // Find certain sequence position and move on until the end
                    for(int index = start_index; index < end_index; index += value) {
                        if(WrongSequence(binary, index, circleColor)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[index + col_index] = to_color[col_index]; }
                    }
                }
            }
            for(int num = 0; num < 10; num++) {
                for(int ch = 0; ch < 6; ch++) {
                    channel = $"{numArr[num]}{chArr[ch]}";
                    circleColor = $"#00{channel}{channel}{channel}".toByteColor().NoAlpha();
                    // Finds certain sequence position and moves on until the end
                    int value = 1;
                    // Find certain sequence position and move on until the end
                    for(int index = start_index; index < end_index; index += value) {
                        if(WrongSequence(binary, index, circleColor)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[index + col_index] = to_color[col_index]; }
                    }
                }
            }
        }
        /// <summary>
        /// Saves current theme changes.
        /// </summary>
        public void SaveTheme() {
            if(file.IsFileBusy()) { return; }
            File.WriteAllBytes(name.original, binary);
            console.SendMessage(serviceMessage.ThemeHasBeenApplied, ConsoleColor.DarkGreen);
        }
    }
}