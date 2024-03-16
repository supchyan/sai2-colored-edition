namespace YumToolkit._ {
    public static class _Extensions {
        /// <summary>
        /// Converts HEX address to decimal form.
        /// </summary>
        public static int GetDecimalAddress(this string hex_address) {
            return int.Parse(hex_address.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);
        }
    }
}