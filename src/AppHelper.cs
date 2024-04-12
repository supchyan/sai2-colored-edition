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

        #region events
        public delegate void SetTheme();
        event SetTheme Set_Theme;

        public delegate void RestoreTheme();
        event RestoreTheme Restore_Theme;

        public delegate void GitHubLink();
        event GitHubLink GitHub_Link;

        public delegate void ExitApplication();
        event ExitApplication Exit_Application;
        #endregion

        #region events logic
        void _SetTheme() {
            if(!file.IsFileBusy(true))
            SetThemeToSelected();
        }
        void _RestoreTheme() {
            if(!file.IsFileBusy(true))
            RestoreThemeToDefault();
        }
        void _GithubLink() {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) { Process.Start(new ProcessStartInfo("cmd", $"/c start {path.GitHubLink}")); }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) { Process.Start("xdg-open", path.GitHubLink); }
        }
        void _ExitApplication() {
            Environment.Exit(0);
        }
        #endregion
        public void _Action() {
            var select = consoleDrawing.MenuSize - consoleDrawing.Selection;

            if(select >= 4) Set_Theme.Invoke();
            if(select == 2) Restore_Theme.Invoke();
            if(select == 1) GitHub_Link.Invoke();
            if(select == 0) Exit_Application.Invoke();
        }

        void SetThemeToSelected() {
            
            if(!file.IsOriginalFileExists(true)) { return; }

            // Creating backup file to restore data or replace original file
            // with backup one to recolor it:
            if(!file.IsOldFileExists()) { file.CreateOldFile(); }
            else {
                // This won't delete sai2.old.exe! Just cloning it to original one:
                file.ReplaceOriginalFile();
            }

            console.ShowWaitMessage();

            // Getting theme vaules:
            themeColor = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText($"{consoleDrawing.pubThemesList[consoleDrawing.Selection]}"))?.ConvertToByteColorDictionary();
            
            // Getting replacment libraries:
            saiAddress = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText(path.saiAddressFile))?.ConvertToDecimalAddressDictionary();
            saiColorARGB = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText(path.saiColorARGBFile))?.ConvertToByteColorDictionary();
            saiColorRGB = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText(path.saiColorRGBFile))?.ConvertToByteColorDictionaryRGB();
            
            // Returning if nothing to replace to:
            if(themeColor is null || saiAddress is null || saiColorARGB is null || saiColorRGB is null) { return; }
            
            // colorRGB.ConfigureRGBColors(themeColor, saiColorRGB);
            colorRGB.ConfigureArtifactsColors(themeColor["Secondary"].NoAlpha(), themeColor["Ternary"].NoAlpha());

            // Creating tmp .exe to replace binary data inside:
            if(!File.Exists(name.tmp)) { file.CreateTmpFile(); }

            // Reading tmp .exe:
            theme.binary = theme.ReadTmpFile(name.tmp);

            // Color picker. Little bit chunky, but not bad at all:
            theme.FixColorPicker(themeColor["Ternary"].NoAlpha(), saiAddress["ColorCircleFrom"], saiAddress["ColorCircleTo"]);

            // These regions is for elements, that has amount of artifacts under the main coloring,
            // so i found patterns, where it located and can be protectly colored, before main coloring processes:
            #region 0 PRIMARY COLOR
            theme.SetElementColorComplicated(saiColorRGB["SlidersBackgroundTransparent2"].NoAlpha(), themeColor["Primary"].NoAlpha(), saiAddress["SlidersBackgroundTransparentFrom"], saiAddress["SlidersBackgroundTransparentTo"]);

            theme.SetElementColorComplicated(saiColorRGB["ActiveCanvasBackgroundFix"], themeColor["Primary"], saiAddress["GlobalSectionTextFrom"], saiAddress["GlobalSectionTextTo"], true);

            #endregion

            #region 0 SECONDARY COLOR
            theme.SetElementColorWithTotalReplacment(themeColor["Secondary"].NoAlpha(), saiAddress["HoveredEmptyBrushesBackgroundFrom"], saiAddress["HoveredEmptyBrushesBackgroundTo"]);
            theme.SetElementColorWithTotalReplacment(themeColor["Secondary"].NoAlpha(), saiAddress["HoveredLayersBackgroundFrom"], saiAddress["HoveredLayersBackgroundTo"]);
            // theme.SetElementColorComplicated(saiColorRGB["ActiveCanvasBackgroundFix"], themeColor["Secondary"], saiAddress["GlobalSectionTextFrom"], saiAddress["GlobalSectionTextTo"], true);
            theme.SetElementColorComplicated(saiColorRGB["SlidersBackgroundTransparent1"].NoAlpha(), themeColor["Secondary"].NoAlpha(), saiAddress["SlidersBackgroundTransparentFrom"], saiAddress["SlidersBackgroundTransparentTo"]);
            byte[][] SlidersPrivelegySelectableTernaryTrue = [
                saiColorRGB["SlidersBackgroundTransparentLineFix1"],
                saiColorRGB["SlidersBackgroundTransparentLineFix2"]
            ];
            foreach(byte[] n in SlidersPrivelegySelectableTernaryTrue) {
                theme.SetElementColorComplicated(n.NoAlpha(), themeColor["Secondary"].NoAlpha(), saiAddress["SlidersBackgroundTransparentFrom"], saiAddress["SlidersBackgroundTransparentTo"]);
            }
            #endregion
            
            #region 0 TERNARY COLOR
            theme.SetElementColorComplicated(saiColorRGB["LayerBackground"], themeColor["Ternary"].NoAlpha(), saiAddress["LayerBackgroundFrom"], saiAddress["LayerBackgroundTo"], true);
            theme.SetElementColorComplicated(saiColorRGB["BrushesBackgroundFileMenuBackgroundScrollBlockBackground"], themeColor["Ternary"].NoAlpha(), saiAddress["BrushesFileMenuTilesScrollableListsBackgroundFrom"], saiAddress["BrushesFileMenuTilesScrollableListsBackgroundTo"]);
            #endregion

            #region 0 SELECTABLE PRIMARY COLOR
            byte[][] SlidersPrivelegySelectablePrimaryTrue = [
                saiColorRGB["SlidersBarBackgroundTransparent1"],
                saiColorRGB["SlidersBarBackgroundTransparentLineFix1"]
            ];
            foreach(byte[] n in SlidersPrivelegySelectablePrimaryTrue) {
                theme.SetElementColorComplicated(n.NoAlpha(), themeColor["SelectablePrimary"].NoAlpha(), saiAddress["SlidersBackgroundTransparentFrom"], saiAddress["SlidersBackgroundTransparentTo"]);
            }
            #endregion

            #region 0 SELECTABLE SECONDARY COLOR
            theme.SetElementColorComplicated(saiColorRGB["SlidersBarBackgroundTransparent2"].NoAlpha(), themeColor["SelectableSecondary"].NoAlpha(), saiAddress["SlidersBackgroundTransparentFrom"], saiAddress["SlidersBackgroundTransparentTo"]);
            #endregion

            // Main regions, which contains basic coloring operations:
            #region PRIMARY COLOR
            int[] PrimaryItems = [

                saiAddress["ActiveCanvasBackground"],
                saiAddress["ActiveCanvasBackground2"],
                saiAddress["ActiveCanvasBackground3"],
                saiAddress["ActiveCanvasBackground4"],

                saiAddress["InActiveCanvasBackground"],
                saiAddress["BehindLayersUIBackground"],
                saiAddress["BrushBorders"],
                saiAddress["SlidersVertical"],
                saiAddress["SlidersHorizontal"],
                saiAddress["ContextMenuArrowsFocused"],
                saiAddress["ContextMenuCheckBoxesMarksFocused"],
                saiAddress["ContextMenuCheckBoxesFocused"],
                saiAddress["ContextMenuRadioButtonsFocused"],
                saiAddress["InActiveText"],
                saiAddress["SliderBarHovered"],
                saiAddress["ScrollBarArrowUp"],
                saiAddress["ScrollBarArrowDown"],
                saiAddress["ScrollBarArrowLeft"],
                saiAddress["ScrollBarArrowRight"],
                saiAddress["ClosedListArrow"],
                saiAddress["GlobalTopBar"],
                saiAddress["ScaleAngleArrow"],
                saiAddress["ColorSlidersArrows"],
                saiAddress["ScaleAngleSliderFillLeft"],
                saiAddress["GreyNoteText"],
                saiAddress["SettingsListBackground"],
                saiAddress["RadioButtonsBackgroundActive"],
                saiAddress["OkCancelButtonsTextInActive"],
                saiAddress["AssetManagerLeftBackground"],
            ];
            foreach(int n in PrimaryItems) {
                theme.SetElementColor(themeColor["Primary"].NoAlpha(), n);
            }

            byte[][] PrimaryRGBComplicatedItemsSrclibsTrue = [
                saiColorRGB["FileMenuTreeTabsFix2"],
                saiColorRGB["BurgerButtonsOutline1"],
                saiColorRGB["BurgerButtonsOutline3"],
                saiColorRGB["BordersFix9"],
                saiColorRGB["saiFileInMenuBelowOutline"],
                saiColorRGB["saiFileInMenuBelowOutlineFix"],
                saiColorRGB["saiFileInMenuBelowInnerOutline"],
                saiColorRGB["BurgerButtonsOutlineSlidersOutline"],
                saiColorRGB["BurgerButtonsOutline4"],
                saiColorRGB["BurgerButtonsOutline2"],
                saiColorRGB["BordersFix1"],
                saiColorRGB["BordersFix2"],
                saiColorRGB["BordersFix3"],
                saiColorRGB["BordersFix4"],
                saiColorRGB["BordersFix5"],
                saiColorRGB["BordersFix6"],
                saiColorRGB["BordersFix7"],
                saiColorRGB["FileMenuListElementsBackgroundDefault"],
                saiColorRGB["InActiveBurgerButtonsOutline"],
                saiColorRGB["InActiveBurgerButtonsOutlineFix1"],
                saiColorRGB["InActiveBurgerButtonsOutlineFix2"],
            ];
            foreach(byte[] n in PrimaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, themeColor["Primary"].NoAlpha(), saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }

            byte[][] PrimaryRGBComplicatedItemsAppskinTrue = [
                saiColorRGB["LayerOutline"],
                saiColorRGB["FileMenuBackground"],
                saiColorRGB["FolderBehindBackground1"],
                saiColorRGB["FolderBehindBackground2"],
            ];
            foreach(byte[] n in PrimaryRGBComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, themeColor["Primary"].NoAlpha(), saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"], true);
            }
            #endregion

            #region SECONDARY COLOR
            int[] SecondaryItems = [
                // saiAddress["ActiveCanvasBackground"],
                // saiAddress["ActiveCanvasBackground2"],
                // saiAddress["ActiveCanvasBackground3"],
                // saiAddress["ActiveCanvasBackground4"],
                saiAddress["Separator"],
                saiAddress["TopBar"],
                saiAddress["ContextMenu"],
                saiAddress["SlidersInActiveBackground"],
                saiAddress["BookmarkBackgroundAndOutlinesSomewhere"],
                saiAddress["GlobalTopBarInActive"],
                saiAddress["FolderArrowOpened"],
                saiAddress["FolderArrowClosed"],
                saiAddress["ScaleAngleSliderFillRight"],
                saiAddress["TopBarTextFocused"],
                saiAddress["ContextMenuTextFocused"],
                saiAddress["SomeMinimizedListsBackground"],
                saiAddress["CheckBoxesBackground"],
                saiAddress["StabilizerBackground"],
                saiAddress["RadioButtonsBackground"],
                saiAddress["RadioButtonsBackgroundHovered"],
                saiAddress["PathLineInFileMenuBackground"],
            ];
            foreach(int n in SecondaryItems) {
                theme.SetElementColor(themeColor["Secondary"].NoAlpha(), n);
            }

            // byte[][] SecondaryComplicatedItemsSrclibs = [
            //     saiColorARGB["InActiveScrollBarsBackground"],
            //     saiColorARGB["EmptyElementsInBrushesUI"],
            //     saiColorARGB["ColorPickerCircleBody"],
            // ];
            // foreach(byte[] n in SecondaryComplicatedItemsSrclibs) {
            //     theme.SetElementColorComplicated(n, themeColor["Secondary"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"]);
            // }

            
            byte[][] SecondaryRGBComplicatedItemsAppskinTrue = [
                saiColorRGB["FolderBackgroundHovered"],
            ];
            foreach(byte[] n in SecondaryRGBComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, themeColor["Secondary"].NoAlpha(), saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"], true);
            }
                

            byte[][] SecondaryRGBComplicatedItemsSrclibsTrue = [
                saiColorRGB["SelectedElementBackgroundIdle"],
                saiColorRGB["SelectedElementBackgroundActive"],
                saiColorRGB["SelectedElementBackgroundHovered"],
                saiColorRGB["FileMenuListElementsBackgroundHovered"],
                saiColorRGB["BurgerButtonsOutlineFix"],
                colorRGB.SecondaryArtifactsColor1,
                colorRGB.SecondaryArtifactsColor2,
                colorRGB.SecondaryArtifactsColor3,
                colorRGB.SecondaryArtifactsColor4,
            ];
            foreach(byte[] n in SecondaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, themeColor["Secondary"].NoAlpha(), saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }
            #endregion

            #region TERNARY COLOR
            int[] TernaryItems = [
                saiAddress["GlobalBorders"],
                saiAddress["GlobalBorders2"],
                saiAddress["TabsResizeGrabberVertical"],
                saiAddress["ScaleAngleSliders"],
                saiAddress["ResizeWindowGrabber"],
                saiAddress["ContextMenuListBackground"],
                saiAddress["ContextMenuListSeparatorBackground"],
            ];
            foreach(int n in TernaryItems) {
                theme.SetElementColor(themeColor["Ternary"].NoAlpha(), n);
            }

            byte[][] TernaryRGBComplicatedItemsAppskinTrue = [
                saiColorRGB["EmptyElementsInBrushesUI"],
                saiColorRGB["FolderBackground"],
                // saiColorRGB["WhatIsThisColor2"],
            ];
            foreach(byte[] n in TernaryRGBComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, themeColor["Ternary"].NoAlpha(), saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"], true);
            }

            byte[][] TernaryRGBComplicatedItemsSrclibsTrue = [
                saiColorRGB["BordersFixBurgerButtonsBackgroundColorLinesBackground"],
                saiColorRGB["EmptyScrollBarBackground"],
                saiColorRGB["ScrollBarOutlineHoveredFix3"],
                saiColorRGB["saiFileInMenuBelowBackground"],
                saiColorRGB["FileMenuTreeTabsFix3"],
                saiColorRGB["FileMenuTreeTabsFix4"],
                saiColorRGB["FileMenuTreeTabsFix5"],
                saiColorRGB["FileMenuTreeTabsFix6"],
                saiColorRGB["FileMenuTreeTabsFix7"],
                saiColorRGB["FileMenuTreeTabsFix8"],
                colorRGB.TernaryArtifactsColor1,
                colorRGB.TernaryArtifactsColor2,
                colorRGB.TernaryArtifactsColor3,
                colorRGB.TernaryArtifactsColor4,
                colorRGB.TernaryArtifactsColor5,
                colorRGB.TernaryArtifactsColor6,
                colorRGB.TernaryArtifactsColor7,
                colorRGB.TernaryArtifactsColor8,
            ];
            foreach(byte[] n in TernaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, themeColor["Ternary"].NoAlpha(), saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }
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
                saiAddress["BrushesTextFix"],
                saiAddress["BrushesTabsText"],
                saiAddress["BrushesCirclesText"],
                saiAddress["ShitTextInWindows"],
                saiAddress["FolderOverlayText"],
                saiAddress["BrushCircles"],
                saiAddress["WindowTitles"],
                saiAddress["OkCancelButtonsText"],
                saiAddress["OkCancelButtonsTextHovered"],
                saiAddress["OkCancelButtonsTextFocused1"],
                saiAddress["OkCancelButtonsTextFocused2"],
                saiAddress["OkCancelButtonsTextFocused3"],
                saiAddress["OkCancelButtonsTextDisfocused1"],
                saiAddress["OkCancelButtonsTextDisfocused2"],
                saiAddress["OkCancelButtonsTextDisfocused3"],
            ];
            foreach(int n in TextItems) {
                theme.SetElementColor(themeColor["Text"].NoAlpha(), n);
            }

            byte[][] TextComplicatedItemsSrclibs = [
                // This should has alpha channel to be replaced properly
                saiColorRGB["ShitColoredText"],
                saiColorRGB["FileMenuTreeText"],
            ];
            foreach(byte[] n in TextComplicatedItemsSrclibs) {
                theme.SetElementColorComplicated(n, themeColor["Text"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"]);
            }

            // byte[][] TextComplicatedItemsTextTrue = [
            //     saiColorRGB["FolderOverlayText"],
            // ];
            // foreach(byte[] n in TextComplicatedItemsTextTrue) {
            //     theme.SetElementColorComplicated(n, themeColor["Text"].NoAlpha(), saiAddress["GlobalSectionTextFrom"], saiAddress["GlobalSectionTextTo"],true);
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
                saiAddress["ButtonsInLayersFill"],
                saiAddress["BlueNoteText"],
                saiAddress["FolderArrowHovered1"],
                saiAddress["FolderArrowHovered2"],
            ];
            foreach(int n in SelectablePrimaryItems) {
                theme.SetElementColor(themeColor["SelectablePrimary"].NoAlpha(), n);
            }

            byte[][] SelectablePrimaryComplicatedItemsTextTrue = [
                saiColorRGB["BlueSelectableElementsText"],
            ];
            foreach(byte[] n in SelectablePrimaryComplicatedItemsTextTrue) {
                theme.SetElementColorComplicated(n, themeColor["SelectablePrimary"].NoAlpha(), saiAddress["GlobalSectionTextFrom"], saiAddress["GlobalSectionTextTo"], true);
            }

            byte[][] SelectablePrimaryRGBComplicatedItemsSrclibsTrue = [
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
                saiColorRGB["BlueSelectableElements"],
                saiColorRGB["ServiceButtonsOutline"],
                saiColorRGB["ServiceButtonsOutlineFix1"],
                saiColorRGB["ServiceButtonsOutlineFix2"],
                saiColorRGB["ServiceButtonsOutlineFocused"],
                saiColorRGB["ServiceButtonsOutlineFocusedFix1"],
                saiColorRGB["ServiceButtonsOutlineFocusedFix2"],
                saiColorRGB["ServiceButtonsBackgroundAndOutlineFocused"],
                saiColorRGB["BrushesBackgroundGrabbed"],
                saiColorRGB["BrushesOutlineGrabbed"],
                saiColorRGB["ServiceButtonsBackground2"],
                saiColorRGB["ServiceButtonsOutline2"],
                saiColorRGB["ServiceButtonsOutline2Fix1"],
                saiColorRGB["ServiceButtonsOutline2Fix2"],
                saiColorRGB["ServiceButtonsOutline2Fix3"],
                saiColorRGB["ServiceButtonsOutline2Fix4"],
                saiColorRGB["ServiceButtonsBackground3"],
                saiColorRGB["ServiceButtonsOutline3"],
                saiColorRGB["ServiceButtonsOutline3Fix1"],
                saiColorRGB["ServiceButtonsOutline3Fix2"],
                saiColorRGB["ServiceButtonsOutline3Fix3"],
                saiColorRGB["AnotherSelectableOutlineFocused"],
                saiColorRGB["AnotherSelectableOutlineFocusedFix1"],
                saiColorRGB["AnotherSelectableOutlineFocusedFix2"],
                saiColorRGB["AnotherSelectableInnerOutlineFocused"],
                saiColorRGB["AnotherSelectableInnerOutlineFocusedFix"],
                saiColorRGB["SelectableBackgroundRightClicked"],
                saiColorRGB["BurgerButtonsOutlineRightClicked1"],
                saiColorRGB["BurgerButtonsOutlineRightClicked2"],
                saiColorRGB["BurgerButtonsOutlineRightClicked3"],
                saiColorRGB["BurgerButtonsOutlineRightClicked4"],
            ];
            foreach(byte[] n in SelectablePrimaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, themeColor["SelectablePrimary"].NoAlpha(), saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }

            byte[][] SelectablePrimaryRGBComplicatedItemsAppskinTrue = [
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
                saiColorRGB["FolderOutlineSelected"],
                saiColorRGB["FolderInnerOutlineSelected"],
                saiColorRGB["FolderBackgroundSelectedFocused2"],
                saiColorRGB["FolderOutlineSelectedFocused"],
                saiColorRGB["FolderInnerOutlineSelectedHovered"],
                saiColorRGB["FolderInnerOutlineSelectedFocused1"],
                saiColorRGB["FolderInnerOutlineSelectedFocused2"],
                saiColorRGB["FolderServiceButtonsSelectedFocused"],
            ];
            foreach(byte[] n in SelectablePrimaryRGBComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, themeColor["SelectablePrimary"].NoAlpha(), saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"], true);
            }
            #endregion

            #region SELECTABLE SECONDARY COLOR
            int[] SelectableSecondaryItems = [
                saiAddress["SlidersActiveBackground"],
                saiAddress["SlidersActiveBackgroundHoveredFocused"],
                saiAddress["saiFileInMenuBelowPercents"],
            ];
            foreach(int n in SelectableSecondaryItems) {
                theme.SetElementColor(themeColor["SelectableSecondary"].NoAlpha(), n);
            }

            byte[][] SelectableSecondaryRGBComplicatedItemsAppskinTrue = [
                saiColorRGB["SelectedLayerBackgroundActive"],
                saiColorRGB["SelectedLayerBackgroundHovered"],
                saiColorRGB["SelectedLayerBackgroundFocused"],
                saiColorRGB["FolderBackgroundFocused1"],
                saiColorRGB["FolderBackgroundFocused2"],
                saiColorRGB["FolderBackgroundSelectedFocused1"],
                saiColorRGB["FolderBackgroundSelected1"],
                saiColorRGB["FolderBackgroundSelected2"],
            ];
            foreach(byte[] n in SelectableSecondaryRGBComplicatedItemsAppskinTrue) {
                theme.SetElementColorComplicated(n, themeColor["SelectableSecondary"].NoAlpha(), saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"], true);
            }

            byte[][] SelectableSecondaryRGBComplicatedItemsSrclibsTrue = [
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
                saiColorRGB["BrushesButtonsBackgroundRightClicked"],
                saiColorRGB["BurgerButtonsBackgroundRightClicked"],
            ];
            foreach(byte[] n in SelectableSecondaryRGBComplicatedItemsSrclibsTrue) {
                theme.SetElementColorComplicated(n, themeColor["SelectableSecondary"].NoAlpha(), saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }
            #endregion

            // Saving current theme changes:
            theme.SaveTheme();
            
        }
        void RestoreThemeToDefault() {
            if(!file.IsOldFileExists(true)) { return; }

            console.ShowWaitMessage();

            if(File.Exists(name.original)) { File.Delete(name.original); }
            file.ReplaceOriginalFile();
            file.DeleteOldFile();

            console.SendMessage(message.DefaultThemeHasBeenRestored, ConsoleColor.DarkGreen);
        }
        public AppHelper() {
            Set_Theme += _SetTheme;
            Restore_Theme += _RestoreTheme;
            GitHub_Link += _GithubLink;
            Exit_Application += _ExitApplication; 
        }
    }
}