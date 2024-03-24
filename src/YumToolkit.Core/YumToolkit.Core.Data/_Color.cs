using YumToolkit.Core.Interfaces;

namespace YumToolkit.Core.Data {
    /// <summary>
    /// You can work on this class to add branch of a new colors, but make sure, it has 4 RGBA channels [ 0 - 255 ].
    /// Alpha channel [ A ] is used for sequences separation.
    /// Brush's buttons and parts of the scrollable UI can't be colored in any color beyond the grey space color palette ;;
    /// But I can be wrong so, you can repair this shit, if you know reverse engineering better than me...
    /// </summary>
    class _Color : IColor {
        public byte[] Primary { get; set; }
        public byte[] Secondary { get; set; }
        public byte[] Ternary { get; set; }
        public byte[] Text { get; set; }

        // Default colors
        /// <summary>
        /// # F2 F2 F2 00
        /// </summary>
        public byte[] Default1 { get; }
        /// <summary>
        /// # F4 F4 F4 00
        /// </summary>
        public byte[] Default2 { get; }
        /// <summary>
        /// # E4 E4 E4 00
        /// </summary>
        public byte[] Default3 { get; }
        /// <summary>
        /// # E0 E0 E0 00
        /// </summary>
        public byte[] Default4 { get; }
        /// <summary>
        /// # E8 E8 E8 00
        /// </summary>
        public byte[] Default5 { get; }
        /// <summary>
        /// # F0 F0 F0 00
        /// </summary>
        public byte[] Default6 { get; }
        /// <summary>
        /// # F8 F8 F8 00
        /// </summary>
        public byte[] Default7 { get; }
        /// <summary>
        /// # DA DA DA 00
        /// </summary>
        public byte[] Default8 { get; }
        /// <summary>
        /// # EE EE EE 00
        /// </summary>
        public byte[] Default9 { get; }
        /// <summary>
        /// # F0 F0 F0 F0
        /// </summary>
        public byte[] Default10 { get; }
        /// <summary>
        /// # F8 F8 F8 F8
        /// </summary>
        public byte[] Default11 { get; }
        /// <summary>
        /// # F0 F0 F0 00
        /// </summary>
        public byte[] Default12 { get; }
        /// <summary>
        /// # AC AC AC AC
        /// </summary>
        public byte[] Default13 { get; }
        /// <summary>
        /// # C6 C6 C6
        /// </summary>
        public byte[] Default14 { get; }
        /// <summary>
        /// # E8 E8 E8
        /// </summary>
        public byte[] Default15 { get; }
        /// <summary>
        /// # B1 B1 B1
        /// </summary>
        public byte[] Default16 { get; }
        /// <summary>
        /// # B0 B0 B0
        /// </summary>
        public byte[] Default17 { get; }
        /// <summary>
        /// # B4 B4 B4
        /// </summary>
        public byte[] Default18 { get; }
        /// <summary>
        /// # D4 D4 D4
        /// </summary>
        public byte[] Default19 { get; }
        /// <summary>
        /// # DE DE DE
        /// </summary>
        public byte[] Default20 { get; }
        /// <summary>
        /// # F8 F8 F8
        /// </summary>
        public byte[] Default21 { get; }
        /// <summary>
        /// # FF FF FF FF
        /// </summary>
        public byte[] Default22 { get; }
        /// <summary>
        /// # 20 40 80 00
        /// </summary>
        public byte[] Default23 { get; }


