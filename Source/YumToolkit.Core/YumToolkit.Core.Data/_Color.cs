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
        public static byte[] Test { get; }
        static _Color() {
            Primary = [ 32, 32, 32, 0 ];
            Secondary = [ 48, 48, 48, 0 ];
            Elements = [ 80, 80, 80, 0];
            LightGrey = [ 238, 238, 238, 0 ];
            Test = [ 0, 0, 0, 0 ];
        }
    }
}