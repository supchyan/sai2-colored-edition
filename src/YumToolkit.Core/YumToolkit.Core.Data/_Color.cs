using YumToolkit.Core.Interfaces;
using YumToolkit.Global;

namespace YumToolkit.Core.Data {
    /// <summary>
    /// Read colors and addresses.md before modifying this!
    /// </summary>
    class _Color : IColor {
        // Customizable colors
        public byte[] Primary { get; set; }
        public byte[] Secondary { get; set; }
        public byte[] Ternary { get; set; }
        public byte[] Text { get; set; }
        public byte[] SelectablePrimary { get; set; }
        public byte[] SelectableSecondary { get; set; }

        // Sequences replacement colors
        /// <summary>
        /// # F2 F2 F2 00
        /// </summary>
        public byte[] BurgerButtonsOutline1 { get; }
        /// <summary>
        /// # F4 F4 F4 00
        /// </summary>
        public byte[] BurgerButtonsOutline2 { get; }
        /// <summary>
        /// # E4 E4 E4 00
        /// </summary>
        public byte[] BurgerButtonsOutline3 { get; }
        /// <summary>
        /// # E0 E0 E0 00
        /// </summary>
        public byte[] BurgerButtonsOutline4 { get; }
        /// <summary>
        /// # E8 E8 E8 00
        /// </summary>
        public byte[] BurgerButtonsOutlineAndScrollBarBackground { get; }
        /// <summary>
        /// # F0 F0 F0 00
        /// </summary>
        public byte[] InActiveScrollBarsBackground { get; }
        /// <summary>
        /// # F8 F8 F8 00
        /// </summary>
        public byte[] RadioButtonsMaskFixBurgerButtonsBackground { get; }
        /// <summary>
        /// # DA DA DA 00
        /// </summary>
        public byte[] BurgerButtonsOutlineSlidersOutline { get; }
        /// <summary>
        /// # EE EE EE 00
        /// </summary>
        public byte[] BordersFix9 { get; }
        /// <summary>
        /// # F0 F0 F0 F0
        /// </summary>
        public byte[] EmplyElementsInBrushesUI { get; }
        /// <summary>
        /// # F8 F8 F8 F8
        /// </summary>
        public byte[] ColorPickerCircleBody { get; }
        /// <summary>
        /// # AC AC AC AC
        /// </summary>
        public byte[] WhatIsThisColor2 { get; }
        /// <summary>
        /// # C6 C6 C6
        /// </summary>
        public byte[] BordersFix1 { get; }
        /// <summary>
        /// # E8 E8 E8
        /// </summary>
        public byte[] BordersFix2 { get; }
        /// <summary>
        /// # B1 B1 B1
        /// </summary>
        public byte[] BordersFix3 { get; }
        /// <summary>
        /// # B0 B0 B0
        /// </summary>
        public byte[] ActiveCanvasBackgroundFix { get; }
        /// <summary>
        /// # D8 D8 D8
        /// </summary>
        public byte[] BordersFix4 { get; }
        /// <summary>
        /// # B4 B4 B4
        /// </summary>
        public byte[] BordersFix5 { get; }
        /// <summary>
        /// # D4 D4 D4
        /// </summary>
        public byte[] BordersFix6 { get; }
        /// <summary>
        /// # DE DE DE
        /// </summary>
        public byte[] BordersFix7 { get; }
        /// <summary>
        /// # F8 F8 F8
        /// </summary>
        public byte[] BordersFix8 { get; }
        /// <summary>
        /// # F8 F8 F8
        /// </summary>
        public byte[] BurgerButtonsBackground { get; }
        /// <summary>
        /// # FF FF FF FF
        /// </summary>
        public byte[] BrushesBackgroundFileMenuBackgroundScrollBlockBackground { get; }
        /// <summary>
        /// # 00 80 40 20
        /// </summary>
        public byte[] ShitColoredText { get; }
        /// <summary>
        /// # DB DB FF
        /// </summary>
        public byte[] SelectedElementBackgroundIdle { get; }
        /// <summary>
        /// # D4 D4 FF
        /// </summary>
        public byte[] SelectedElementBackgroundActive { get; }
        /// <summary>
        /// # F6 F6 FF
        /// </summary>
        public byte[] SelectedElementBackgroundHovered { get; }
        /// <summary>
        /// # 80 80 FF
        /// </summary>
        public byte[] SelectedElementOutlineNotStated { get; }
        /// <summary>
        /// # C2 C2 FF
        /// </summary>
        public byte[] SelectedElementOutlineHovered { get; }
        /// <summary>
        /// # CF CF FF
        /// </summary>
        public byte[] SelectedElementOutlineIdle { get; }
        /// <summary>
        /// # D4 EC FF
        /// </summary>
        public byte[] SelectedElementOutlineNotFound1 { get; }
        /// <summary>
        /// # 66 B5 FF
        /// </summary>
        public byte[] SelectedElementDefaultNotFound2 { get; }
        /// <summary>
        /// # BF E4 FF
        /// </summary>
        public byte[] SelectedElementDefaultNotFound3 { get; }
        /// <summary>
        /// # A6 A6 FF
        /// </summary>
        public byte[] SelectedElementOutlineFix1 { get; }
        /// <summary>
        /// # 8E 8E FF
        /// </summary>
        public byte[] SelectedElementOutlineFix2 { get; }
        /// <summary>
        /// # DF DF F9
        /// </summary>
        public byte[] SelectedElementOutlineFix3 { get; }
        /// <summary>
        /// # E4 E4 F9
        /// </summary>
        public byte[] SelectedElementOutlineFix5 { get; }
        /// <summary>
        /// # EC FF D4
        /// </summary>
        public byte[] SelectedElementOutlineFix6 { get; }
        /// <summary>
        /// # 66 B5 FF
        /// </summary>
        public byte[] SelectedElementOutlineFix7 { get; }
        /// <summary>
        /// # BF E4 FF
        /// </summary>
        public byte[] SelectedElementOutlineFix8 { get; }
        /// <summary>
        /// # 7A C0 FF
        /// </summary>
        public byte[] SelectedElementOutlineFix9 { get; }
        /// <summary>
        /// # D5 E8 FA
        /// </summary>
        public byte[] SelectedElementOutlineFix10 { get; }
        /// <summary>
        /// # 9C D0 FF
        /// </summary>
        public byte[] SelectedElementOutlineFix11 { get; }