        /// <summary>
        /// # FF DB DB
        /// </summary>
        public byte[] SelectedElementDefault1 { get; }
        /// <summary>
        /// # FF D4 D4
        /// </summary>
        public byte[] SelectedElementDefault2 { get; }
        /// <summary>
        /// # FF F6 F6
        /// </summary>
        public byte[] SelectedElementDefault3 { get; }
        /// <summary>
        /// # FF 80 80
        /// </summary>
        public byte[] SelectedElementDefault4 { get; }
        /// <summary>
        /// # FF C2 C2
        /// </summary>
        public byte[] SelectedElementDefault5 { get; }
        /// <summary>
        /// # FF CF CF
        /// </summary>
        public byte[] SelectedElementDefault6 { get; }
        /// <summary>
        /// # FF D4 EC
        /// </summary>
        public byte[] SelectedElementDefault7 { get; }
        /// <summary>
        /// # FF 66 B5
        /// </summary>
        public byte[] SelectedElementDefault8 { get; }
        /// <summary>
        /// # FF BF E4
        /// </summary>
        public byte[] SelectedElementDefault9 { get; }
        /// <summary>
        /// # FF A6 A6
        /// </summary>
        public byte[] SelectedElementDefault10 { get; }
        /// <summary>
        /// # FF 8E 8E
        /// </summary>
        public byte[] SelectedElementDefault11 { get; }
        /// <summary>
        /// # F9 DF DF
        /// </summary>
        public byte[] SelectedElementDefault12 { get; }
        /// <summary>
        /// # F9 E4 E4
        /// </summary>
        public byte[] SelectedElementDefault13 { get; }
        /// <summary>
        /// # FF D4 EC
        /// </summary>
        public byte[] SelectedElementDefault14 { get; }
        /// <summary>
        /// # FF 66 B5
        /// </summary>
        public byte[] SelectedElementDefault15 { get; }
        /// <summary>
        /// # FF BF E4
        /// </summary>
        public byte[] SelectedElementDefault16 { get; }

        // TODO: REPLACE ALL RGBA BYTE COLORS WITH HEX TO ABGR CONVERTER SUCH AS APPHELPER.CS HAS
        // ThemeColors["Primary"].toByteColor(); where ThemeColors["Primary"] => string.
        public _Color() {
            Primary = [ 32, 32, 32, 32 ];
            Secondary = [ 48, 48, 48, 48 ];
            Ternary = [ 80, 80, 80, 80];
            Text = [ 0, 0, 0, 0 ];

            // Default colors
            Default1 = [ 242, 242, 242, 0 ];
            Default2 = [ 244, 244, 244, 0 ];
            Default3 = [ 228, 228, 228, 0 ];
            Default4 = [ 224, 224, 224, 0 ];
            Default5 = [ 232, 232, 232, 0 ];
            Default6 = [ 240, 240, 240, 0 ];
            Default7 = [ 248, 248, 248, 0 ];
            Default8 = [ 218, 218, 218, 0 ];
            Default9 = [ 238, 238, 238, 0 ];
            Default10 = [ 240, 240, 240, 240 ];
            Default11 = [ 248, 248, 248, 248 ];
            Default12 = [ 240, 240, 240, 0 ];
            Default13 = [ 172, 172, 172, 172 ];
            Default14 = [ 198, 198, 198 ];
            Default15 = [ 232, 232, 232 ];
            Default16 = [ 177, 177, 177 ];
            Default17 = [ 176, 176, 176 ];
            Default18 = [ 180, 180, 180 ];
            Default19 = [ 216, 216, 216 ];
            Default20 = [ 222, 222, 222 ];
            Default21 = [ 248, 248, 248 ];
            Default22 = [ 255, 255, 255, 255];
            Default23 = [ 32, 64, 128, 0 ];

            SelectedElementDefault1 = [ 255, 219, 219 ];
            SelectedElementDefault2 = [ 255, 212, 212 ];
            SelectedElementDefault3 = [ 255, 246, 246 ];
            SelectedElementDefault4 = [ 255, 128, 128 ];
            SelectedElementDefault5 = [ 255, 194, 194 ];
            SelectedElementDefault6 = [ 255, 207, 207 ];
            SelectedElementDefault7 = [ 255, 212, 236 ];
            SelectedElementDefault8 = [ 255, 102, 181 ];
            SelectedElementDefault9 = [ 255, 191, 228 ];
            SelectedElementDefault10 = [ 255, 166, 166 ];
            SelectedElementDefault11 = [ 255, 142, 142 ];
            SelectedElementDefault12 = [ 249, 223, 223 ];
            SelectedElementDefault13 = [ 249, 228, 228 ];
            SelectedElementDefault14 = [ 255, 212, 236 ];
            SelectedElementDefault15 = [ 255, 102, 181 ];
            SelectedElementDefault16 = [ 255, 191, 228 ];
        }
    }
}