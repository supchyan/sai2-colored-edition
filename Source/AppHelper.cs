using System.Text.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YumToolkit.Global;
using YumToolkit.Core;
using YumToolkit.Core.UI;
using YumToolkit.Core.Data;

namespace YumToolkit {

    // Unneccessary stuff, to be stored here, but i did it to free space in App.cs
    class AppHelper {
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
            int index = _ConsoleDrawing.Get.MaxListValue - _ConsoleDrawing.Get.Choice;
            if(index > 3) index = 3;

            switch(index) {
                
                case 0: 
                    Environment.Exit(0);
                break;

                case 1:
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) { Process.Start(new ProcessStartInfo("cmd", $"/c start {_Path.Get.GitHubLink}")); }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) { Process.Start("xdg-open", _Path.Get.GitHubLink); }
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

            if(!File.Exists(_Name.Get.original)) { _Console.Get.SendMessage(_ServiceMessage.Get.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }

            // Creating backup file to restore data or replace original file
            // with backup one to recolor it:
            if(!File.Exists(_Name.Get.old)) { _File.Get.CreateOldFile(); }
            else {
                File.Delete(_Name.Get.original);
                // This won't delete sai2.old.exe! Just cloning it to original one:
                _File.Get.ReplaceOriginalFile();
            }
            

            // Reading theme file:
            ThemeColors = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText($"{_ConsoleDrawing.Get.ThemesList[_ConsoleDrawing.Get.Choice]}"));
            
            // Returning if nothing to replace to:
            if(ThemeColors is null) return;
            
            // Applying colors to... colors:
            _Color.Get.Primary = ThemeColors["Primary"].toByteColor();
            _Color.Get.Secondary = ThemeColors["Secondary"].toByteColor();
            _Color.Get.Ternary = ThemeColors["Ternary"].toByteColor();
            _Color.Get.Text = ThemeColors["Text"].toByteColor();

            _SemiColor.Get.SecondaryRGB = _Color.Get.Secondary.NoAlpha();
            _SemiColor.Get.TernaryRGB = _Color.Get.Ternary.NoAlpha();

            // Creating tmp .exe to replace binary data inside:
            if(!File.Exists(_Name.Get.tmp)) { _File.Get.CreateTmpFile(); }

