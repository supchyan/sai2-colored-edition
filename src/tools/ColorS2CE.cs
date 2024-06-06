using S2CE.Extensions;

namespace S2CE.Tools
{
    class ColorS2CE {
        /// <summary>
        /// # FF FF Ternary[0]
        /// </summary>
        public byte[] TernaryArtifactsColor1 { get; set; }
        /// <summary>
        /// # Ternary[0] FF FF
        /// </summary>
        public byte[] TernaryArtifactsColor2 { get; set; }
        /// <summary>
        /// # F8 Ternary[0] Ternary[0]
        /// </summary>
        public byte[] TernaryArtifactsColor3 { get; set; }
        /// <summary>
        /// # Ternary[0] Ternary[0] F8
        /// </summary>
        public byte[] TernaryArtifactsColor4 { get; set; }
        /// <summary>
        /// # F8 F8 Ternary[0]
        /// </summary>
        public byte[] TernaryArtifactsColor5 { get; set; }
        /// <summary>
        /// # Ternary[0] F8 F8
        /// </summary>
        public byte[] TernaryArtifactsColor6 { get; set; }
        /// <summary>
        /// # F8 F8 Ternary[0]
        /// </summary>
        public byte[] TernaryArtifactsColor7 { get; set; }
        /// <summary>
        /// # Ternary[0] Ternary[0] F8
        /// </summary>
        public byte[] TernaryArtifactsColor8 { get; set; }
        /// <summary>
        /// # F8 F8 Secondary[0]
        /// </summary>
        public byte[] SecondaryArtifactsColor1 { get; set; }
        /// <summary>
        /// # Secondary[0] F8 F8
        /// </summary>
        public byte[] SecondaryArtifactsColor2 { get; set; }
        /// <summary>
        /// # F8 Secondary[0] Secondary[0]
        /// </summary>
        public byte[] SecondaryArtifactsColor3 { get; set; }
        /// <summary>
        /// # Secondary[0] Secondary[0] F8 
        /// </summary>
        public byte[] SecondaryArtifactsColor4 { get; set; }
        

        public ColorS2CE() {
            // Artifacts fix
            TernaryArtifactsColor1 = [];
            TernaryArtifactsColor2 = [];
            TernaryArtifactsColor3 = [];
            TernaryArtifactsColor4 = [];
            TernaryArtifactsColor5 = [];
            TernaryArtifactsColor6 = [];
            TernaryArtifactsColor7 = [];
            TernaryArtifactsColor8 = [];
            SecondaryArtifactsColor1 = [];
            SecondaryArtifactsColor2 = [];
            SecondaryArtifactsColor3 = [];
            SecondaryArtifactsColor4 = [];
        }
        // // TODO: 
        // public void ConfigureRGBColors(Dictionary<string, byte[]> clone_from, Dictionary<string, byte[]> clone_to) {
        //     foreach(var pair in clone_from) {
        //         clone_to[pair.Key] = clone_from[pair.Key].NoAlpha();
        //     }
        // }
        public void ConfigureArtifactsColors(byte[] secondary, byte[] ternary) {
            string s = secondary.toHEXColor();
            s = $"{s[0]}{s[1]}";
            string t = ternary.toHEXColor();
            t = $"{t[0]}{t[1]}";

            SecondaryArtifactsColor1 = $"#00F8F8{s}".toByteColor().NoAlpha();
            SecondaryArtifactsColor2 = $"#00{s}F8F8".toByteColor().NoAlpha();
            SecondaryArtifactsColor3 = $"#00F8{s}{s}".toByteColor().NoAlpha();
            SecondaryArtifactsColor4 = $"#00{s}{s}F8".toByteColor().NoAlpha();
            TernaryArtifactsColor1 = $"#00FFFF{t}".toByteColor().NoAlpha();
            TernaryArtifactsColor2 = $"#00{t}FFFF".toByteColor().NoAlpha();
            TernaryArtifactsColor3 = $"#00FF{t}{t}".toByteColor().NoAlpha();
            TernaryArtifactsColor4 = $"#00{t}{t}FF".toByteColor().NoAlpha();
            TernaryArtifactsColor5 = $"#00F8F8{t}".toByteColor().NoAlpha();
            TernaryArtifactsColor6 = $"#00{t}F8F8".toByteColor().NoAlpha();
            TernaryArtifactsColor7 = $"#00F8{t}{t}".toByteColor().NoAlpha();
            TernaryArtifactsColor8 = $"#00{t}{t}F8".toByteColor().NoAlpha();
        }
    }
}