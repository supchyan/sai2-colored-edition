using System.Text.Json;
using System.Diagnostics;
using YumToolkit.Core;
using YumToolkit.Core.Data;
using System.Runtime.InteropServices;

namespace YumToolkit {

    // Unneccessary stuff, to be stored here, but i did it to free space in App.cs
    class AppHelper {
        static Dictionary<string, string>? ThemeColors = new Dictionary<string, string>();
        public static void _Action() {
            // Since projcet can absorb any amount of themes,
            // at this moment I decided to make unique behaviours
            // to anything in Console Menu, except of theme selection.
            // So users can select certain theme or anything else.
            // And because themes are in the top of Menu list,
            // I subtract user's choice from MaxListValue
            // to get unique Menu choices first and themes at the end.
            // So yeah, ReColor() is universal method to work with any selected theme.
            int index = _Console.MaxListValue - _Console.Choice;
            if(index > 3) index = 3;

            switch(index) {
                
                case 0: 
                    Environment.Exit(0);
                break;

                case 1:
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) { Process.Start(new ProcessStartInfo("cmd", $"/c start {_Path.GitHubLink}")); }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) { Process.Start("xdg-open", _Path.GitHubLink); }
                break;

                case 2: 
                    RemoveTheme();
                break;

                case 3: 
                    ReColor();
                break;

            }
            
        }

        static void ReColor() {

            if(!File.Exists(_Name.original)) { _Console.SendMessage(_ServiceMessage.OriginalFileIsNotExist, ConsoleColor.DarkRed); return; }

            // Creating backup file to restore data or replace original file
            // with backup one to recolor it:
            if(!File.Exists(_Name.old)) { _File.CreateOldFile(); }
            else {
                File.Delete(_Name.original);
                // This won't delete sai2.old.exe! Just cloning it to original one:
                _File.ReplaceOriginalFile();
            }
            

            // Reading theme file:
            ThemeColors = JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText($"{_Console.ThemesList[_Console.Choice]}"));
            
            // Returning if nothing to replace to:
            if(ThemeColors is null) return;
            
            // Applying colors to... colors:
            _Color.Primary = ThemeColors["Primary"].toByteColor();
            _Color.Secondary = ThemeColors["Secondary"].toByteColor();
            _Color.Ternary = ThemeColors["Ternary"].toByteColor();
            _Color.Text = ThemeColors["Text"].toByteColor();

            _Color._SemiColor.SecondaryRGB = _Color.Secondary.NoAlpha();
            _Color._SemiColor.TernaryRGB = _Color.Ternary.NoAlpha();

            // Creating tmp .exe to replace binary data inside:
            if(!File.Exists(_Name.tmp)) { _File.CreateTmpFile(); }

            // Too glitchy, so I decided to disable canvas bg recoloring rn:
            // _Theme.SetElementColor(_Color.Secondary, _Address.ActiveCanvasBackground);
            // _Theme.SetElementColor(_Color.Secondary, _Address.ActiveCanvasBackground2);
            // _Theme.SetElementColor(_Color.Secondary, _Address.ActiveCanvasBackground3);
            // _Theme.SetElementColor(_Color.Secondary, _Address.ActiveCanvasBackground4);

            _Theme.SetElementColor(_Color.Primary, _Address.InActiveCanvasBackground);
            _Theme.SetElementColor(_Color.Primary, _Address.BehindLayersUIBackground);
            _Theme.SetElementColor(_Color.Primary, _Address.BrushBorders);
            _Theme.SetElementColor(_Color.Primary, _Address.SlidersVertical);
            _Theme.SetElementColor(_Color.Primary, _Address.SlidersHorizontal);
            _Theme.SetElementColor(_Color.Primary, _Address.SlidersActiveBackground);
            _Theme.SetElementColor(_Color.Primary, _Address.SlidersActiveBackgroundHoveredFocused);
            
            
            // I'm not sure, should I manage this two elements as Ternary color,
            // because it looks much better in Secondary colors. But for Secondary color,
            // I need to find all text's Black sequences [ 00 00 00 00 ].
            // In other way, those black texts will suck as look style:
            _Theme.SetElementColor(_Color.Ternary, _Address.GlobalBorders);
            _Theme.SetElementColor(_Color.Ternary, _Address.GlobalBorders2);

            

            _Theme.SetElementColor(_Color.Ternary, _Address.TabsResizeGrabberVertical);
            _Theme.SetElementColor(_Color.Ternary, _Address.TabsResizeGrabberHorizontal);
            _Theme.SetElementColor(_Color.Ternary, _Address.ScaleAngleSliders);

            _Theme.SetElementColor(_Color.Secondary, _Address.Separator);
            _Theme.SetElementColor(_Color.Secondary, _Address.TopBar);
            _Theme.SetElementColor(_Color.Secondary, _Address.ContextMenu);
            _Theme.SetElementColor(_Color.Secondary, _Address.ResizeWindowGrabber);
            _Theme.SetElementColor(_Color.Secondary, _Address.SlidersInActiveBackground);
            _Theme.SetElementColor(_Color.Secondary, _Address.SlidersColor);
            _Theme.SetElementColor(_Color.Secondary, _Address.BookmarkBackgroundAndOutlinesSomewhere);
            _Theme.SetElementColor(_Color.Secondary, _Address.RadioButtonsBackground);


            // That 'blue text' sai2's glitch of some brushes names:
            _Theme.SetElementColor(_Color.Text, _Address.BrushesSpecialText); 
            
            // 'Shit text' color replacer:
            _Theme.SetElementColorComplicated(_Color.Text, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor23);
            _Theme.SetElementColorComplicated(_Color.Text, _Address.GlobalSectionAppskin[0], _Address.GlobalSectionAppskin[1], _Color.DefaultColor23);

            // Should be useful on dark backgrounds. Right now I can't find couple of this texts, so almost unusable ;;
            _Theme.SetElementColor(_Color.Text, _Address.ContextMenuText);
            _Theme.SetElementColor(_Color.Text, _Address.TopBarText);
            // _Theme.SetElementColor(_Color.Text, _Address.FileMenuScrollableText);
            // _Theme.SetElementColor(_Color.Text, _Address.FileMenuTilesText);
            // _Theme.SetElementColor(_Color.Text, _Address.BrushesText);
            // _Theme.SetElementColor(_Color.Text, _Address.BrushesTabsText);
            // _Theme.SetElementColor(_Color.Text, _Address.BrushesCirclesText);


            // This section is replacing huge parts of sequences,
            // which is going one by one in binaries,
            // so it was much easer to make this method to override the certain colors.
            // In this case, it means, this method is about artifacts after coloring, so
            // also, there is a method to fix consequences after coloring that way:
            _Theme.SetElementColorComplicated(_Color.Ternary, _Address.BrushesFileMenuTilesScrollableListsBackground[0], _Address.BrushesFileMenuTilesScrollableListsBackground[1], _Color.DefaultColor22);
            _Theme.SetElementColorComplicated(_Color.Ternary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor7);
            _Theme.SetElementColorComplicated(_Color.Ternary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor11);
            _Theme.SetElementColorComplicated(_Color.Ternary, _Address.GlobalSectionAppskin[0], _Address.GlobalSectionAppskin[1], _Color.DefaultColor10);
            _Theme.SetElementColorComplicated(_Color.Ternary, _Address.GlobalSectionAppskin[0], _Address.GlobalSectionAppskin[1], _Color.DefaultColor13);
            
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor1);
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor2);
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor3);
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor4);
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor5);
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor6);
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor8);
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor9);
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor10);
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor12);

            
            
            // Semi colors fixes [ borders in sort of buttons ] [[ `bordering colors`, as you wish ]]:
            _Theme.SetElementColorComplicated(_Color._SemiColor.TernaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor14, true);
            _Theme.SetElementColorComplicated(_Color._SemiColor.TernaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor15, true);
            _Theme.SetElementColorComplicated(_Color._SemiColor.TernaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor16, true);
            _Theme.SetElementColorComplicated(_Color._SemiColor.TernaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor17, true);
            _Theme.SetElementColorComplicated(_Color._SemiColor.TernaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor18, true);
            _Theme.SetElementColorComplicated(_Color._SemiColor.TernaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor19, true);
            _Theme.SetElementColorComplicated(_Color._SemiColor.TernaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor20, true);
            _Theme.SetElementColorComplicated(_Color._SemiColor.TernaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor21, true);
            //

            // Artifacts fixes [ which is inevitable after that colring method. ]:
            _Theme.SetElementColorComplicated(_Color._SemiColor.SecondaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color._SemiColor.ArtifactsColor1);
            _Theme.SetElementColorComplicated(_Color._SemiColor.SecondaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color._SemiColor.ArtifactsColor2);
            _Theme.SetElementColorComplicated(_Color._SemiColor.SecondaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color._SemiColor.ArtifactsColor3);
            _Theme.SetElementColorComplicated(_Color._SemiColor.SecondaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color._SemiColor.ArtifactsColor4);
            _Theme.SetElementColorComplicated(_Color._SemiColor.SecondaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color._SemiColor.ArtifactsColor5);
            _Theme.SetElementColorComplicated(_Color._SemiColor.SecondaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color._SemiColor.ArtifactsColor6);
            _Theme.SetElementColorComplicated(_Color._SemiColor.SecondaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color._SemiColor.ArtifactsColor7);
            _Theme.SetElementColorComplicated(_Color._SemiColor.SecondaryRGB, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color._SemiColor.ArtifactsColor8);

            // Saving current theme changes:
            _Theme.SaveTheme();

            // Removing unnecessary tmp file:
            if(File.Exists(_Name.tmp)) { _File.DeleteTmpFile(); }

            Console.ReadKey();
            
        }
        static void RemoveTheme() {
            if(!File.Exists(_Name.old)) { _Console.SendMessage(_ServiceMessage.OldFileIsNotExist, ConsoleColor.DarkRed); return; }
            
            File.Delete(_Name.original);
            _File.ReplaceOriginalFile();
            _File.DeleteOldFile();

            _Console.SendMessage(_ServiceMessage.DefaultThemeHasBeenRestored, ConsoleColor.DarkGreen);
        } 
    }
}