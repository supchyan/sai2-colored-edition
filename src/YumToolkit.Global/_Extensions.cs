using System.Drawing;

namespace YumToolkit.Global {
    static class _Extensions {
        /// <summary>
        /// Converts HEX address to decimal one.
        /// </summary>
        public static int GetDecimalAddress(this string hex_address) {
            return int.Parse(hex_address.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);
        }
        public static byte[] toByteColor(this string hex_value) {

            // RGBA in SAI2 is BGRA. Live your life with that.
            // Also... Some BGRA sequences actually is ABGR
            // and i've no fkn~ clue, how to figure it out! ^^
            return [
                ColorTranslator.FromHtml(hex_value).B,
                ColorTranslator.FromHtml(hex_value).G,
                ColorTranslator.FromHtml(hex_value).R,
                ColorTranslator.FromHtml(hex_value).A,
            ];
        }
        public static string toHEXColor(this byte[] byte_value) {
            return BitConverter.ToString(byte_value).Replace("-", string.Empty);
        }
        public static byte[] NoAlpha(this byte[] c) {
            return [ c[0], c[1], c[2] ];
        }
    }
}