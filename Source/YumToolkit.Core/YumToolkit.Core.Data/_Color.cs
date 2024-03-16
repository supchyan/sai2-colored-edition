namespace YumToolkit.Core.Data {
    /// <summary>
    /// You can edit this class to add branch of a new colors,
    /// but make sure, it has 4 RGBA channels [ 0 - 255 ]
    /// Alpha channel [ A ] is for bytes separation, but highly necessary.
    /// Be sure to make it always equal to 0.
    /// </summary>
    public class _Color {
        public static _Color color = new _Color();
        public byte[] Primary { get; }
        public byte[] Secondary { get; }
        public _Color() {
            Primary = [ 25, 25, 25, 0 ];
            Secondary = [ 52, 52, 52, 0 ];
        }
    }
}