namespace YumToolkit.Core.Data {
    /// <summary>
    /// You can work on this class to add branch of a new colors, but make sure, it has 4 RGBA channels [ 0 - 255 ].
    /// Alpha channel [ A ] is used for sequences separation.
    /// Brush's buttons and parts of the scrollable UI can't be colored in any color beyond the grey space color palette ;;
    /// But I can be wrong so, you can repair this shit, if you know reverse engineering better than me...
    /// </summary>
    public static class _Color {
        public static byte[] Primary { get; }
        public static byte[] Secondary { get; }
        public static byte[] Elements { get; }
        public static byte[] LightGrey { get; }
        public static byte[] Green { get; }
        public static byte[] Black { get; }
        public static byte[] White { get; }

        // Default colors
        /// <summary>
        /// # F2 F2 F2 00
        /// </summary>
        public static byte[] DefaultColor1 { get; }
        /// <summary>
        /// # F4 F4 F4 00
        /// </summary>
        public static byte[] DefaultColor2 { get; }
        /// <summary>
        /// # E4 E4 E4 00
        /// </summary>
        public static byte[] DefaultColor3 { get; }
        /// <summary>
        /// # E0 E0 E0 00
        /// </summary>
        public static byte[] DefaultColor4 { get; }
        /// <summary>
        /// # E8 E8 E8 00
        /// </summary>
        public static byte[] DefaultColor5 { get; }
        /// <summary>
        /// # F0 F0 F0 00
        /// </summary>
        public static byte[] DefaultColor6 { get; }
        /// <summary>
        /// # F8 F8 F8 00
        /// </summary>
        public static byte[] DefaultColor7 { get; }
        /// <summary>
        /// # DA DA DA 00
        /// </summary>
        public static byte[] DefaultColor8 { get; }
        /// <summary>
        /// # EE EE EE 00
        /// </summary>
        public static byte[] DefaultColor9 { get; }
        /// <summary>
        /// # F0 F0 F0 F0
        /// </summary>
        public static byte[] DefaultColor10 { get; }
        /// <summary>
        /// # F8 F8 F8 F8
        /// </summary>
        public static byte[] DefaultColor11 { get; }
        /// <summary>
        /// # F0 F0 F0 00
        /// </summary>
        public static byte[] DefaultColor12 { get; }
        /// <summary>
        /// # AC AC AC AC
        /// </summary>
        public static byte[] DefaultColor13 { get; }
        /// <summary>
        /// # C6 C6 C6
        /// </summary>
        public static byte[] DefaultColor14 { get; }
        /// <summary>
        /// # E8 E8 E8
        /// </summary>
        public static byte[] DefaultColor15 { get; }
        /// <summary>
        /// # B1 B1 B1
        /// </summary>
        public static byte[] DefaultColor16 { get; }
        /// <summary>
        /// # B0 B0 B0
        /// </summary>
        public static byte[] DefaultColor17 { get; }
        /// <summary>
        /// # B4 B4 B4
        /// </summary>
        public static byte[] DefaultColor18 { get; }
        /// <summary>
        /// # D4 D4 D4
        /// </summary>
        public static byte[] DefaultColor19 { get; }
        /// <summary>
        /// # DE DE DE
        /// </summary>
        public static byte[] DefaultColor20 { get; }
        /// <summary>
        /// # F8 F8 F8
        /// </summary>
        public static byte[] DefaultColor21 { get; }



        /// <summary>
        /// # FF FF Elements[0]
        /// </summary>
        public static byte[] ArtefactsColor1 { get; }
        /// <summary>
        /// # Elements[0] FF FF
        /// </summary>
        public static byte[] ArtefactsColor2 { get; }
        /// <summary>
        /// # F8 Elements[0] Elements[0]
        /// </summary>
        public static byte[] ArtefactsColor3 { get; }
        /// <summary>
        /// # Elements[0] Elements[0] F8
        /// </summary>
        public static byte[] ArtefactsColor4 { get; }
        /// <summary>
        /// # F8 F8 Elements[0]
        /// </summary>
        public static byte[] ArtefactsColor5 { get; }
        /// <summary>
        /// # Elements[0] F8 F8
        /// </summary>
        public static byte[] ArtefactsColor6 { get; }
        /// <summary>
        /// # F8 F8 Elements[0]
        /// </summary>
        public static byte[] ArtefactsColor7 { get; }
        /// <summary>
        /// # Elements[0] Elements[0] F8
        /// </summary>
        public static byte[] ArtefactsColor8 { get; }
        

        static _Color() {
            Primary = [ 32, 32, 32, 32 ];
            Secondary = [ 48, 48, 48, 48 ];
            Elements = [ 80, 80, 80, 80];
            LightGrey = [ 238, 238, 238, 238 ];
            Green = [ 100, 150, 100, 0 ];
            Black = [ 0, 0, 0, 0 ];
            White = [ 255, 255, 255, 255 ];

            // Default colors
            DefaultColor1 = [ 242, 242, 242, 0 ];
            DefaultColor2 = [ 244, 244, 244, 0 ];
            DefaultColor3 = [ 228, 228, 228, 0 ];
            DefaultColor4 = [ 224, 224, 224, 0 ];
            DefaultColor5 = [ 232, 232, 232, 0 ];
            DefaultColor6 = [ 240, 240, 240, 0 ];
            DefaultColor7 = [ 248, 248, 248, 0 ];
            DefaultColor8 = [ 218, 218, 218, 0 ];
            DefaultColor9 = [ 238, 238, 238, 0 ];
            DefaultColor10 = [ 240, 240, 240, 240 ];
            DefaultColor11 = [ 248, 248, 248, 248 ];
            DefaultColor12 = [ 240, 240, 240, 0 ];
            DefaultColor13 = [ 172, 172, 172, 172 ];
            DefaultColor14 = [ 198, 198, 198 ];
            DefaultColor15 = [ 232, 232, 232 ];
            DefaultColor16 = [ 177, 177, 177 ];
            DefaultColor17 = [ 176, 176, 176 ];
            DefaultColor18 = [ 180, 180, 180 ];
            DefaultColor19 = [ 216, 216, 216 ];
            DefaultColor20 = [ 222, 222, 222 ];
            DefaultColor21 = [ 248, 248, 248 ];

            // Artefacts fix
            ArtefactsColor1 = [ 255, 255, Elements[0] ];
            ArtefactsColor2 = [ Elements[0], 255, 255 ];
            ArtefactsColor3 = [ 248, Elements[0], Elements[0] ];
            ArtefactsColor4 = [ Elements[0], 248, 248 ];
            ArtefactsColor5 = [ 255, 255, Elements[0] ];
            ArtefactsColor6 = [ Elements[0], 255, 255 ];
            ArtefactsColor7 = [ 248, 248, Elements[0] ];
            ArtefactsColor8 = [ Elements[0], Elements[0], 248 ];
        }
    }
}