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
            string R = string.Empty, G = string.Empty, B = string.Empty; 
            string r = string.Empty, g = string.Empty, b = string.Empty; 
            string hexLets = "ABCDEF", hexNums = "0123456789", hexAll = "0123456789ABCDEF";
            byte[] cirCol = [];

            // For colors like letter + num in each channel
            foreach(var o in hexLets) {
                foreach(var i in hexNums) {
                    cirCol = $"#00{o}{i}{o}{i}{o}{i}".toByteColor().NoAlpha();
                    for(int n = start_index; n < end_index; n++) {
                        if(WrongSequence(binary, n, cirCol)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[n + col_index] = to_color[col_index]; }
                    }
                }
            }

            // For colors like letter + letter in each channel
            foreach(var o in hexLets) {
                foreach(var oo in hexLets) {
                    cirCol = $"#00{o}{oo}{o}{oo}{o}{oo}".toByteColor().NoAlpha();
                    for(int n = start_index; n < end_index; n++) {
                        if(WrongSequence(binary, n, cirCol)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[n + col_index] = to_color[col_index]; }
                    }
                }
            }

            // For colors like num + letter in each channel
            foreach(var i in hexNums) {
                foreach(var o in hexLets) {
                    cirCol = $"#00{i}{o}{i}{o}{i}{o}".toByteColor().NoAlpha();
                    for(int n = start_index; n < end_index; n++) {
                        if(WrongSequence(binary, n, cirCol)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[n + col_index] = to_color[col_index]; }
                    }
                }
            }

            // // CA -> F9 fixes

            // F9CAE2 - > F9F9CA
            for(int o = 2; o < hexLets.Length; o++) {
                for(int i = 9; i < hexAll.Length; i++) {
                    cirCol = $"#00F9{hexLets[o]}{hexAll[i]}E2".toByteColor().NoAlpha();
                    for(int n = start_index; n < end_index; n++) {
                        if(WrongSequence(binary, n, cirCol)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[n + col_index] = to_color[col_index]; }
                    }
                }
            }
            for(int o = 2; o < hexLets.Length; o++) {
                for(int i = 2; i < hexAll.Length; i++) {
                    cirCol = $"#00F9F9{hexLets[o]}{hexAll[i]}".toByteColor().NoAlpha();
                    for(int n = start_index; n < end_index; n++) {
                        if(WrongSequence(binary, n, cirCol)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[n + col_index] = to_color[col_index]; }
                    }
                }
            }

            // // F9F9CA - > CAF9E2
            for(int o = 2; o < hexLets.Length; o++) {
                for(int i = 0; i < hexAll.Length; i++) {
                    cirCol = $"#00{o}{i}F9CA".toByteColor().NoAlpha();
                    for(int n = start_index; n < end_index; n++) {
                        if(WrongSequence(binary, n, cirCol)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[n + col_index] = to_color[col_index]; }
                    }
                }
            }
            for(int o = 2; o < hexLets.Length; o++) {
                for(int i = 2; i < hexAll.Length; i++) {
                    cirCol = $"#00CAF9{hexLets[o]}{hexAll[i]}".toByteColor().NoAlpha();
                    for(int n = start_index; n < end_index; n++) {
                        if(WrongSequence(binary, n, cirCol)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[n + col_index] = to_color[col_index]; }
                    }
                }
            }

            // CAF9E2 -> CACAF9
            for(int o = 2; o < hexLets.Length; o++) {
                for(int i = 0; i < hexAll.Length; i++) {
                    cirCol = $"#00{o}{i}F9E2".toByteColor().NoAlpha();
                    for(int n = start_index; n < end_index; n++) {
                        if(WrongSequence(binary, n, cirCol)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[n + col_index] = to_color[col_index]; }
                    }
                }
            }
            for(int o = 4; o < hexLets.Length; o++) {
                for(int i = 2; i < hexAll.Length; i++) {
                    cirCol = $"#00CACA{hexLets[o]}{hexAll[i]}".toByteColor().NoAlpha();
                    for(int n = start_index; n < end_index; n++) {
                        if(WrongSequence(binary, n, cirCol)) { continue; }
                        // Change color in certain sequence
                        for(int col_index = 0; col_index  < to_color.Length; col_index++) { binary[n + col_index] = to_color[col_index]; }
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