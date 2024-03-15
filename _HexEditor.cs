using System.Text;

namespace drak_mode_sai2 {
    public class _HexEditor {
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
        public static void EditHEX(List<_Replacer> toReplace, int from, int to) {

            byte[] binaries = File.ReadAllBytes("sai.old.exe");
            
            foreach (_Replacer _ in toReplace) {

                byte[] seeker = GetByteArray(_.Search);
                byte[] hider = GetByteArray(_.Replace);
                
                for (int i = from; i < to; i++) {
                    
                    if (!ContainsHEX(binaries, i, seeker)) continue;
                    
                    for (int j = from; j < to; j++) {
                        binaries[i + j] = hider[j];
                    }
                }
            }

            _Console.Write($"all good.", ConsoleColor.Blue);

            File.WriteAllBytes("sai2.exe", binaries);
        }
    }
}