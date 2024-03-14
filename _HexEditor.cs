using System.Text;

namespace drak_mode_sai2 {
    public class _HexEditor {
        static double right, left;
        public static byte[] GetByteArray(string str) {
            return Enumerable.Range(0, str.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(str.Substring(x, 2), 16)).ToArray();
        }
        /// <summary>
        /// Seraching for valid HEX code inside binaries.
        /// </summary>
        /// <returns>True, when current HEX exists.</returns>
        public static bool ContainsHEX(byte[] sequence, int position, byte[] seeker) {
            if (position + seeker.Length > sequence.Length) return false;

            for (int i = 0; i < seeker.Length; i++) {
                if (seeker[i] != sequence[position + i]) return false;
            }

            return true;
        }
        /// <summary>
        /// Straightly edits binaries of the current .exe
        /// </summary>
        public static void EditHEX(string targetFile, string resultFile, List<_Replacer> toReplace) {

            byte[] binaries = File.ReadAllBytes(targetFile);
            
            foreach (_Replacer _ in toReplace) {

                byte[] seeker = GetByteArray(_.Search);
                byte[] hider = GetByteArray(_.Replace);
                // from 2.10kk
                // "f8f8f8" -> "000000" good
                // "ffffff" -> "c12120" bad
                // to 2.15kk

                //0kk

                //1kk
                // from 500k to 700k nothing
                // less 500k -> not working

                // from 1.7kk
                // "f8f8f8" -> "424242" good
                // ffffff -> 424242 good
                // c5c5c5 -> 212121 bad
                // new drawing test -> crash
                // to 4kk

                // from 2.1kk
                // "f8f8f8" -> "424242" good
                // ffffff -> 424242 medium, not all fff recolored
                // c5c5c5 -> 212121 bad
                // "000000" -> "F5F5F5" crash
                // new drawing test -> good
                // to 2.3kk

                // from 2260000
                // "000000" -> "F5F5F5" bad
                // to 2470410
                for (int i = 0; i < binaries.Length; i++) {
                    
                    if (!ContainsHEX(binaries, i, seeker)) continue;
                    
                    // Console.WriteLine(i.ToString() + " " + new StringBuilder().Append(binaries.Skip(i).Take(23).Select(x => (char)x).ToArray()).ToString());
                    // 2085392 = .data header begins
                    // Probably pallete:
                    
                    // C0C0C0
                    // FF3050 
                    // D0D0D0
                    // 204080
                    // E0E0E0
                    // F8F8F8
                    // 90B0E8

                    // 808080
                    
                    // 0800F9 FF?
                    // E9FFE9 FF?
                    // 0100E9 FF?
                    for (int j = 2085392; j < 2084909; j++) {
                        binaries[i + j] = hider[j];
                    }
                }
            }

            _Console.Write($"left gap => {left} right gap => {right}", ConsoleColor.Blue);

            File.WriteAllBytes(resultFile, binaries);
        }
    }
}