            // Too glitchy, so I decided to disable canvas bg recoloring rn:
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.ActiveCanvasBackground);
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.ActiveCanvasBackground2);
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.ActiveCanvasBackground3);
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.ActiveCanvasBackground4);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionText[0], _Address.Get.GlobalSectionText[1], _Color.Get.DefaultColor17, true);
           

            _Theme.Get.SetElementColor(_Color.Get.Primary, _Address.Get.InActiveCanvasBackground);
            _Theme.Get.SetElementColor(_Color.Get.Primary, _Address.Get.BehindLayersUIBackground);
            _Theme.Get.SetElementColor(_Color.Get.Primary, _Address.Get.BrushBorders);
            _Theme.Get.SetElementColor(_Color.Get.Primary, _Address.Get.SlidersVertical);
            _Theme.Get.SetElementColor(_Color.Get.Primary, _Address.Get.SlidersHorizontal);
            _Theme.Get.SetElementColor(_Color.Get.Primary, _Address.Get.SlidersActiveBackground);
            _Theme.Get.SetElementColor(_Color.Get.Primary, _Address.Get.SlidersActiveBackgroundHoveredFocused);
            
            
            // I'm not sure, should I manage this two elements as Ternary color,
            // because it looks much better in Secondary colors. But for Secondary color,
            // I need to find all text's Black sequences [ 00 00 00 00 ].
            // In other way, those black texts will suck as look style:
            _Theme.Get.SetElementColor(_Color.Get.Ternary, _Address.Get.GlobalBorders);
            _Theme.Get.SetElementColor(_Color.Get.Ternary, _Address.Get.GlobalBorders2);

            

            _Theme.Get.SetElementColor(_Color.Get.Ternary, _Address.Get.TabsResizeGrabberVertical);
            _Theme.Get.SetElementColor(_Color.Get.Ternary, _Address.Get.TabsResizeGrabberHorizontal);
            _Theme.Get.SetElementColor(_Color.Get.Ternary, _Address.Get.ScaleAngleSliders);

            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.Separator);
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.TopBar);
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.ContextMenu);
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.ResizeWindowGrabber);
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.SlidersInActiveBackground);
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.SlidersColor);
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.BookmarkBackgroundAndOutlinesSomewhere);
            _Theme.Get.SetElementColor(_Color.Get.Secondary, _Address.Get.RadioButtonsBackground);


            // That 'blue text' sai2's glitch of some brushes names:
            _Theme.Get.SetElementColor(_Color.Get.Text, _Address.Get.BrushesSpecialText); 
            
            // 'Shit text' color replacer:
            _Theme.Get.SetElementColorComplicated(_Color.Get.Text, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor23);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Text, _Address.Get.GlobalSectionAppskin[0], _Address.Get.GlobalSectionAppskin[1], _Color.Get.DefaultColor23);

            // Should be useful on dark backgrounds. Right now I can't find couple of this texts, so almost unusable ;;
            _Theme.Get.SetElementColor(_Color.Get.Text, _Address.Get.ContextMenuText);
            _Theme.Get.SetElementColor(_Color.Get.Text, _Address.Get.TopBarText);
            // _Theme.Get.SetElementColor(_Color.Get.Text, _Address.Get.FileMenuScrollableText);
            // _Theme.Get.SetElementColor(_Color.Get.Text, _Address.Get.FileMenuTilesText);
            // _Theme.Get.SetElementColor(_Color.Get.Text, _Address.Get.BrushesText);
            // _Theme.Get.SetElementColor(_Color.Get.Text, _Address.Get.BrushesTabsText);
            // _Theme.Get.SetElementColor(_Color.Get.Text, _Address.Get.BrushesCirclesText);


            // This section is replacing huge parts of sequences,
            // which is going one by one in binaries,
            // so it was much easer to make this method to override the certain colors.
            // In this case, it means, this method is about artifacts after coloring, so
            // also, there is a method to fix consequences after coloring that way:
            _Theme.Get.SetElementColorComplicated(_Color.Get.Ternary, _Address.Get.BrushesFileMenuTilesScrollableListsBackground[0], _Address.Get.BrushesFileMenuTilesScrollableListsBackground[1], _Color.Get.DefaultColor22);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Ternary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor7);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Ternary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor11);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Ternary, _Address.Get.GlobalSectionAppskin[0], _Address.Get.GlobalSectionAppskin[1], _Color.Get.DefaultColor10);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Ternary, _Address.Get.GlobalSectionAppskin[0], _Address.Get.GlobalSectionAppskin[1], _Color.Get.DefaultColor13);
            
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor1);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor2);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor3);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor4);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor5);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor6);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor8);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor9);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor10);
            _Theme.Get.SetElementColorComplicated(_Color.Get.Secondary, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor12);

            
            
            // Semi colors fixes [ borders in sort of buttons ] [[ `bordering colors`, as you wish ]]:
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.TernaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor14, true);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.TernaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor15, true);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.TernaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor16, true);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.TernaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor17, true);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.TernaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor18, true);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.TernaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor19, true);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.TernaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor20, true);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.TernaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _Color.Get.DefaultColor21, true);
            //

            // Artifacts fixes [ which is inevitable after that colring method. ]:
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.SecondaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _SemiColor.Get.ArtifactsColor1);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.SecondaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _SemiColor.Get.ArtifactsColor2);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.SecondaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _SemiColor.Get.ArtifactsColor3);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.SecondaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _SemiColor.Get.ArtifactsColor4);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.SecondaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _SemiColor.Get.ArtifactsColor5);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.SecondaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _SemiColor.Get.ArtifactsColor6);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.SecondaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _SemiColor.Get.ArtifactsColor7);
            _Theme.Get.SetElementColorComplicated(_SemiColor.Get.SecondaryRGB, _Address.Get.GlobalSectionSrclibs[0], _Address.Get.GlobalSectionSrclibs[1], _SemiColor.Get.ArtifactsColor8);

            // Saving current theme changes:
            _Theme.Get.SaveTheme();

            // Removing unnecessary tmp file:
            if(File.Exists(_Name.Get.tmp)) { _File.Get.DeleteTmpFile(); }
            
        }
        void RemoveTheme() {
            if(!File.Exists(_Name.Get.old)) { _Console.Get.SendMessage(_ServiceMessage.Get.OldFileIsNotExist, ConsoleColor.DarkRed); return; }
            
            File.Delete(_Name.Get.original);
            _File.Get.ReplaceOriginalFile();
            _File.Get.DeleteOldFile();

            _Console.Get.SendMessage(_ServiceMessage.Get.DefaultThemeHasBeenRestored, ConsoleColor.DarkGreen);
        }
        static AppHelper() {
            Get = new AppHelper {
                ThemeColors = new Dictionary<string, string>()
            };
        }
    }
}