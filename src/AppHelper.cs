using System.Text.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YumToolkit.Global;
using YumToolkit.Core;

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

            if(!File.Exists(name.original)) { console.SendMessage(serviceMessage.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }

            // Creating backup file to restore data or replace original file
            // with backup one to recolor it:
            if(!File.Exists(name.old)) { _File.Get.CreateOldFile(); }
            else {
                File.Delete(name.original);
                // This won't delete sai2.old.exe! Just cloning it to original one:
                _File.Get.ReplaceOriginalFile();
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
            if(!File.Exists(name.tmp)) { _File.Get.CreateTmpFile(); }

            // Reading tmp .exe:
            theme.binary = theme.ReadTmpFile(name.tmp);

            #region PRIMARY COLOR
            int[] PrimaryItems = [
                address.InActiveCanvasBackground,
                address.BehindLayersUIBackground,
                address.BrushBorders,
                address.SlidersVertical,
                address.SlidersHorizontal,
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
                address.ResizeWindowGrabber,
                address.SlidersInActiveBackground,
                // address.SlidersColor,
                address.BookmarkBackgroundAndOutlinesSomewhere,
                address.RadioButtonsBackground
            ];
            foreach(int n in SecondaryItems) {
                theme.SetElementColor(color.Secondary, n);
            }

            byte[][] SecondaryComplicatedItemsSrclibs = [
                color.BurgerButtonsOutline1,
                color.BurgerButtonsOutline2,
                color.BurgerButtonsOutline3,
                color.BurgerButtonsOutline4,
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
                // color.SelectedElementDefaultNotFound2,
                // color.SelectedElementDefaultNotFound3,
            ];
            foreach(byte[] n in SecondaryRGBComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
            }

            byte[][] SecondaryRGBComplicatedItemsSrclibsFix = [
                semiColor.SecondaryArtifactsColor1,
                semiColor.SecondaryArtifactsColor2,
                semiColor.SecondaryArtifactsColor3,
                semiColor.SecondaryArtifactsColor4,
            ];
            foreach(byte[] n in SecondaryRGBComplicatedItemsSrclibsFix) {
                theme.SetElementColorComplicated(n, semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
            }
            #endregion

            #region TERNARY COLOR
            int[] TernaryItems = [
                address.GlobalBorders,
                address.GlobalBorders2,
                address.TabsResizeGrabberVertical,
                address.ScaleAngleSliders,
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

            byte[][] TernaryRGBComplicatedItemsSrclibs = [
                color.BordersFix1,
                color.BordersFix2,
                color.BordersFix3,
                color.BordersFix4,
                color.BordersFix5,
                color.BordersFix6,
                color.BordersFix7,
                color.BordersFix8,
                color.BordersFix9,
            ];
            foreach(byte[] n in TernaryRGBComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
            }

            theme.SetElementColorComplicated(color.BrushesBackgroundFileMenuBackgroundScrollBlockBackground, color.Ternary, address.BrushesFileMenuTilesScrollableListsBackground[0], address.BrushesFileMenuTilesScrollableListsBackground[1]);
            
            byte[][] TernaryRGBComplicatedItemsSrclibsFix = [
                semiColor.TernaryArtifactsColor1,
                semiColor.TernaryArtifactsColor2,
                semiColor.TernaryArtifactsColor3,
                semiColor.TernaryArtifactsColor4,
                semiColor.TernaryArtifactsColor5,
                semiColor.TernaryArtifactsColor6,
                semiColor.TernaryArtifactsColor7,
                semiColor.TernaryArtifactsColor8,
            ];
            foreach(byte[] n in TernaryRGBComplicatedItemsSrclibsFix) {
                theme.SetElementColorComplicated(n, semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
            }

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
            ];
            foreach(int n in TextItems) {
                theme.SetElementColor(color.Text, n);
            }

            byte[][] TextComplicatedItems = [ color.ShitColoredText ];
            foreach(byte[] n in TextComplicatedItems) {
                theme.SetElementColorComplicated(n, color.Text, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1]);
                theme.SetElementColorComplicated(n, color.Text, address.GlobalSectionAppskin[0], address.GlobalSectionAppskin[1]);
            }
            #endregion

            #region SELECTABLE PRIMARY COLOR
            int[] SelectablePrimaryItems = [
                address.SlidersColor,
            ];
            foreach(int n in SelectablePrimaryItems) {
                theme.SetElementColor(color.SelectablePrimary, n);
            }
            byte[][] SelectablePrimaryComplicatedItems = [
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
            ];
            foreach(byte[] n in SelectablePrimaryComplicatedItems) {
                theme.SetElementColorComplicated(n, color.SelectablePrimary.NoAlpha(), address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], true);
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
            #endregion
            
            // Saving current theme changes:
            theme.SaveTheme();

            // Removing unnecessary tmp file:
            if(File.Exists(name.tmp)) { _File.Get.DeleteTmpFile(); }
            
        }
        void RemoveTheme() {
            if(!File.Exists(name.old)) { console.SendMessage(serviceMessage.OldFileIsNotExist, ConsoleColor.DarkRed); return; }
            
            File.Delete(name.original);
            _File.Get.ReplaceOriginalFile();
            _File.Get.DeleteOldFile();

            console.SendMessage(serviceMessage.DefaultThemeHasBeenRestored, ConsoleColor.DarkGreen);
        }
        static AppHelper() {
            Get = new AppHelper {
                ThemeColors = new Dictionary<string, string>()
            };
        }
    }
}