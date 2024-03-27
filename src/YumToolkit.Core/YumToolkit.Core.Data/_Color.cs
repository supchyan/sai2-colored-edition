using YumToolkit.Core.Interfaces;
using YumToolkit.Global;

namespace YumToolkit.Core.Data {
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
        /// # F2 F2 F2
        /// </summary>
        public byte[] BurgerButtonsOutline1 { get; }
        /// <summary>
        /// # F4 F4 F4
        /// </summary>
        public byte[] BurgerButtonsOutline2 { get; }
        /// <summary>
        /// # E4 E4 E4
        /// </summary>
        public byte[] BurgerButtonsOutline3 { get; }
        /// <summary>
        /// # E0 E0 E0
        /// </summary>
        public byte[] BurgerButtonsOutline4 { get; }
        /// <summary>
        /// # E8 E8 E8
        /// </summary>
        public byte[] BurgerButtonsOutlineAndScrollBarBackground { get; }
        /// <summary>
        /// # F0 F0 F0 00
        /// </summary>
        public byte[] InActiveScrollBarsBackground { get; }
        /// <summary>
        /// # F8 F8 F8
        /// </summary>
        public byte[] RadioButtonsMaskFixBurgerButtonsBackground { get; }
        /// <summary>
        /// # DA DA DA
        /// </summary>
        public byte[] BurgerButtonsOutlineSlidersOutline { get; }
        /// <summary>
        /// # EE EE EE
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
        /// # B0 B0 B0
        /// </summary>
        public byte[] ActiveCanvasBackgroundFix { get; }
        /// <summary>
        /// # F0 F0 F0
        /// </summary>
        public byte[] EmptyScrollBarBackground { get; }
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
        /// # 80 40 20
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
        public byte[] SelectedElementOutlineActive { get; }
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
        public byte[] SelectedElementBackgroundFocused { get; }
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
        /// <summary>
        /// # DB DB FF
        /// </summary>
        public byte[] SelectedLayerBackgroundActive { get; }
        /// <summary>
        /// # D4 D4 FF
        /// </summary>
        public byte[] SelectedLayerBackgroundHovered { get; }
        /// <summary>
        /// # BD F2 FF
        /// </summary>
        public byte[] SelectedLayerBackgroundFocused { get; }
        /// <summary>
        /// # 80 80 FF
        /// </summary>
        public byte[] SelectedLayerOutlineActiveHovered  { get; }
        /// <summary>
        /// # D1 F6 FF
        /// </summary>
        public byte[] SelectedLayerBackgroundGrabbed  { get; }
        /// <summary>
        /// # 22 B1 E6
        /// </summary>
        public byte[] SelectedLayerOutlineFocused { get; }
        /// <summary>
        /// # B0 B0 B0
        /// </summary>
        public byte[] LayerOutline { get; }
        /// <summary>
        /// # CF CF FF
        /// </summary>
        public byte[] SelectedLayerInnerOutlineActive { get; }
        /// <summary>
        /// # C2 C2 FF
        /// </summary>
        public byte[] SelectedLayerInnerOutlineHovered { get; }
        /// <summary>
        /// # A8 EE FF
        /// </summary>
        public byte[] SelectedLayerInnerOutlineFocused { get; }
        /// <summary>
        /// # BF F3 FF
        /// </summary>
        public byte[] SelectedLayerInnerOutlineGrabbed { get; }
        /// <summary>
        /// # DB F8 FF
        /// </summary>
        public byte[] LayerBackgroundFocused { get; }
        /// <summary>
        /// # 9D 9D FF
        /// </summary>
        public byte[] ScrollBarFillHovered { get; }
        /// <summary>
        /// # B5 B5 FF
        /// </summary>
        public byte[] ScrollBarFillFocused { get; }
        /// <summary>
        /// # 5E 5E EC
        /// </summary>
        public byte[] ScrollBarOutlineHovered { get; }
        /// <summary>
        /// # 71 71 F1
        /// </summary>
        public byte[] ScrollBarOutlineHoveredFix1 { get; }
        /// <summary>
        /// # 8C 8C F8
        /// </summary>
        public byte[] ScrollBarOutlineHoveredFix2 { get; }
        /// <summary>
        /// # CB CB FF
        /// </summary>
        public byte[] ScrollBarOutlineHoveredFix3 { get; }
        /// <summary>
        /// # 61 61 FF
        /// </summary>
        public byte[] ScrollBarOutlineFocused { get; }
        /// <summary>
        /// # 78 78 FF
        /// </summary>
        public byte[] ScrollBarOutlineFocusedFix1 { get; }
        /// <summary>
        /// # 9F 9F FF
        /// </summary>
        public byte[] ScrollBarOutlineFocusedFix2 { get; }
        /// <summary>
        /// # 7C 96 E2
        /// </summary>
        public byte[] YesNoButtonsBackground { get; }
        /// <summary>
        /// # 42 67 D6
        /// </summary>
        public byte[] YesNoButtonsOutline { get; }
        /// <summary>
        /// # 53 75 D9
        /// </summary>
        public byte[] YesNoButtonsOutlineFix1 { get; }
        /// <summary>
        /// # 6C 88 DE
        /// </summary>
        public byte[] YesNoButtonsOutlineFix2 { get; }
        /// <summary>
        /// # A5 B4 E1
        /// </summary>
        public byte[] YesNoButtonsOutlineFix3 { get; }
        /// <summary>
        /// # 96 96 96
        /// </summary>
        public byte[] ScrollBarAndServiceButtonsFill { get; }
        /// <summary>
        /// # 70 70 70
        /// </summary>
        public byte[] ScrollBarAndServiceButtonsOutline { get; }
        /// <summary>
        /// # 7D 7D 7D
        /// </summary>
        public byte[] ScrollBarAndServiceButtonsOutlineFix1 { get; }
        /// <summary>
        /// # 8C 8C 8C
        /// </summary>
        public byte[] ScrollBarAndServiceButtonsOutlineFix2 { get; }
        /// <summary>
        /// # FF FF FF
        /// </summary>
        public byte[] LayerBackground { get; }
        /// <summary>
        /// # E3 F9 FF
        /// </summary>
        public byte[] LayerBackgroundGrabbed { get; }
        /// <summary>
        /// # EB EB EB
        /// </summary>
        public byte[] saiFileInMenuBelowBackground { get; }
        /// <summary>
        /// # E7 E7 E7
        /// </summary>
        public byte[] saiFileInMenuBelowBackgroundHovered { get; }
        /// <summary>
        /// # A6 A6 A6
        /// </summary>
        public byte[] saiFileInMenuBelowOutline { get; }
        /// <summary>
        /// # DC DC DC
        /// </summary>
        public byte[] saiFileInMenuBelowOutlineHovered { get; }
        /// <summary>
        /// # B2 B2 B2
        /// </summary>
        public byte[] saiFileInMenuBelowOutlineFix { get; }
        /// <summary>
        /// # DF DF DF
        /// </summary>
        public byte[] saiFileInMenuBelowInnerOutline { get; }
        /// <summary>
        /// # FC FC FF
        /// </summary>
        public byte[] FileMenuBackground { get; }
        /// <summary>
        /// # E6 E6 E6
        /// </summary>
        public byte[] FileMenuListElementsBackgroundHovered { get; }
        /// <summary>
        /// # ED ED ED
        /// </summary>
        public byte[] FileMenuListElementsBackgroundDefault { get; }
        /// <summary>
        /// # 8E 8E 8E
        /// </summary>
        public byte[] FileMenuListElementsOutlineDefault { get; }
        /// <summary>
        /// # EE EE EE
        /// </summary>
        public byte[] FileMenuTreeTabsFix1 { get; }
        /// <summary>
        /// # F3 F3 F3
        /// </summary>
        public byte[] FileMenuTreeTabsFix2 { get; }
        /// <summary>
        /// # A7 A7 A7
        /// </summary>
        public byte[] FileMenuTreeTabsFix3 { get; }
        /// <summary>
        /// # B8 B8 B8
        /// </summary>
        public byte[] FileMenuTreeTabsFix4 { get; }
        /// <summary>
        /// # DA DA DA
        /// </summary>
        public byte[] FileMenuTreeTabsFix5 { get; }
        /// <summary>
        /// # E2 E2 E2
        /// </summary>
        public byte[] FileMenuTreeTabsFix6 { get; }
        /// <summary>
        /// # EA EA EA
        /// </summary>
        public byte[] FileMenuTreeTabsFix7 { get; }
        /// <summary>
        /// # AE AE AE
        /// </summary>
        public byte[] FileMenuTreeTabsFix8 { get; }
        /// <summary>
        /// # 34 34 34
        /// </summary>
        public byte[] FileMenuListCategoryArrows { get; }
        /// <summary>
        /// # 40 40 40
        /// </summary>
        public byte[] FileMenuTreeText { get; }
        /// <summary>
        /// # 40 20 C0
        /// </summary>
        public byte[] FileMenuTreeTextHovered { get; }
        /// <summary>
        /// # C0 60 40
        /// </summary>
        public byte[] FileMenuTreeTextFocused { get; }

