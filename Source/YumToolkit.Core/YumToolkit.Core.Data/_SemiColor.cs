using YumToolkit.Global;

namespace YumToolkit.Core.Data {
    class _SemiColor {
        public static _SemiColor Get { get; private set; }
        public byte[] SecondaryRGB { get; set; } = [];
        public byte[] TernaryRGB { get; set; } = [];
        /// <summary>
        /// # FF FF Ternary[0]
        /// </summary>
        public byte[] ArtifactsColor1 { get; private set; } = [];
        /// <summary>
        /// # Ternary[0] FF FF
        /// </summary>
        public byte[] ArtifactsColor2 { get; private set; } = [];
        /// <summary>
        /// # F8 Ternary[0] Ternary[0]
        /// </summary>
        public byte[] ArtifactsColor3 { get; private set; } = [];
        /// <summary>
        /// # Ternary[0] Ternary[0] F8
        /// </summary>
        public byte[] ArtifactsColor4 { get; private set; } = [];
        /// <summary>
        /// # F8 F8 Ternary[0]
        /// </summary>
        public byte[] ArtifactsColor5 { get; private set; } = [];
        /// <summary>
        /// # Ternary[0] F8 F8
        /// </summary>
        public byte[] ArtifactsColor6 { get; private set; } = [];
        /// <summary>
        /// # F8 F8 Ternary[0]
        /// </summary>
        public byte[] ArtifactsColor7 { get; private set; } = [];
        /// <summary>
        /// # Ternary[0] Ternary[0] F8
        /// </summary>
        public byte[] ArtifactsColor8 { get; private set; } = [];

        static _SemiColor() {
            Get = new _SemiColor {
                SecondaryRGB = _Color.Get.Secondary.NoAlpha(),
                TernaryRGB = _Color.Get.Ternary.NoAlpha(),

                // Artifacts fix
                ArtifactsColor1 = [ 255, 255, _Color.Get.Ternary[0] ],
                ArtifactsColor2 = [ _Color.Get.Ternary[0], 255, 255 ],
                ArtifactsColor3 = [ 248, _Color.Get.Ternary[0], _Color.Get.Ternary[0] ],
                ArtifactsColor4 = [ _Color.Get.Ternary[0], 248, 248 ],
                ArtifactsColor5 = [ 255, 255, _Color.Get.Ternary[0] ],
                ArtifactsColor6 = [ _Color.Get.Ternary[0], 255, 255 ],
                ArtifactsColor7 = [ 248, 248, _Color.Get.Ternary[0] ],
                ArtifactsColor8 = [ _Color.Get.Ternary[0], _Color.Get.Ternary[0], 248 ],
            };
        }
    }
}