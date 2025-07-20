using System.Text.Json;
using System.IO;
using System.Diagnostics;
using S2CE.Tools;
using S2CE.Extensions;

namespace S2CE {
    class MainTheme {
        FileS2CE file = new();
        ThemeS2CE theme = new();
        ColorS2CE colorRGB = new();

        Dictionary<string, byte[]>? themeColor { get; set; }
        Dictionary<string, int>? saiAddress { get; set; }
        Dictionary<string, byte[]>? saiColorRGB { get; set; }

        public void Apply(string themeName) {

            if (themeName == "classic_sai2")
            {
                try
                {
                    file.UpdateOriginalFile();
                    file.DeleteOldFile();
                    Process.Start(PathS2CE.sai2);
                    Environment.Exit(0);
                }
                catch { }
                return;
            }

            // Creating backup file to restore data or replace original file
            // with backup one to recolor it:
            if (!file.IsOldFileExists()) { file.CreateOldFile(); }

            // Getting theme vaules:
            themeColor = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText($"./themes/{themeName}.json"))?.ConvertToByteColorDictionary();

            // Getting replacment libraries:
            saiAddress = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("./ref/init/data/Address.json"))?.ConvertToDecimalAddressDictionary();
            saiColorRGB = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("./ref/init/data/ColorRGB.json"))?.ConvertToByteColorDictionaryRGB();

            // Returning if nothing to replace to:
            if (themeColor is null || saiAddress is null || saiColorRGB is null) { return; }

            // colorRGB.ConfigureRGBColors(themeColor, saiColorRGB);
            colorRGB.ConfigureArtifactsColors(themeColor["Secondary"].NoAlpha(), themeColor["Ternary"].NoAlpha());

            // Color picker. Little bit chunky, but not bad at all:
            Thread partOne = new Thread(() => {
                theme.FixColorPicker(themeColor["Ternary"].NoAlpha(), saiAddress["ColorCircleFrom"], saiAddress["ColorCircleTo"]);
            }) { IsBackground = true };

            Thread partTwo = new Thread(() => {
                theme.FixColorPicker(themeColor["Ternary"].NoAlpha(), saiAddress["ColorCircleFrom2"], saiAddress["ColorCircleTo2"]);
            }) { IsBackground = true };

            Thread partThree = new Thread(() => {
                theme.FixColorPicker(themeColor["Ternary"].NoAlpha(), saiAddress["ColorCircleFrom3"], saiAddress["ColorCircleTo3"]);
            }) { IsBackground = true };

            Thread partFour = new Thread(() => {
                theme.FixColorPicker(themeColor["Ternary"].NoAlpha(), saiAddress["ColorCircleFrom4"], saiAddress["ColorCircleTo4"]);
            }) { IsBackground = true };

            partOne.Start();
            partTwo.Start();
            partThree.Start();
            partFour.Start();

            // These regions is for elements, that has amount of artifacts under the main coloring,
            // so i found patterns, where it located and can be protectly colored, before main coloring processes:
            #region 0 PRIMARY COLOR
            theme.SetElementColorComplicated(saiColorRGB["SlidersBackgroundTransparent2"].NoAlpha(), themeColor["Primary"].NoAlpha(), saiAddress["SlidersBackgroundTransparentFrom"], saiAddress["SlidersBackgroundTransparentTo"]);
            theme.SetElementColorComplicated(saiColorRGB["ActiveCanvasBackgroundFix"], themeColor["Primary"], saiAddress["GlobalSectionTextFrom"], saiAddress["GlobalSectionTextTo"], true);
            #endregion

            #region 0 SECONDARY COLOR
            theme.SetElementColorWithTotalReplacment(themeColor["Secondary"].NoAlpha(), saiAddress["HoveredEmptyBrushesBackgroundFrom"], saiAddress["HoveredEmptyBrushesBackgroundTo"]);
            theme.SetElementColorWithTotalReplacment(themeColor["Secondary"].NoAlpha(), saiAddress["HoveredLayersBackgroundFrom"], saiAddress["HoveredLayersBackgroundTo"]);
            theme.SetElementColorComplicated(saiColorRGB["SelectedElementBackgroundHovered"].NoAlpha(), themeColor["Secondary"].NoAlpha(), saiAddress["HoveredLayersBackgroundFrom2"], saiAddress["HoveredLayersBackgroundTo2"], true);
            theme.SetElementColorComplicated(saiColorRGB["SlidersBackgroundTransparent1"].NoAlpha(), themeColor["Secondary"].NoAlpha(), saiAddress["SlidersBackgroundTransparentFrom"], saiAddress["SlidersBackgroundTransparentTo"]);
            byte[][] SlidersPrivelegySelectableTernaryTrue = [
                saiColorRGB["SlidersBackgroundTransparentLineFix1"],
            saiColorRGB["SlidersBackgroundTransparentLineFix2"]
            ];
            foreach (byte[] n in SlidersPrivelegySelectableTernaryTrue)
            {
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
            foreach (byte[] n in SlidersPrivelegySelectablePrimaryTrue)
            {
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
                saiAddress["BehindLayersUIBackground2"],
                saiAddress["BehindLayersUIBackground3"],
                saiAddress["BehindLayersUIBackground4"],
                saiAddress["BrushBorders"],
                saiAddress["SlidersVertical"],
                saiAddress["SlidersHorizontal"],
                saiAddress["InActiveText"],
                saiAddress["SliderBarHovered"],
                saiAddress["ScrollBarArrowUp"],
                saiAddress["ScrollBarArrowDown"],
                saiAddress["ScrollBarArrowLeft"],
                saiAddress["ScrollBarArrowRight"],
                saiAddress["ClosedListArrow"],
                saiAddress["GlobalTopBar"],
                saiAddress["GlobalTopBar2"],
                saiAddress["GlobalTopBar3"],
                saiAddress["GlobalTopBar4"],
                saiAddress["GlobalTopBar5"],
                saiAddress["GlobalTopBar6"],
                saiAddress["GlobalTopBar7"],
                saiAddress["GlobalTopBar8"],
                saiAddress["ScaleAngleArrow"],
                saiAddress["ColorSlidersArrows"],
                saiAddress["GreyNoteText"],
                saiAddress["SettingsListBackground"],
                saiAddress["SettingsListBackground2"],
                saiAddress["SettingsListBackground3"],
                saiAddress["SettingsListBackground4"],
                saiAddress["OkCancelButtonsTextInActive"],
                saiAddress["AssetManagerLeftBackground"],
                saiAddress["ScaleAngleSliders2"],
                saiAddress["ScaleAngleSliders3"],
                saiAddress["ScaleAngleSliders4"],
                saiAddress["ScaleAngleSliders5"],
                saiAddress["ScaleAngleSliders6"],
                saiAddress["ScaleAngleSliders7"],
                saiAddress["ScaleAngleSliders8"],
                saiAddress["ScaleAngleSliders9"],
                saiAddress["ScaleAngleSliders10"],
                saiAddress["ScaleAngleSliders11"],
                saiAddress["ScaleAngleSliders12"],
                saiAddress["ScaleAngleSliders13"],
                saiAddress["ScaleAngleSliders14"],
                saiAddress["ScaleAngleSliders15"],
            ];
            foreach (int n in PrimaryItems)
            {
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
                saiColorRGB["BordersFix8"],
                saiColorRGB["BordersFix10"],
                saiColorRGB["BordersFix11"],
                saiColorRGB["BordersFix12"],
                saiColorRGB["BordersFix14"],
                saiColorRGB["Separators"],
                saiColorRGB["FileMenuListElementsBackgroundDefault"],
                saiColorRGB["InActiveBurgerButtonsOutline"],
                saiColorRGB["InActiveBurgerButtonsOutlineFix1"],
                saiColorRGB["InActiveBurgerButtonsOutlineFix2"],
            ];
            foreach (byte[] n in PrimaryRGBComplicatedItemsSrclibsTrue)
            {
                theme.SetElementColorComplicated(n, themeColor["Primary"].NoAlpha(), saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }

            byte[][] PrimaryRGBComplicatedItemsAppskinTrue = [
                saiColorRGB["BordersFix13"],
                saiColorRGB["BordersFix15"],
                saiColorRGB["BordersFix16"],
                saiColorRGB["LayerOutline"],
                saiColorRGB["FileMenuBackground"],
                saiColorRGB["FolderBehindBackground1"],
                saiColorRGB["FolderBehindBackground2"],
            ];
            foreach (byte[] n in PrimaryRGBComplicatedItemsAppskinTrue)
            {
                theme.SetElementColorComplicated(n, themeColor["Primary"].NoAlpha(), saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"], true);
            }
            #endregion

            #region SECONDARY COLOR
            int[] SecondaryItems = [
                saiAddress["Separator"],
                saiAddress["TopBar"],
                saiAddress["TopBar2"],
                saiAddress["TopBar3"],
                saiAddress["TopBar4"],
                saiAddress["ContextMenu"],
                saiAddress["ContextMenu2"],
                saiAddress["ContextMenu3"],
                saiAddress["ContextMenu4"],
                saiAddress["SlidersInActiveBackground"],
                saiAddress["BookmarkBackgroundAndOutlinesSomewhere"],
                saiAddress["GlobalTopBarInActive"],
                saiAddress["GlobalTopBarInActive2"],
                saiAddress["GlobalTopBarInActive3"],
                saiAddress["GlobalTopBarInActive4"],
                saiAddress["TopBarTextFocused"],
                saiAddress["TopBarTextFocused2"],
                saiAddress["TopBarTextFocused3"],
                saiAddress["TopBarTextFocused4"],
                saiAddress["SomeMinimizedListsBackground"],
                saiAddress["CheckBoxesBackground"],
                saiAddress["StabilizerBackground"],
                saiAddress["PathLineInFileMenuBackground"],
            ];
            foreach (int n in SecondaryItems)
            {
                theme.SetElementColor(themeColor["Secondary"].NoAlpha(), n);
            }


            byte[][] SecondaryRGBComplicatedItemsAppskinTrue = [
                saiColorRGB["FolderBackgroundHovered"],
                saiColorRGB["BordersFix17"],
                saiColorRGB["BordersFix18"],
            ];
            foreach (byte[] n in SecondaryRGBComplicatedItemsAppskinTrue)
            {
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
            foreach (byte[] n in SecondaryRGBComplicatedItemsSrclibsTrue)
            {
                theme.SetElementColorComplicated(n, themeColor["Secondary"].NoAlpha(), saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }
            #endregion

            #region TERNARY COLOR
            int[] TernaryItems = [
                saiAddress["ScaleAngleSlidersBg"],
                saiAddress["GlobalBorders"],
                saiAddress["GlobalBorders2"],
                saiAddress["TabsResizeGrabberVertical"],
                saiAddress["ResizeWindowGrabber"],
                saiAddress["ContextMenuListBackground"],
                saiAddress["ContextMenuListSeparatorBackground"],
            ];
            foreach (int n in TernaryItems)
            {
                theme.SetElementColor(themeColor["Ternary"].NoAlpha(), n);
            }

            byte[][] TernaryRGBComplicatedItemsAppskinTrue = [
                saiColorRGB["EmptyElementsInBrushesUI"],
                saiColorRGB["FolderBackground"],
            ];
            foreach (byte[] n in TernaryRGBComplicatedItemsAppskinTrue)
            {
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
            foreach (byte[] n in TernaryRGBComplicatedItemsSrclibsTrue)
            {
                theme.SetElementColorComplicated(n, themeColor["Ternary"].NoAlpha(), saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }
            #endregion

            #region TEXT COLOR
            int[] TextItems = [
                saiAddress["BrushesBlueText"],
                saiAddress["BrushesBlueText2"],
                saiAddress["BrushesBlueText3"],
                saiAddress["TopBarText"],
                saiAddress["TopBarText2"],
                saiAddress["TopBarText3"],
                saiAddress["TopBarText4"],
                saiAddress["TopBarTextHovered"],
                saiAddress["TopBarTextHovered2"],
                saiAddress["TopBarTextHovered3"],
                saiAddress["TopBarTextHovered4"],
                saiAddress["FileMenuScrollableText"],
                saiAddress["FileMenuScrollableText2"],
                saiAddress["FileMenuScrollableText3"],
                saiAddress["FileMenuScrollableText4"],
                saiAddress["FileMenuTilesText"],
                saiAddress["FileMenuTilesText2"],
                saiAddress["FileMenuTilesText3"],
                saiAddress["FileMenuTilesText4"],
                saiAddress["BrushesText"],
                saiAddress["BrushesText2"],
                saiAddress["BrushesText3"],
                saiAddress["BrushesText4"],
                saiAddress["BrushesText5"],
                saiAddress["BrushesText6"],
                saiAddress["BrushesText7"],
                saiAddress["BrushesText8"],
                saiAddress["BrushesText9"],
                saiAddress["BrushesText10"],
                saiAddress["BrushesText11"],
                saiAddress["BrushesText12"],
                saiAddress["BrushesText13"],
                saiAddress["BrushesText14"],
                saiAddress["BrushesText15"],
                saiAddress["BrushesText16"],
                saiAddress["BrushesText17"],
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
                saiAddress["ContextMenuContent"],
                saiAddress["ContextMenuContent2"],
                saiAddress["ContextMenuContent3"],
                saiAddress["ContextMenuContent4"],
                saiAddress["ContextMenuContent5"],
                saiAddress["ContextMenuContent6"],
                saiAddress["ContextMenuContent7"],
                saiAddress["ContextMenuContent8"],
                saiAddress["ContextMenuContent9"],
                saiAddress["ContextMenuContent10"],
                saiAddress["ContextMenuContent11"],
                saiAddress["ContextMenuContent12"],
                saiAddress["ContextMenuContent13"],
                saiAddress["ContextMenuContent14"],
                saiAddress["ContextMenuContent15"],
                saiAddress["ContextMenuContent16"],
                saiAddress["ContextMenuContent17"],
                saiAddress["ContextMenuContent18"],
                saiAddress["ContextMenuContent19"],
                saiAddress["ContextMenuContent20"],
                saiAddress["ContextMenuContent21"],
                saiAddress["ContextMenuContent22"],
                saiAddress["ContextMenuContent23"],
                saiAddress["ContextMenuContent24"],
                saiAddress["ContextMenuContent25"],
                saiAddress["ContextMenuContent26"],
                saiAddress["ContextMenuContent27"],
                saiAddress["ContextMenuContent28"],
                saiAddress["ContextMenuContent29"],
                saiAddress["ContextMenuContent30"],
                saiAddress["ContextMenuContent31"],
                saiAddress["ContextMenuContent32"],
                saiAddress["ContextMenuContent33"],
                saiAddress["ContextMenuContent34"],
                saiAddress["ContextMenuContent35"],
                saiAddress["ContextMenuContent36"],
                saiAddress["ContextMenuContent37"],
                saiAddress["ContextMenuContent38"],
                saiAddress["ContextMenuContent39"],
                saiAddress["ContextMenuContent40"],
                saiAddress["ContextMenuContent41"],
                saiAddress["ContextMenuContent42"],
                saiAddress["ContextMenuContent43"],
                saiAddress["ContextMenuContent44"],
                saiAddress["ContextMenuContent45"],
                saiAddress["ContextMenuContent46"],
                saiAddress["ContextMenuContent47"],
                saiAddress["ContextMenuContent48"],
                saiAddress["ContextMenuContent49"],
                saiAddress["ContextMenuContent50"],
                saiAddress["ContextMenuContent51"],
                saiAddress["ContextMenuContent52"],
                saiAddress["ContextMenuContent53"],
                saiAddress["ContextMenuContent54"],
                saiAddress["ContextMenuContent55"],
                saiAddress["ContextMenuContent56"],
                saiAddress["ContextMenuContent57"],
                saiAddress["ContextMenuContent58"],
                saiAddress["ContextMenuContent59"],
                saiAddress["ContextMenuContent60"],
                saiAddress["ContextMenuContent61"],
                saiAddress["ContextMenuContent62"],
                saiAddress["ContextMenuContent63"],
                saiAddress["ContextMenuContent64"],
                saiAddress["ContextMenuContent65"],
                saiAddress["ContextMenuContent66"],
                saiAddress["ContextMenuContent67"],
                saiAddress["ContextMenuContent68"],
                saiAddress["ContextMenuContent69"],
                saiAddress["ContextMenuContent70"],
                saiAddress["ContextMenuContent71"],
                saiAddress["ContextMenuContent72"],
                saiAddress["ContextMenuContent73"],
                saiAddress["ContextMenuContent74"],
                saiAddress["ContextMenuContent75"],
                saiAddress["ContextMenuContent76"],
                saiAddress["ContextMenuContent77"],
                saiAddress["ContextMenuContent78"],
                saiAddress["ContextMenuContent79"],
                saiAddress["ContextMenuContent80"],
                saiAddress["ContextMenuContent81"],
                saiAddress["ContextMenuContent82"],
                saiAddress["ContextMenuContent83"],
                saiAddress["ContextMenuContent84"],
                saiAddress["ContextMenuContent85"],
                saiAddress["ContextMenuContent86"],
                saiAddress["ContextMenuContent87"],
                saiAddress["ContextMenuContent88"],
                saiAddress["ContextMenuContent89"],
                saiAddress["ContextMenuContent90"],
                saiAddress["ContextMenuContent91"],
                saiAddress["ContextMenuContent92"],
                saiAddress["ContextMenuContent93"],
                saiAddress["ContextMenuContent94"],
                saiAddress["ContextMenuContent95"],
                saiAddress["ContextMenuContent96"],
                saiAddress["ContextMenuContent97"],
                saiAddress["ContextMenuContent98"],
                saiAddress["ContextMenuContent99"],
                saiAddress["ContextMenuContent100"],
                saiAddress["ContextMenuContent101"],
                saiAddress["ContextMenuContent102"],
                saiAddress["ContextMenuContent103"],
                saiAddress["ContextMenuContent104"],
                saiAddress["ContextMenuContent105"],
                saiAddress["ContextMenuContent106"],
                saiAddress["ContextMenuContent107"],
                saiAddress["ContextMenuContent108"],
                saiAddress["ContextMenuContent109"],
                saiAddress["ContextMenuContent110"],
                saiAddress["ContextMenuContent111"],
                saiAddress["ContextMenuContent112"],
                saiAddress["ContextMenuContent113"],
                saiAddress["ContextMenuContent114"],
                saiAddress["ContextMenuContent115"],
                saiAddress["ContextMenuContent116"],
                saiAddress["ContextMenuContent117"],
                saiAddress["ContextMenuContent118"],
                saiAddress["ContextMenuContent119"],
                saiAddress["ContextMenuContent120"],
            ];
            foreach (int n in TextItems)
            {
                theme.SetElementColor(themeColor["Text"].NoAlpha(), n);
            }

            byte[][] TextComplicatedItemsSrclibs = [
                // This should has alpha channel to be replaced properly
                saiColorRGB["ShitColoredText"],
                saiColorRGB["FileMenuTreeText"],
            ];
            foreach (byte[] n in TextComplicatedItemsSrclibs)
            {
                theme.SetElementColorComplicated(n, themeColor["Text"], saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"]);
            }
            #endregion

            #region SELECTABLE PRIMARY COLOR
            int[] SelectablePrimaryItems = [
                saiAddress["SlidersColor"],
                saiAddress["saiFileInMenuBelowText"],
                saiAddress["ButtonsInLayersFill"],
                saiAddress["BlueNoteText"],
            ];
            foreach (int n in SelectablePrimaryItems)
            {
                theme.SetElementColor(themeColor["SelectablePrimary"].NoAlpha(), n);
            }

            byte[][] SelectablePrimaryComplicatedItemsTextTrue = [
                saiColorRGB["BlueSelectableElementsText"],
            ];
            foreach (byte[] n in SelectablePrimaryComplicatedItemsTextTrue)
            {
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
                saiColorRGB["BurgerButtonsOutlineRightClicked4"],
            ];
            foreach (byte[] n in SelectablePrimaryRGBComplicatedItemsSrclibsTrue)
            {
                theme.SetElementColorComplicated(n, themeColor["SelectablePrimary"].NoAlpha(), saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }

            byte[][] SelectablePrimaryRGBComplicatedItemsAppskinTrue = [
                saiColorRGB["BlueFixesHovered"],
                saiColorRGB["GreyFixesClosed"],
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
            foreach (byte[] n in SelectablePrimaryRGBComplicatedItemsAppskinTrue)
            {
                theme.SetElementColorComplicated(n, themeColor["SelectablePrimary"].NoAlpha(), saiAddress["GlobalSectionAppskinFrom"], saiAddress["GlobalSectionAppskinTo"], true);
            }
            #endregion

            #region SELECTABLE SECONDARY COLOR
            int[] SelectableSecondaryItems = [
                saiAddress["SlidersActiveBackground"],
                saiAddress["SlidersActiveBackgroundHoveredFocused"],
                saiAddress["saiFileInMenuBelowPercents"],
            ];
            foreach (int n in SelectableSecondaryItems)
            {
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
            foreach (byte[] n in SelectableSecondaryRGBComplicatedItemsAppskinTrue)
            {
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
                saiColorRGB["YesNoButtonsOutlineFix4"],
                saiColorRGB["YesNoButtonsOutlineFix5"],
                saiColorRGB["YesNoButtonsOutlineFix6"],
                saiColorRGB["YesNoButtonsOutlineFix7"],
                saiColorRGB["YesNoButtonsOutlineFix8"],
                saiColorRGB["YesNoButtonsOutlineFix9"],
                saiColorRGB["YesNoButtonsOutlineFix10"],
                saiColorRGB["YesNoButtonsOutlineFix11"],
                saiColorRGB["YesNoButtonsOutlineFix12"],
                saiColorRGB["YesNoButtonsOutlineFix13"],
                saiColorRGB["YesNoButtonsOutlineFix14"],
                saiColorRGB["YesNoButtonsOutlineFix15"],
                saiColorRGB["ScrollBarAndServiceButtonsOutline"],
                saiColorRGB["ScrollBarAndServiceButtonsOutlineFix1"],
                saiColorRGB["ScrollBarAndServiceButtonsOutlineFix2"],
                saiColorRGB["saiFileInMenuBelowOutlineHovered"],
                saiColorRGB["FileMenuTreeTextHovered"],
                saiColorRGB["BrushesButtonsBackgroundRightClicked"],
                saiColorRGB["BurgerButtonsBackgroundRightClicked"],
                saiColorRGB["TopbarOutlineFix"],
                saiColorRGB["TopbarOutlineFix2"],
                saiColorRGB["TopbarOutlineFix3"],
                saiColorRGB["TopbarOutlineFix4"],
            ];
            foreach (byte[] n in SelectableSecondaryRGBComplicatedItemsSrclibsTrue)
            {
                theme.SetElementColorComplicated(n, themeColor["SelectableSecondary"].NoAlpha(), saiAddress["GlobalSectionSrclibsFrom"], saiAddress["GlobalSectionSrclibsTo"], true);
            }
            #endregion

            // Saving current theme changes:
            theme.SaveTheme();
            Process.Start(PathS2CE.sai2);
            Environment.Exit(0);

        }
        public MainTheme() { }
    }
}