         public _Color() {
            // Depends on theme choice, so values here isn't important
            Primary = [];
            Secondary = [];
            Ternary = [];
            Text = [];
            SelectablePrimary = [];
            SelectableSecondary = [];
            // Constants
            BurgerButtonsOutline1 = "#00F2F2F2".toByteColor().NoAlpha();
            BurgerButtonsOutline2 = "#00F4F4F4".toByteColor().NoAlpha();
            BurgerButtonsOutline3 = "#00E4E4E4".toByteColor().NoAlpha();
            BurgerButtonsOutline4 = "#00E0E0E0".toByteColor().NoAlpha();
            BurgerButtonsOutlineAndScrollBarBackground = "#00E8E8E8".toByteColor().NoAlpha();
            InActiveScrollBarsBackground = "#F0F0F000".toByteColor(); // with out NoAlpha(), yes.
            RadioButtonsMaskFixBurgerButtonsBackground = "#00F8F8F8".toByteColor().NoAlpha();
            BurgerButtonsOutlineSlidersOutline = "#00DADADA".toByteColor().NoAlpha();
            EmplyElementsInBrushesUI = "#F0F0F0F0".toByteColor();
            ColorPickerCircleBody = "#F8F8F8F8".toByteColor();
            WhatIsThisColor2 = "#ACACACAC".toByteColor();
            ActiveCanvasBackgroundFix = "#00B0B0B0".toByteColor().NoAlpha();
            EmptyScrollBarBackground = "#00F0F0F0".toByteColor().NoAlpha();
            BordersFix1 = "#00C6C6C6".toByteColor().NoAlpha();
            BordersFix2 = "#00E8E8E8".toByteColor().NoAlpha();
            BordersFix3 = "#00B1B1B1".toByteColor().NoAlpha();
            BordersFix4 = "#00D8D8D8".toByteColor().NoAlpha();
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
            SelectedElementOutlineActive = "#008080FF".toByteColor().NoAlpha();
            SelectedElementOutlineHovered = "#00C2C2FF".toByteColor().NoAlpha();
            SelectedElementOutlineIdle = "#00CFCFFF".toByteColor().NoAlpha();
            SelectedElementBackgroundFocused = "#00D4ECFF".toByteColor().NoAlpha();
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
            SelectedLayerBackgroundActive = "#00DBDBFF".toByteColor().NoAlpha();
            SelectedLayerBackgroundHovered = "#00D4D4FF".toByteColor().NoAlpha();
            SelectedLayerBackgroundFocused = "#00BDF2FF".toByteColor().NoAlpha();
            SelectedLayerBackgroundGrabbed = "#00D1F6FF".toByteColor().NoAlpha();
            SelectedLayerOutlineActiveHovered = "#008080FF".toByteColor().NoAlpha();
            SelectedLayerOutlineFocused = "#0022B1E6".toByteColor().NoAlpha();
            LayerOutline = "#00B0B0B0".toByteColor().NoAlpha();
            SelectedLayerInnerOutlineActive = "#00CFCFFF".toByteColor().NoAlpha();
            SelectedLayerInnerOutlineHovered = "#00C2C2FF".toByteColor().NoAlpha();
            SelectedLayerInnerOutlineFocused = "#00A8EEFF".toByteColor().NoAlpha();
            SelectedLayerInnerOutlineGrabbed = "#00BFF3FF".toByteColor().NoAlpha();
            LayerBackgroundFocused = "#00DBF8FF".toByteColor().NoAlpha();
            ScrollBarFillHovered = "#009D9DFF".toByteColor().NoAlpha();
            ScrollBarFillFocused = "#00B5B5FF".toByteColor().NoAlpha();
            ScrollBarOutlineHovered = "#005E5EEC".toByteColor().NoAlpha();
            ScrollBarOutlineHoveredFix1 = "#007171F1".toByteColor().NoAlpha();
            ScrollBarOutlineHoveredFix2 = "#008C8CF8".toByteColor().NoAlpha();
            ScrollBarOutlineHoveredFix3 = "#00CBCBFF".toByteColor().NoAlpha();
            ScrollBarOutlineFocused = "#006161FF".toByteColor().NoAlpha();
            ScrollBarOutlineFocusedFix1 = "#007878FF".toByteColor().NoAlpha();
            ScrollBarOutlineFocusedFix2 = "#009F9FFF".toByteColor().NoAlpha();
            YesNoButtonsBackground = "#007C96E2".toByteColor().NoAlpha();
            YesNoButtonsOutline = "#004267D6".toByteColor().NoAlpha();
            YesNoButtonsOutlineFix1 = "#005375D9".toByteColor().NoAlpha();
            YesNoButtonsOutlineFix2 = "#006C88DE".toByteColor().NoAlpha();
            YesNoButtonsOutlineFix3 = "#00A5B4E1".toByteColor().NoAlpha();
            ScrollBarAndServiceButtonsFill = "#00969696".toByteColor().NoAlpha();
            ScrollBarAndServiceButtonsOutline = "#00707070".toByteColor().NoAlpha();
            ScrollBarAndServiceButtonsOutlineFix1 = "#007D7D7D".toByteColor().NoAlpha();
            ScrollBarAndServiceButtonsOutlineFix2 = "#008C8C8C".toByteColor().NoAlpha();
            LayerBackground = "#00FFFFFF".toByteColor().NoAlpha();
            LayerBackgroundGrabbed = "#00E3F9FF".toByteColor().NoAlpha();
            saiFileInMenuBelowBackground = "#00EBEBEB".toByteColor().NoAlpha();
            saiFileInMenuBelowBackgroundHovered = "#00E7E7E7".toByteColor().NoAlpha();
            saiFileInMenuBelowOutline = "#00A6A6A6".toByteColor().NoAlpha();
            saiFileInMenuBelowOutlineHovered = "#00DCDCDC".toByteColor().NoAlpha();
            saiFileInMenuBelowOutlineFix = "#00B2B2B2".toByteColor().NoAlpha();
            saiFileInMenuBelowInnerOutline = "#00DFDFDF".toByteColor().NoAlpha();
            FileMenuBackground = "#00FCFCFF".toByteColor().NoAlpha();
            FileMenuListElementsBackgroundHovered = "#00E6E6E6".toByteColor().NoAlpha();
            FileMenuListElementsBackgroundDefault = "#00EDEDED".toByteColor().NoAlpha();
            FileMenuListElementsOutlineDefault = "#008E8E8E".toByteColor().NoAlpha();
            FileMenuTreeTabsFix1 = "#00EEEEEE".toByteColor().NoAlpha();
            FileMenuTreeTabsFix2 = "#00F3F3F3".toByteColor().NoAlpha();
            FileMenuTreeTabsFix3 = "#00A7A7A7".toByteColor().NoAlpha();
            FileMenuTreeTabsFix4 = "#00B8B8B8".toByteColor().NoAlpha();
            FileMenuTreeTabsFix5 = "#00DADADA".toByteColor().NoAlpha();
            FileMenuTreeTabsFix6 = "#00E2E2E2".toByteColor().NoAlpha();
            FileMenuTreeTabsFix7 = "#00EAEAEA".toByteColor().NoAlpha();
            FileMenuTreeTabsFix8 = "#00AEAEAE".toByteColor().NoAlpha();
            FileMenuListCategoryArrows = "#00343434".toByteColor().NoAlpha();
            FileMenuTreeText = "#00404040".toByteColor().NoAlpha();
            FileMenuTreeTextHovered = "#004020C0".toByteColor().NoAlpha();
            FileMenuTreeTextFocused = "#00C06040".toByteColor().NoAlpha();
        }
    }
}