using YumToolkit.Global;
using YumToolkit.Core.Interfaces;

namespace YumToolkit.Core.Data {
    class _SemiColor : _Globals, ISemiColor {
        public byte[] SecondaryRGB { get; set; }
        public byte[] TernaryRGB { get; set; }
        /// <summary>
        /// # FF FF Ternary[0]
        /// </summary>
        public byte[] ArtifactsColor1 { get; }
        /// <summary>
        /// # Ternary[0] FF FF
        /// </summary>
        public byte[] ArtifactsColor2 { get; }
        /// <summary>
        /// # F8 Ternary[0] Ternary[0]
        /// </summary>
        public byte[] ArtifactsColor3 { get; }
        /// <summary>
        /// # Ternary[0] Ternary[0] F8
        /// </summary>
        public byte[] ArtifactsColor4 { get; }
        /// <summary>
        /// # F8 F8 Ternary[0]
        /// </summary>
        public byte[] ArtifactsColor5 { get; }
        /// <summary>
        /// # Ternary[0] F8 F8
        /// </summary>
        public byte[] ArtifactsColor6 { get; }
        /// <summary>
        /// # F8 F8 Ternary[0]
        /// </summary>
        public byte[] ArtifactsColor7 { get; }
        /// <summary>
        /// # Ternary[0] Ternary[0] F8
        /// </summary>
        public byte[] ArtifactsColor8 { get; }

        public _SemiColor() {
            SecondaryRGB = color.Secondary.NoAlpha();
            TernaryRGB = color.Ternary.NoAlpha();

            // Artifacts fix
            ArtifactsColor1 = [ 255, 255, color.Ternary[0] ];
            ArtifactsColor2 = [ color.Ternary[0], 255, 255 ];
            ArtifactsColor3 = [ 248, color.Ternary[0], color.Ternary[0] ];
            ArtifactsColor4 = [ color.Ternary[0], 248, 248 ];
            ArtifactsColor5 = [ 255, 255, color.Ternary[0] ];
            ArtifactsColor6 = [ color.Ternary[0], 255, 255 ];
            ArtifactsColor7 = [ 248, 248, color.Ternary[0] ];
            ArtifactsColor8 = [ color.Ternary[0], color.Ternary[0], 248 ];
        }
    }
}