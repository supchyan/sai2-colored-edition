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
        /// #F2F2F200
        /// </summary>
        public static byte[] DefaultColor1 { get; }
        /// <summary>
        /// #F4F4F400
        /// </summary>
        public static byte[] DefaultColor2 { get; }
        /// <summary>
        /// #E4E4E400
        /// </summary>
        public static byte[] DefaultColor3 { get; }
        /// <summary>
        /// #E0E0E000
        /// </summary>
        public static byte[] DefaultColor4 { get; }
        /// <summary>
        /// #E8E8E800
        /// </summary>
        public static byte[] DefaultColor5 { get; }
        /// <summary>
        /// #F0F0F000
        /// </summary>
        public static byte[] DefaultColor6 { get; }
        /// <summary>
        /// #F8F8F800
        /// </summary>
        public static byte[] DefaultColor7 { get; }
        /// <summary>
        /// #DADADA00
        /// </summary>
        public static byte[] DefaultColor8 { get; }
        /// <summary>
        /// #EEEEEE00
        /// </summary>
        public static byte[] DefaultColor9 { get; }
        /// <summary>
        /// #F0F0F0F0
        /// </summary>
        public static byte[] DefaultColor10 { get; }
        /// <summary>
        /// #F8F8F8F8
        /// </summary>
        public static byte[] DefaultColor11 { get; }
        /// <summary>
        /// #F0F0F000
        /// </summary>
        public static byte[] DefaultColor12 { get; }
        /// <summary>
        /// #ACACACAC
        /// </summary>
        public static byte[] DefaultColor13 { get; }
        /// <summary>
        /// #FFFF30
        /// </summary>
        public static byte[] DefaultColor14 { get; }
        /// <summary>
        /// #30FFFF
        /// </summary>
        public static byte[] DefaultColor15 { get; }
        /// <summary>
        /// #F83030
        /// </summary>
        public static byte[] DefaultColor16 { get; }
        /// <summary>
        /// 3030F8
        /// </summary>
        public static byte[] DefaultColor17 { get; }
        /// <summary>
        /// F8F830
        /// </summary>
        public static byte[] DefaultColor18 { get; }
        /// <summary>
        /// #30F8F8
        /// </summary>
        public static byte[] DefaultColor19 { get; }
        

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

            // Artefacts fix
            DefaultColor14 = [ 255, 255, 48 ];
            DefaultColor15 = [ 48, 255, 255 ];
            DefaultColor16 = [ 248, 48, 48 ];
            DefaultColor17 = [ 48, 248, 48 ];
            DefaultColor18 = [ 255, 255, 48 ];
            DefaultColor19 = [ 48, 255, 255 ];
        }
    }
}