namespace YumToolkit.Core.Interfaces {
    interface IColor {
        // Customizable colors
        byte[] Primary { get; set; }
        byte[] Secondary { get; set; }
        byte[] Ternary { get; set; }
        byte[] Text { get; set; }
        byte[] SelectablePrimary { get; set; }
        byte[] SelectableSecondary { get; set; }
        // Sequences replacement colors
        byte[] BurgerButtonsOutline1 { get; }
        byte[] BurgerButtonsOutline2 { get; }
        byte[] BurgerButtonsOutline3 { get; }
        byte[] BurgerButtonsOutline4 { get; }
        byte[] BurgerButtonsOutlineAndScrollBarBackground { get; }
        byte[] InActiveScrollBarsBackground { get; }
        byte[] RadioButtonsMaskFixBurgerButtonsBackground { get; }
        byte[] BurgerButtonsOutlineSlidersOutline { get; }
        byte[] EmplyElementsInBrushesUI { get; }
        byte[] ColorPickerCircleBody { get; }
        byte[] WhatIsThisColor2 { get; }
        byte[] BordersFix1 { get; }
        byte[] BordersFix2 { get; }
        byte[] BordersFix3 { get; }
        byte[] ActiveCanvasBackgroundFix { get; }
        byte[] BordersFix4 { get; }
        byte[] BordersFix5 { get; }
        byte[] BordersFix6 { get; }
        byte[] BordersFix7 { get; }
        byte[] BordersFix8 { get; }
        byte[] BordersFix9 { get; }
        byte[] BurgerButtonsBackground { get; }
        byte[] BrushesBackgroundFileMenuBackgroundScrollBlockBackground { get; }
        byte[] ShitColoredText { get; }
        byte[] SelectedElementBackgroundIdle { get; }
        byte[] SelectedElementBackgroundActive { get; }
        byte[] SelectedElementBackgroundHovered { get; }
        byte[] SelectedElementOutlineNotStated { get; }
        byte[] SelectedElementOutlineHovered { get; }
        byte[] SelectedElementOutlineIdle { get; }
        byte[] SelectedElementOutlineNotFound1 { get; }
        byte[] SelectedElementDefaultNotFound2 { get; }
        byte[] SelectedElementDefaultNotFound3 { get; }
        byte[] SelectedElementOutlineFix1 { get; }
        byte[] SelectedElementOutlineFix2 { get; }
        byte[] SelectedElementOutlineFix3 { get; }
        byte[] SelectedElementOutlineFix5 { get; }
        byte[] SelectedElementOutlineFix6 { get; }
        byte[] SelectedElementOutlineFix7 { get; }
        byte[] SelectedElementOutlineFix8 { get; }
        byte[] SelectedElementOutlineFix9 { get; }
        byte[] SelectedElementOutlineFix10 { get; }
        byte[] SelectedElementOutlineFix11 { get; }
    }
}