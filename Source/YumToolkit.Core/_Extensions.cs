using System.Drawing;

namespace YumToolkit.Core {
    public static class _Extensions {
        /// <summary>
        /// Converts HEX address to decimal one.
        /// </summary>
        public static int GetDecimalAddress(this string hex_address) {
            return int.Parse(hex_address.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);
        }
        public static byte[] toByteArray(this string hex_value) {
            return [
                ColorTranslator.FromHtml(hex_value).R,
                ColorTranslator.FromHtml(hex_value).G,
                ColorTranslator.FromHtml(hex_value).B,
                ColorTranslator.FromHtml(hex_value).A
            ];
        }
        public static byte[] NoAlpha(this byte[] col) {
            return [col[1],col[2],col[3]];
        }
    }
}