         public _Color() {
            // Depends on theme choice, so values here isn't important
            Primary = [];
            Secondary = [];
            Ternary = [];
            Text = [];
            SelectablePrimary = [];
            SelectableSecondary = [];
            // Constants
            BurgerButtonsOutline1 = "#00F2F2F2".toByteColor();
            BurgerButtonsOutline2 = "#00F4F4F4".toByteColor();
            BurgerButtonsOutline3 = "#00E4E4E4".toByteColor();
            BurgerButtonsOutline4 = "#00E0E0E0".toByteColor();
            BurgerButtonsOutlineAndScrollBarBackground = "#00E8E8E8".toByteColor();
            InActiveScrollBarsBackground = "#F0F0F000".toByteColor();
            RadioButtonsMaskFixBurgerButtonsBackground = "#00F8F8F8".toByteColor();
            BurgerButtonsOutlineSlidersOutline = "#00DADADA".toByteColor();
            EmplyElementsInBrushesUI = "#F0F0F0F0".toByteColor();
            ColorPickerCircleBody = "#F8F8F8F8".toByteColor();
            WhatIsThisColor2 = "#ACACACAC".toByteColor();
            BordersFix1 = "#00C6C6C6".toByteColor().NoAlpha();
            BordersFix2 = "#00E8E8E8".toByteColor().NoAlpha();
            BordersFix3 = "#00B1B1B1".toByteColor().NoAlpha();
            BordersFix4 = "#00D8D8D8".toByteColor().NoAlpha();
            ActiveCanvasBackgroundFix = "#00B0B0B0".toByteColor().NoAlpha();
            BordersFix5 = "#00B4B4B4".toByteColor().NoAlpha();
            BordersFix6 = "#00D4D4D4".toByteColor().NoAlpha();
            BordersFix7 = "#00DEDEDE".toByteColor().NoAlpha();
            BordersFix8 = "#00F8F8F8".toByteColor().NoAlpha();
            BordersFix9 = "#00EEEEEE".toByteColor();
            BurgerButtonsBackground = "#00F8F8F8".toByteColor().NoAlpha();
            BrushesBackgroundFileMenuBackgroundScrollBlockBackground = "#FFFFFFFF".toByteColor();
            ShitColoredText = "#00804020".toByteColor();
            SelectedElementBackgroundIdle = "#00DBDBFF".toByteColor().NoAlpha();
            SelectedElementBackgroundActive = "#00D4D4FF".toByteColor().NoAlpha();
            SelectedElementBackgroundHovered = "#00F6F6FF".toByteColor().NoAlpha();
            SelectedElementOutlineNotStated = "#008080FF".toByteColor().NoAlpha();
            SelectedElementOutlineHovered = "#00C2C2FF".toByteColor().NoAlpha();
            SelectedElementOutlineIdle = "#00CFCFFF".toByteColor().NoAlpha();
            SelectedElementOutlineNotFound1 = "#00D4ECFF".toByteColor().NoAlpha();
            SelectedElementDefaultNotFound2 = "#0066B5FF".toByteColor().NoAlpha();
            SelectedElementDefaultNotFound3 = "#00BFE4FF".toByteColor().NoAlpha();
            SelectedElementOutlineFix1 = "#00A6A6FF".toByteColor().NoAlpha();
            SelectedElementOutlineFix2 = "#008E8EFF".toByteColor().NoAlpha();
            SelectedElementOutlineFix3 = "#00DFDFF9".toByteColor().NoAlpha();
            SelectedElementOutlineFix5 = "#00E4E4F9".toByteColor().NoAlpha();
            SelectedElementOutlineFix6 = "#00ECFFD4".toByteColor().NoAlpha();
            SelectedElementOutlineFix7 = "#0066B5FF".toByteColor().NoAlpha();
            SelectedElementOutlineFix8 = "#00BFE4FF".toByteColor().NoAlpha();
            SelectedElementOutlineFix9 = "#007AC0FF".toByteColor().NoAlpha();
            SelectedElementOutlineFix10 = "#00D5E8FA".toByteColor().NoAlpha();
            SelectedElementOutlineFix11 = "#009CD0FF".toByteColor().NoAlpha();
        }
    }
}