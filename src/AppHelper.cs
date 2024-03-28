using System.Text.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YumToolkit.Global;
using YumToolkit.Core;
using System.Drawing;

namespace YumToolkit {
    class AppHelper : _Globals {
        Dictionary<string, byte[]>? themeColor { get; set; }
        Dictionary<string, byte[]>? saiColorARGB { get; set; }
        Dictionary<string, byte[]>? saiColorRGB { get; set; }
        Dictionary<string, int>? saiAddress { get; set; }
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
            

            // Getting theme vaules:
            themeColor = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText($"{consoleDrawing.ThemesList[consoleDrawing.Choice]}"))?.ConvertToByteColorDictionary();
            
            // Getting replacment libraries:
            saiAddress = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText(path.saiAddressFile))?.ConvertToDecimalAddressDictionary();
            saiColorARGB = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText(path.saiColorARGBFile))?.ConvertToByteColorDictionary();
            saiColorRGB = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText(path.saiColorRGBFile))?.ConvertToByteColorDictionaryRGB();
            
            // Returning if nothing to replace to:
            if(themeColor is null || saiAddress is null || saiColorARGB is null || saiColorRGB is null) { return; }
            
            colorRGB.ConfigureRGBColors(themeColor, saiColorRGB);
            colorRGB.ConfigureArtifactsColors(saiColorRGB["Secondary"], saiColorRGB["Ternary"]);

            // Creating tmp .exe to replace binary data inside:
            if(!File.Exists(name.tmp)) { file.CreateTmpFile(); }

            // Reading tmp .exe:
            theme.binary = theme.ReadTmpFile(name.tmp);

            // Painting color circle. It's too complicated, so I disabled it for now.
            // theme.FixColorPicker(saiColorRGB["Ternary"],saiAddress["GlobalSectionAppskin[0],saiAddress["GlobalSectionAppskin[1]);

            #region PRIMARY COLOR
            int[] PrimaryItems = [
                saiAddress["InActiveCanvasBackground"],
                saiAddress["BehindLayersUIBackground"],
                saiAddress["BrushBorders"],
                saiAddress["SlidersVertical"],
                saiAddress["SlidersHorizontal"],
                saiAddress["ContextMenuArrowsFocused"],
                saiAddress["ContextMenuCheckBoxesMarksFocused"],
                saiAddress["ContextMenuCheckBoxesFocused"],
                saiAddress["ContextMenuRadioButtonsFocused"],
            ];
            foreach(int n in PrimaryItems) {
                theme.SetElementColor(themeColor["Primary"], n);
            }

            byte[][] PrimaryComplicatedItemsSrclibs = [
                saiColorRGB["BurgerButtonsOutlineSlidersOutline"],
            ];
            foreach(byte[] n in PrimaryComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, themeColor["Primary"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"]);
            }
            byte[][] PrimaryRGBComplicatedItemsSrclibsTrue = [
                saiColorRGB["BurgerButtonsOutline1"],
                saiColorRGB["BurgerButtonsOutline3"],
                saiColorRGB["BurgerButtonsOutline4"],
                saiColorRGB["BordersFix9"],
                saiColorRGB["saiFileInMenuBelowOutline"],
                saiColorRGB["saiFileInMenuBelowOutlineFix"],
                saiColorRGB["saiFileInMenuBelowInnerOutline"],
                saiColorRGB["FileMenuTreeTabsFix1"],
                saiColorRGB["FileMenuTreeTabsFix2"],
            ];
            foreach(byte[] n in PrimaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, saiColorRGB["Primary"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }

            byte[][] PrimaryRGBComplicatedItemsAppskinTrue = [
                saiColorRGB["LayerOutline"],
                saiColorRGB["FileMenuBackground"],
            ];
            foreach(byte[] n in PrimaryRGBComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, saiColorRGB["Primary"], saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"], true);
            }
            #endregion

            #region SECONDARY COLOR
            int[] SecondaryItems = [
                saiAddress["ActiveCanvasBackground"],
                saiAddress["ActiveCanvasBackground2"],
                saiAddress["ActiveCanvasBackground3"],
                saiAddress["ActiveCanvasBackground4"],
                saiAddress["Separator"],
                saiAddress["TopBar"],
                saiAddress["ContextMenu"],
                saiAddress["SlidersInActiveBackground"],
                saiAddress["BookmarkBackgroundAndOutlinesSomewhere"],
                saiAddress["RadioButtonsBackground"],
            ];
            foreach(int n in SecondaryItems) {
                theme.SetElementColor(themeColor["Secondary"], n);
            }

            theme.SetElementColorWithTotalReplacment(saiColorRGB["Secondary"], saiAddress["HoveredEmptyBrushesBackgroundFrom"], saiAddress["HoveredEmptyBrushesBackgroundTo"]);
            theme.SetElementColorWithTotalReplacment(saiColorRGB["Secondary"], saiAddress["HoveredLayersBackgroundFrom"], saiAddress["HoveredLayersBackgroundTo"]);
            
            byte[][] SecondaryComplicatedItemsSrclibs = [
                saiColorARGB["InActiveScrollBarsBackground"],
                saiColorARGB["EmplyElementsInBrushesUI"],
                saiColorARGB["ColorPickerCircleBody"],
            ];
            foreach(byte[] n in SecondaryComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, themeColor["Secondary"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"]);
            }

            theme.SetElementColorComplicated(saiColorRGB["ActiveCanvasBackgroundFix"], themeColor["Secondary"], saiAddress["GlobalSectionTextFrom"], saiAddress["GlobalSectionTextTo"], true);

            byte[][] SecondaryRGBComplicatedItemsSrclibs = [
                saiColorRGB["SelectedElementBackgroundIdle"],
                saiColorRGB["SelectedElementBackgroundActive"],
                saiColorRGB["SelectedElementBackgroundHovered"],
                saiColorRGB["FileMenuListElementsBackgroundHovered"],
                saiColorRGB["FileMenuListElementsBackgroundDefault"],
            ];
            foreach(byte[] n in SecondaryRGBComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, saiColorRGB["Secondary"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }

            byte[][] SecondaryRGBComplicatedItemsSrclibsTrue = [
                colorRGB.SecondaryArtifactsColor1,
                colorRGB.SecondaryArtifactsColor2,
                colorRGB.SecondaryArtifactsColor3,
                colorRGB.SecondaryArtifactsColor4,
            ];
            foreach(byte[] n in SecondaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, saiColorRGB["Secondary"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }
            #endregion

            #region TERNARY COLOR
            int[] TernaryItems = [
                saiAddress["GlobalBorders"],
                saiAddress["GlobalBorders2"],
                saiAddress["TabsResizeGrabberVertical"],
                saiAddress["ScaleAngleSliders"],
                saiAddress["ResizeWindowGrabber"],
            ];
            foreach(int n in TernaryItems) {
                theme.SetElementColor(themeColor["Ternary"], n);
            }

            byte[][] TernaryComplicatedItemsSrclibs = [
                saiColorRGB["RadioButtonsMaskFixBurgerButtonsBackground"],
            ];
            foreach(byte[] n in TernaryComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, themeColor["Ternary"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"]);
            }

            byte[][] TernaryComplicatedItemsAppskin = [
                saiColorARGB["EmplyElementsInBrushesUI"],
                saiColorARGB["WhatIsThisColor2"],
            ];
            foreach(byte[] n in TernaryComplicatedItemsAppskin) {
                theme.SetElementColorComplicated(n, themeColor["Ternary"], saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"]);
            }

            theme.SetElementColorComplicated(saiColorARGB["BrushesBackgroundFileMenuBackgroundScrollBlockBackground"], themeColor["Ternary"], saiAddress["BrushesFileMenuTilesScrollableListsBackgroundFrom"], saiAddress["BrushesFileMenuTilesScrollableListsBackgroundTo"]);
            
            byte[][] TernaryRGBComplicatedItemsSrclibsTrue = [
                colorRGB.TernaryArtifactsColor1,
                colorRGB.TernaryArtifactsColor2,
                colorRGB.TernaryArtifactsColor3,
                colorRGB.TernaryArtifactsColor4,
                colorRGB.TernaryArtifactsColor5,
                colorRGB.TernaryArtifactsColor6,
                colorRGB.TernaryArtifactsColor7,
                colorRGB.TernaryArtifactsColor8,
                saiColorRGB["BurgerButtonsOutline2"],
                saiColorRGB["BordersFix1"],
                saiColorRGB["BordersFix2"],
                saiColorRGB["BordersFix3"],
                saiColorRGB["BordersFix4"],
                saiColorRGB["BordersFix5"],
                saiColorRGB["BordersFix6"],
                saiColorRGB["BordersFix7"],
                saiColorRGB["BordersFix8"],
                saiColorRGB["EmptyScrollBarBackground"],
                saiColorRGB["ScrollBarOutlineHoveredFix3"],
                saiColorRGB["saiFileInMenuBelowBackground"],
                saiColorRGB["FileMenuTreeTabsFix3"],
                saiColorRGB["FileMenuTreeTabsFix4"],
                saiColorRGB["FileMenuTreeTabsFix5"],
                saiColorRGB["FileMenuTreeTabsFix6"],
                saiColorRGB["FileMenuTreeTabsFix7"],
                saiColorRGB["FileMenuTreeTabsFix8"],
            ];
            foreach(byte[] n in TernaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, saiColorRGB["Ternary"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }
            theme.SetElementColorComplicated(saiColorRGB["LayerBackground"], saiColorRGB["Ternary"], saiAddress["LayerBackgroundFrom"], saiAddress["LayerBackgroundTo"], true);
            #endregion

            #region TEXT COLOR
            int[] TextItems = [
                saiAddress["BrushesSpecialText"],
                saiAddress["ContextMenuText"],
                saiAddress["ContextMenuTextHovered"],
                saiAddress["TopBarText"],
                saiAddress["TopBarTextHovered"],
                saiAddress["FileMenuScrollableText"],
                saiAddress["FileMenuTilesText"],
                saiAddress["BrushesText"],
                saiAddress["BrushesTabsText"],
                saiAddress["BrushesCirclesText"],
                saiAddress["ShitTextInWindows"],
            ];
            foreach(int n in TextItems) {
                theme.SetElementColor(themeColor["Text"], n);
            }

            byte[][] TextComplicatedItemsSrclibs = [ 
                saiColorRGB["ShitColoredText"],
                saiColorRGB["FileMenuTreeText"],
            ];
            foreach(byte[] n in TextComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, themeColor["Text"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"]);
            }

            // byte[][] TextComplicatedItemsAppskin = [];
            // foreach(byte[] n in TextComplicatedItemsAppskin) {
            //     theme.SetElementColorComplicated(n, themeColor["Text"], saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"]);
            // }
            #endregion

            #region SELECTABLE PRIMARY COLOR
            int[] SelectablePrimaryItems = [
                saiAddress["SlidersColor"],
                saiAddress["ContextMenuArrows"],
                saiAddress["ContextMenuArrowsHovered"],
                saiAddress["ContextMenuCheckBoxes"],
                saiAddress["ContextMenuCheckBoxesHovered"],
                saiAddress["ContextMenuCheckBoxesMarks"],
                saiAddress["ContextMenuCheckBoxesMarksHovered"],
                saiAddress["ContextMenuRadioButtons"],
                saiAddress["ContextMenuRadioButtonsEmpty"],
                saiAddress["ContextMenuRadioButtonsHovered"],
                saiAddress["saiFileInMenuBelowText"],
            ];
            foreach(int n in SelectablePrimaryItems) {
                theme.SetElementColor(themeColor["SelectablePrimary"], n);
            }
            byte[][] SelectablePrimaryComplicatedItemsSrclibsTrue = [
                saiColorRGB["SelectedElementOutlineActive"],
                saiColorRGB["SelectedElementOutlineHovered"],
                saiColorRGB["SelectedElementOutlineIdle"],
                saiColorRGB["SelectedElementBackgroundFocused"],
                saiColorRGB["SelectedElementOutlineFix1"],
                saiColorRGB["SelectedElementOutlineFix2"],
                saiColorRGB["SelectedElementOutlineFix3"],
                saiColorRGB["SelectedElementOutlineFix5"],
                saiColorRGB["SelectedElementOutlineFix6"],
                saiColorRGB["SelectedElementOutlineFix7"],
                saiColorRGB["SelectedElementOutlineFix8"],
                saiColorRGB["SelectedElementOutlineFix9"],
                saiColorRGB["SelectedElementOutlineFix10"],
                saiColorRGB["SelectedElementOutlineFix11"],
                saiColorRGB["ScrollBarFillHovered"],
                saiColorRGB["YesNoButtonsBackground"],
                saiColorRGB["ScrollBarAndServiceButtonsFill"],
                saiColorRGB["saiFileInMenuBelowBackgroundHovered"],
                saiColorRGB["FileMenuListElementsOutlineDefault"],
                saiColorRGB["FileMenuTreeTextFocused"],
            ];
            foreach(byte[] n in SelectablePrimaryComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, saiColorRGB["SelectablePrimary"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }

            byte[][] SelectablePrimaryComplicatedItemsAppskinTrue = [
                saiColorRGB["SelectedLayerOutlineActiveHovered"],
                saiColorRGB["SelectedLayerOutlineFocused"],
                saiColorRGB["SelectedLayerInnerOutlineActive"],
                saiColorRGB["SelectedLayerInnerOutlineHovered"],
                saiColorRGB["SelectedLayerInnerOutlineFocused"],
                saiColorRGB["SelectedLayerInnerOutlineGrabbed"],
                saiColorRGB["LayerBackgroundFocused"],
                saiColorRGB["SelectedLayerBackgroundGrabbed"],
                saiColorRGB["LayerBackgroundGrabbed"],
                saiColorRGB["FileMenuListCategoryArrows"],
            ];
            foreach(byte[] n in SelectablePrimaryComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, saiColorRGB["SelectablePrimary"], saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"], true);
            }
            #endregion

            #region SELECTABLE SECONDARY COLOR
            int[] SelectableSecondaryItems = [
                saiAddress["SlidersActiveBackground"],
                saiAddress["SlidersActiveBackgroundHoveredFocused"],
                saiAddress["saiFileInMenuBelowPercents"],
            ];
            foreach(int n in SelectableSecondaryItems) {
                theme.SetElementColor(themeColor["SelectableSecondary"], n);
            }

            byte[][] SelectableSecondaryComplicatedItemsAppskinTrue = [
                saiColorRGB["SelectedLayerBackgroundActive"],
                saiColorRGB["SelectedLayerBackgroundHovered"],
                saiColorRGB["SelectedLayerBackgroundFocused"],
            ];
            foreach(byte[] n in SelectableSecondaryComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, saiColorRGB["SelectableSecondary"], saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"], true);
            }

            byte[][] SelectableSecondaryComplicatedItemsSrclibsTrue = [
                saiColorRGB["ScrollBarFillFocused"],
                saiColorRGB["ScrollBarOutlineHovered"],
                saiColorRGB["ScrollBarOutlineHoveredFix1"],
                saiColorRGB["ScrollBarOutlineHoveredFix2"],
                saiColorRGB["ScrollBarOutlineFocused"],
                saiColorRGB["ScrollBarOutlineFocusedFix1"],
                saiColorRGB["ScrollBarOutlineFocusedFix2"],
                saiColorRGB["YesNoButtonsOutline"],
                saiColorRGB["YesNoButtonsOutlineFix1"],
                saiColorRGB["YesNoButtonsOutlineFix2"],
                saiColorRGB["YesNoButtonsOutlineFix3"],
                saiColorRGB["ScrollBarAndServiceButtonsOutline"],
                saiColorRGB["ScrollBarAndServiceButtonsOutlineFix1"],
                saiColorRGB["ScrollBarAndServiceButtonsOutlineFix2"],
                saiColorRGB["saiFileInMenuBelowOutlineHovered"],
                saiColorRGB["FileMenuTreeTextHovered"],
            ];
            foreach(byte[] n in SelectableSecondaryComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, saiColorRGB["SelectableSecondary"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
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
            appHelper = new AppHelper { };
        }
    }
}