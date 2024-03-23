namespace YumToolkit.Core.Data {
    /// <summary>
    /// You can work on this class to add branch of a new colors, but make sure, it has 4 RGBA channels [ 0 - 255 ].
    /// Alpha channel [ A ] is used for sequences separation.
    /// Brush's buttons and parts of the scrollable UI can't be colored in any color beyond the grey space color palette ;;
    /// But I can be wrong so, you can repair this shit, if you know reverse engineering better than me...
    /// </summary>
    class _Color {
        public static _Color Get { get; private set; }
        public byte[] Primary { get; set; } = [];
        public byte[] Secondary { get; set; } = [];
        public byte[] Ternary { get; set; } = [];
        public byte[] Text { get; set; } = [];

        // Default colors
        /// <summary>
        /// # F2 F2 F2 00
        /// </summary>
        public byte[] DefaultColor1 { get; private set; } = [];
        /// <summary>
        /// # F4 F4 F4 00
        /// </summary>
        public byte[] DefaultColor2 { get; private set; } = [];
        /// <summary>
        /// # E4 E4 E4 00
        /// </summary>
        public byte[] DefaultColor3 { get; private set; } = [];
        /// <summary>
        /// # E0 E0 E0 00
        /// </summary>
        public byte[] DefaultColor4 { get; private set; } = [];
        /// <summary>
        /// # E8 E8 E8 00
        /// </summary>
        public byte[] DefaultColor5 { get; private set; } = [];
        /// <summary>
        /// # F0 F0 F0 00
        /// </summary>
        public byte[] DefaultColor6 { get; private set; } = [];
        /// <summary>
        /// # F8 F8 F8 00
        /// </summary>
        public byte[] DefaultColor7 { get; private set; } = [];
        /// <summary>
        /// # DA DA DA 00
        /// </summary>
        public byte[] DefaultColor8 { get; private set; } = [];
        /// <summary>
        /// # EE EE EE 00
        /// </summary>
        public byte[] DefaultColor9 { get; private set; } = [];
        /// <summary>
        /// # F0 F0 F0 F0
        /// </summary>
        public byte[] DefaultColor10 { get; private set; } = [];
        /// <summary>
        /// # F8 F8 F8 F8
        /// </summary>
        public byte[] DefaultColor11 { get; private set; } = [];
        /// <summary>
        /// # F0 F0 F0 00
        /// </summary>
        public byte[] DefaultColor12 { get; private set; } = [];
        /// <summary>
        /// # AC AC AC AC
        /// </summary>
        public byte[] DefaultColor13 { get; private set; } = [];
        /// <summary>
        /// # C6 C6 C6
        /// </summary>
        public byte[] DefaultColor14 { get; private set; } = [];
        /// <summary>
        /// # E8 E8 E8
        /// </summary>
        public byte[] DefaultColor15 { get; private set; } = [];
        /// <summary>
        /// # B1 B1 B1
        /// </summary>
        public byte[] DefaultColor16 { get; private set; } = [];
        /// <summary>
        /// # B0 B0 B0
        /// </summary>
        public byte[] DefaultColor17 { get; private set; } = [];
        /// <summary>
        /// # B4 B4 B4
        /// </summary>
        public byte[] DefaultColor18 { get; private set; } = [];
        /// <summary>
        /// # D4 D4 D4
        /// </summary>
        public byte[] DefaultColor19 { get; private set; } = [];
        /// <summary>
        /// # DE DE DE
        /// </summary>
        public byte[] DefaultColor20 { get; private set; } = [];
        /// <summary>
        /// # F8 F8 F8
        /// </summary>
        public byte[] DefaultColor21 { get; private set; } = [];
        /// <summary>
        /// # FF FF FF FF
        /// </summary>
        public byte[] DefaultColor22 { get; private set; } = [];
        /// <summary>
        /// # 20 40 80 00
        /// </summary>
        public byte[] DefaultColor23 { get; private set; } = [];


        static _Color() {
            
            Get = new _Color {
                Primary = [ 32, 32, 32, 32 ],
                Secondary = [ 48, 48, 48, 48 ],
                Ternary = [ 80, 80, 80, 80],
                Text = [ 0, 0, 0, 0 ],

                // Default colors
                DefaultColor1 = [ 242, 242, 242, 0 ],
                DefaultColor2 = [ 244, 244, 244, 0 ],
                DefaultColor3 = [ 228, 228, 228, 0 ],
                DefaultColor4 = [ 224, 224, 224, 0 ],
                DefaultColor5 = [ 232, 232, 232, 0 ],
                DefaultColor6 = [ 240, 240, 240, 0 ],
                DefaultColor7 = [ 248, 248, 248, 0 ],
                DefaultColor8 = [ 218, 218, 218, 0 ],
                DefaultColor9 = [ 238, 238, 238, 0 ],
                DefaultColor10 = [ 240, 240, 240, 240 ],
                DefaultColor11 = [ 248, 248, 248, 248 ],
                DefaultColor12 = [ 240, 240, 240, 0 ],
                DefaultColor13 = [ 172, 172, 172, 172 ],
                DefaultColor14 = [ 198, 198, 198 ],
                DefaultColor15 = [ 232, 232, 232 ],
                DefaultColor16 = [ 177, 177, 177 ],
                DefaultColor17 = [ 176, 176, 176 ],
                DefaultColor18 = [ 180, 180, 180 ],
                DefaultColor19 = [ 216, 216, 216 ],
                DefaultColor20 = [ 222, 222, 222 ],
                DefaultColor21 = [ 248, 248, 248 ],
                DefaultColor22 = [ 255, 255, 255, 255],
                DefaultColor23 = [ 32, 64, 128, 0 ],
            };

            

        }
    }
}