using System.Text.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YumToolkit.Global;
using YumToolkit.Core;
using System.Drawing;

namespace YumToolkit {

    // Unneccessary stuff, to be stored here, but i did it to free space in App.cs
    class AppHelper : _Globals {
        public static AppHelper Get { get; private set; }
        Dictionary<string, string>? ThemeColors { get; set; }
        public void _Action() {
            // Since projcet can absorb any amount of themes,
            // at this moment, I decided to make unique behaviours
            // to anything in Console Menu, except of theme selection.
            // So users can select certain theme or anything else.
            // And because themes are in the top of Menu list,
            // I subtract user's choice from MaxListValue
            // to get unique Menu choices first and themes at the end.
            // So yeah, ReColor() is universal method to work with any selected theme,
            // so index can't be greater than 3, while no more unique menu choices inside.
            int index = consoleDrawing.MaxListValue - consoleDrawing.Choice;
            if(index > 3) index = 3;

            switch(index) {
                
                case 0: 
                    Environment.Exit(0);
                break;

                case 1:
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) { Process.Start(new ProcessStartInfo("cmd", $"/c start {path.GitHubLink}")); }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) { Process.Start("xdg-open", path.GitHubLink); }
                break;

                case 2: 
                    RemoveTheme();
                break;

                case 3: 
                    ReColor();
                break;

            }
            
        }

        void ReColor() {

            if(!file.IsOriginalFileExists()) { return; }
            if(file.IsFileBusy()) { return; }

            // Creating backup file to restore data or replace original file
            // with backup one to recolor it:
            if(!File.Exists(name.old)) { file.CreateOldFile(); }
            else {
                File.Delete(name.original);
                // This won't delete sai2.old.exe! Just cloning it to original one:
                file.ReplaceOriginalFile();
            }
            

            // Reading theme file:
            ThemeColors = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText($"{consoleDrawing.ThemesList[consoleDrawing.Choice]}"));
            
            // Returning if nothing to replace to:
            if(ThemeColors is null) return;
            
            // Applying colors to... colors:
            color.Primary = ThemeColors["Primary"].toByteColor();
            color.Secondary = ThemeColors["Secondary"].toByteColor();
            color.Ternary = ThemeColors["Ternary"].toByteColor();
            color.Text = ThemeColors["Text"].toByteColor();
            color.SelectablePrimary = ThemeColors["SelectablePrimary"].toByteColor();
            color.SelectableSecondary = ThemeColors["SelectableSecondary"].toByteColor();

            semiColor.ConfigureRGBColors();
            semiColor.ConfigureArtifactsColors();

            // Creating tmp .exe to replace binary data inside:
            if(!File.Exists(name.tmp)) { file.CreateTmpFile(); }

            // Reading tmp .exe:
            theme.binary = theme.ReadTmpFile(name.tmp);

            // Painting color circle. It's too complicated, so I disabled it for now.
            // theme.FixColorPicker(semiColor.TernaryRGB,address.GlobalSectionAppskin[0],address.GlobalSectionAppskin[1]);

            #region PRIMARY COLOR
            int[] PrimaryItems = [
                address.InActiveCanvasBackground,
                address.BehindLayersUIBackground,
                address.BrushBorders,
                address.SlidersVertical,
                address.SlidersHorizontal,
                address.ContextMenuArrowsFocused,
                address.ContextMenuCheckBoxesMarksFocused,
                address.ContextMenuCheckBoxesFocused,
                address.ContextMenuRadioButtonsFocused,
                // address.SlidersActiveBackground,
                // address.SlidersActiveBackgroundHoveredFocused,
            ];
            foreach(int n in PrimaryItems) {
                theme.SetElementColor(color.Primary, n);
            }

            byte[][] PrimaryComplicatedItemsSrclibs = [
                color.BurgerButtonsOutlineSlidersOutline,
            ];
            foreach(byte[] n in PrimaryComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, color.Primary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1]);
            }
            byte[][] PrimaryRGBComplicatedItemsSrclibsTrue = [
                color.BurgerButtonsOutline1,
                // color.BurgerButtonsOutline2,
                color.BurgerButtonsOutline3,
                color.BurgerButtonsOutline4,
                color.BordersFix9,
                color.saiFileInMenuBelowOutline,
                color.saiFileInMenuBelowOutlineFix,
                color.saiFileInMenuBelowInnerOutline,
                color.FileMenuTreeTabsFix1,
                color.FileMenuTreeTabsFix2,
            ];
            foreach(byte[] n in PrimaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, semiColor.PrimaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
            }

            byte[][] PrimaryRGBComplicatedItemsAppskinTrue = [
                color.LayerOutline,
                color.FileMenuBackground,
            ];
            foreach(byte[] n in PrimaryRGBComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, semiColor.PrimaryRGB, address.GlobalSectionAppskin[0], address.GlobalSectionAppskin[1], true);
            }
            #endregion

            #region SECONDARY COLOR
            int[] SecondaryItems = [
                address.ActiveCanvasBackground,
                address.ActiveCanvasBackground2,
                address.ActiveCanvasBackground3,
                address.ActiveCanvasBackground4,
                address.Separator,
                address.TopBar,
                address.ContextMenu,
                address.SlidersInActiveBackground,
                // address.SlidersColor,
                address.BookmarkBackgroundAndOutlinesSomewhere,
                address.RadioButtonsBackground
            ];
            foreach(int n in SecondaryItems) {
                theme.SetElementColor(color.Secondary, n);
            }

            theme.SetElementColorWithTotalReplacment(semiColor.SecondaryRGB, address.HoveredEmptyBrushesBackground[0], address.HoveredEmptyBrushesBackground[1]);
            theme.SetElementColorWithTotalReplacment(semiColor.SecondaryRGB, address.HoveredLayersBackground[0], address.HoveredLayersBackground[1]);
            
            byte[][] SecondaryComplicatedItemsSrclibs = [
                // color.BurgerButtonsOutline1,
                // color.BurgerButtonsOutline2,
                // color.BurgerButtonsOutline3,
                // color.BurgerButtonsOutline4,
                // color.BurgerButtonsOutlineAndScrollBarBackground,
                color.InActiveScrollBarsBackground,
                // color.BurgerButtonsOutlineSlidersOutline,
                // color.BordersFix9,
                color.EmplyElementsInBrushesUI,
                color.ColorPickerCircleBody,
            ];
            foreach(byte[] n in SecondaryComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1]);
            }

            theme.SetElementColorComplicated(color.ActiveCanvasBackgroundFix, color.Secondary, address.GlobalSectionText[0], address.GlobalSectionText[1], true);

            byte[][] SecondaryRGBComplicatedItemsSrclibs = [
                color.SelectedElementBackgroundIdle,
                color.SelectedElementBackgroundActive,
                color.SelectedElementBackgroundHovered,
                color.FileMenuListElementsBackgroundHovered,
                color.FileMenuListElementsBackgroundDefault,
                // color.SelectedElementDefaultNotFound2,
                // color.SelectedElementDefaultNotFound3,
            ];
            foreach(byte[] n in SecondaryRGBComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
            }

            byte[][] SecondaryRGBComplicatedItemsSrclibsTrue = [
                semiColor.SecondaryArtifactsColor1,
                semiColor.SecondaryArtifactsColor2,
                semiColor.SecondaryArtifactsColor3,
                semiColor.SecondaryArtifactsColor4,
            ];
            foreach(byte[] n in SecondaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
            }
            #endregion

            #region TERNARY COLOR
            int[] TernaryItems = [
                address.GlobalBorders,
                address.GlobalBorders2,
                address.TabsResizeGrabberVertical,
                address.ScaleAngleSliders,
                address.ResizeWindowGrabber,
            ];
            foreach(int n in TernaryItems) {
                theme.SetElementColor(color.Ternary, n);
            }

            byte[][] TernaryComplicatedItemsSrclibs = [
                color.RadioButtonsMaskFixBurgerButtonsBackground,
                // color.BurgerButtonsOutlineSlidersOutline,
                // color.ColorPickerCircleBody,
            ];
            foreach(byte[] n in TernaryComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, color.Ternary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1]);
            }

            byte[][] TernaryComplicatedItemsAppskin = [
                color.EmplyElementsInBrushesUI,
                color.WhatIsThisColor2,
            ];
            foreach(byte[] n in TernaryComplicatedItemsAppskin) {
                theme.SetElementColorComplicated(n, color.Ternary, address.GlobalSectionAppskin[0], address.GlobalSectionAppskin[1]);
            }

            theme.SetElementColorComplicated(color.BrushesBackgroundFileMenuBackgroundScrollBlockBackground, color.Ternary, address.BrushesFileMenuTilesScrollableListsBackground[0], address.BrushesFileMenuTilesScrollableListsBackground[1]);
            
            byte[][] TernaryRGBComplicatedItemsSrclibsTrue = [
                semiColor.TernaryArtifactsColor1,
                semiColor.TernaryArtifactsColor2,
                semiColor.TernaryArtifactsColor3,
                semiColor.TernaryArtifactsColor4,
                semiColor.TernaryArtifactsColor5,
                semiColor.TernaryArtifactsColor6,
                semiColor.TernaryArtifactsColor7,
                semiColor.TernaryArtifactsColor8,
                color.BurgerButtonsOutline2,
                color.BordersFix1,
                color.BordersFix2,
                color.BordersFix3,
                color.BordersFix4,
                color.BordersFix5,
                color.BordersFix6,
                color.BordersFix7,
                color.BordersFix8,
                // color.BordersFix9,
                color.EmptyScrollBarBackground,
                color.ScrollBarOutlineHoveredFix3,
                color.saiFileInMenuBelowBackground,
                color.FileMenuTreeTabsFix3,
                color.FileMenuTreeTabsFix4,
                color.FileMenuTreeTabsFix5,
                color.FileMenuTreeTabsFix6,
                color.FileMenuTreeTabsFix7,
                color.FileMenuTreeTabsFix8,
            ];
            foreach(byte[] n in TernaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
            }
            theme.SetElementColorComplicated(color.LayerBackground, semiColor.TernaryRGB, address.LayerBackground[0], address.LayerBackground[1], true);
            #endregion

            #region TEXT COLOR
            int[] TextItems = [
                address.BrushesSpecialText,
                address.ContextMenuText,
                // address.ContextMenuTextFocused,
                address.ContextMenuTextHovered,
                address.TopBarText,
                // address.TopBarTextFocused,
                address.TopBarTextHovered,
                address.FileMenuScrollableText,
                address.FileMenuTilesText,
                address.BrushesText,
                address.BrushesTabsText,
                address.BrushesCirclesText,
                address.ShitTextInWindows,
            ];
            foreach(int n in TextItems) {
                theme.SetElementColor(color.Text, n);
            }

            byte[][] TextComplicatedItemsSrclibs = [ 
                color.ShitColoredText,
                color.FileMenuTreeText
            ];
            foreach(byte[] n in TextComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, color.Text, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1]);
            }

            // byte[][] TextComplicatedItemsAppskin = [
            // ];
            // foreach(byte[] n in TextComplicatedItemsAppskin) {
            //     theme.SetElementColorComplicated(n, color.Text, address.GlobalSectionAppskin[0], address.GlobalSectionAppskin[1]);
            // }
            #endregion

            #region SELECTABLE PRIMARY COLOR
            int[] SelectablePrimaryItems = [
                address.SlidersColor,
                address.ContextMenuArrows,
                address.ContextMenuArrowsHovered,
                address.ContextMenuCheckBoxes,
                address.ContextMenuCheckBoxesHovered,
                address.ContextMenuCheckBoxesMarks,
                address.ContextMenuCheckBoxesMarksHovered,
                address.ContextMenuRadioButtons,
                address.ContextMenuRadioButtonsEmpty,
                address.ContextMenuRadioButtonsHovered,
                // address.ContextMenuArrowsFocused,
                // address.ContextMenuCheckBoxesMarksFocused,
                // address.ContextMenuCheckBoxesFocused,
                // address.ContextMenuRadioButtonsFocused,
            ];
            foreach(int n in SelectablePrimaryItems) {
                theme.SetElementColor(color.SelectablePrimary, n);
            }
            byte[][] SelectablePrimaryComplicatedItemsSrclibsTrue = [
                color.SelectedElementOutlineActive,
                color.SelectedElementOutlineHovered,
                color.SelectedElementOutlineIdle,
                color.SelectedElementBackgroundFocused,
                color.SelectedElementOutlineFix1,
                color.SelectedElementOutlineFix2,
                color.SelectedElementOutlineFix3,
                color.SelectedElementOutlineFix5,
                color.SelectedElementOutlineFix6,
                color.SelectedElementOutlineFix7,
                color.SelectedElementOutlineFix8,
                color.SelectedElementOutlineFix9,
                color.SelectedElementOutlineFix10,
                color.SelectedElementOutlineFix11,
                color.ScrollBarFillHovered,
                color.YesNoButtonsBackground,
                color.ScrollBarAndServiceButtonsFill,
                color.saiFileInMenuBelowBackgroundHovered,
                color.FileMenuListElementsOutlineDefault,
                color.FileMenuTreeTextFocused,
            ];
            foreach(byte[] n in SelectablePrimaryComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, semiColor.SelectablePrimaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
            }

            byte[][] SelectablePrimaryComplicatedItemsAppskinTrue = [
                color.SelectedLayerOutlineActiveHovered,
                color.SelectedLayerOutlineFocused,
                color.SelectedLayerInnerOutlineActive,
                color.SelectedLayerInnerOutlineHovered,
                color.SelectedLayerInnerOutlineFocused,
                color.SelectedLayerInnerOutlineGrabbed,
                // color.LayerOutline,
                color.LayerBackgroundFocused,
                color.SelectedLayerBackgroundGrabbed,
                color.LayerBackgroundGrabbed,
                color.FileMenuListCategoryArrows,
            ];
            foreach(byte[] n in SelectablePrimaryComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, semiColor.SelectablePrimaryRGB, address.GlobalSectionAppskin[0], address.GlobalSectionAppskin[1], true);
            }
            #endregion

            #region SELECTABLE SECONDARY COLOR
            int[] SelectableSecondaryItems = [
                // address.SlidersInActiveBackground,
                address.SlidersActiveBackground,
                address.SlidersActiveBackgroundHoveredFocused,
            ];
            foreach(int n in SelectableSecondaryItems) {
                theme.SetElementColor(color.SelectableSecondary, n);
            }

            byte[][] SelectableSecondaryComplicatedItemsAppskinTrue = [
                color.SelectedLayerBackgroundActive,
                color.SelectedLayerBackgroundHovered,
                color.SelectedLayerBackgroundFocused,
            ];
            foreach(byte[] n in SelectableSecondaryComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, semiColor.SelectableSecondaryRGB, address.GlobalSectionAppskin[0], address.GlobalSectionAppskin[1], true);
            }

            byte[][] SelectableSecondaryComplicatedItemsSrclibsTrue = [
                color.ScrollBarFillFocused,
                color.ScrollBarOutlineHovered,
                color.ScrollBarOutlineHoveredFix1,
                color.ScrollBarOutlineHoveredFix2,
                // color.ScrollBarOutlineHoveredFix3,
                color.ScrollBarOutlineFocused,
                color.ScrollBarOutlineFocusedFix1,
                color.ScrollBarOutlineFocusedFix2,
                color.YesNoButtonsOutline,
                color.YesNoButtonsOutlineFix1,
                color.YesNoButtonsOutlineFix2,
                color.YesNoButtonsOutlineFix3,
                color.ScrollBarAndServiceButtonsOutline,
                color.ScrollBarAndServiceButtonsOutlineFix1,
                color.ScrollBarAndServiceButtonsOutlineFix2,
                color.saiFileInMenuBelowOutlineHovered,
                color.FileMenuTreeTextHovered,
            ];
            foreach(byte[] n in SelectableSecondaryComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, semiColor.SelectableSecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
            }
            #endregion

            // Saving current theme changes:
            theme.SaveTheme();

            // Removing unnecessary tmp file:
            if(File.Exists(name.tmp)) { file.DeleteTmpFile(); }
            
        }
        void RemoveTheme() {
            if(!file.IsOldFileExists()) { return; }
            if(file.IsFileBusy()) { return; }

            File.Delete(name.original);
            file.ReplaceOriginalFile();
            file.DeleteOldFile();

            console.SendMessage(serviceMessage.DefaultThemeHasBeenRestored, ConsoleColor.DarkGreen);
        }
        static AppHelper() {
            Get = new AppHelper {
                ThemeColors = new Dictionary<string, string>()
            };
        }
    }
}