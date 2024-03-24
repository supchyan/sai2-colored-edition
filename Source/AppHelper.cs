using System.Text.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YumToolkit.Global;
using YumToolkit.Core;

namespace YumToolkit {

    // Unneccessary stuff, to be stored here, but i did it to free space in App.cs
    class AppHelper :  _Globals {
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

            semiColor.SecondaryRGB = color.Secondary.NoAlpha();
            semiColor.TernaryRGB = color.Ternary.NoAlpha();

            // Creating tmp .exe to replace binary data inside:
            if(!File.Exists(name.tmp)) { _File.Get.CreateTmpFile(); }

            // Reading tmp .exe:
            theme.binary = theme.ReadTmpFile(name.tmp);

            // Too glitchy, so I decided to disable canvas bg recoloring rn:
            theme.SetElementColor(color.Secondary, address.ActiveCanvasBackground);
            theme.SetElementColor(color.Secondary, address.ActiveCanvasBackground2);
            theme.SetElementColor(color.Secondary, address.ActiveCanvasBackground3);
            theme.SetElementColor(color.Secondary, address.ActiveCanvasBackground4);
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionText[0], address.GlobalSectionText[1], color.DefaultColor17, true);
           

            theme.SetElementColor(color.Primary, address.InActiveCanvasBackground);
            theme.SetElementColor(color.Primary, address.BehindLayersUIBackground);
            theme.SetElementColor(color.Primary, address.BrushBorders);
            theme.SetElementColor(color.Primary, address.SlidersVertical);
            theme.SetElementColor(color.Primary, address.SlidersHorizontal);
            theme.SetElementColor(color.Primary, address.SlidersActiveBackground);
            theme.SetElementColor(color.Primary, address.SlidersActiveBackgroundHoveredFocused);
            
            
            // I'm not sure, should I manage this two elements as Ternary color,
            // because it looks much better in Secondary colors. But for Secondary color,
            // I need to find all text's Black sequences [ 00 00 00 00 ].
            // In other way, those black texts will suck as look style:
            theme.SetElementColor(color.Ternary, address.GlobalBorders);
            theme.SetElementColor(color.Ternary, address.GlobalBorders2);

            

            theme.SetElementColor(color.Ternary, address.TabsResizeGrabberVertical);
            theme.SetElementColor(color.Ternary, address.TabsResizeGrabberHorizontal);
            theme.SetElementColor(color.Ternary, address.ScaleAngleSliders);

            theme.SetElementColor(color.Secondary, address.Separator);
            theme.SetElementColor(color.Secondary, address.TopBar);
            theme.SetElementColor(color.Secondary, address.ContextMenu);
            theme.SetElementColor(color.Secondary, address.ResizeWindowGrabber);
            theme.SetElementColor(color.Secondary, address.SlidersInActiveBackground);
            theme.SetElementColor(color.Secondary, address.SlidersColor);
            theme.SetElementColor(color.Secondary, address.BookmarkBackgroundAndOutlinesSomewhere);
            theme.SetElementColor(color.Secondary, address.RadioButtonsBackground);


            // That 'blue text' sai2's glitch of some brushes names:
            theme.SetElementColor(color.Text, address.BrushesSpecialText); 
            
            // 'Shit text' color replacer:
            theme.SetElementColorComplicated(color.Text, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor23);
            theme.SetElementColorComplicated(color.Text, address.GlobalSectionAppskin[0], address.GlobalSectionAppskin[1], color.DefaultColor23);

            // Should be useful on dark backgrounds. Right now I can't find couple of this texts, so almost unusable ;;
            theme.SetElementColor(color.Text, address.ContextMenuText);
            theme.SetElementColor(color.Text, address.TopBarText);
            // theme.SetElementColor(color.Text, address.FileMenuScrollableText);
            // theme.SetElementColor(color.Text, address.FileMenuTilesText);
            // theme.SetElementColor(color.Text, address.BrushesText);
            // theme.SetElementColor(color.Text, address.BrushesTabsText);
            // theme.SetElementColor(color.Text, address.BrushesCirclesText);


            // This section is replacing huge parts of sequences,
            // which is going one by one in binaries,
            // so it was much easer to make this method to override the certain colors.
            // In this case, it means, this method is about artifacts after coloring, so
            // also, there is a method to fix consequences after coloring that way:
            theme.SetElementColorComplicated(color.Ternary, address.BrushesFileMenuTilesScrollableListsBackground[0], address.BrushesFileMenuTilesScrollableListsBackground[1], color.DefaultColor22);
            theme.SetElementColorComplicated(color.Ternary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor7);
            theme.SetElementColorComplicated(color.Ternary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor11);
            theme.SetElementColorComplicated(color.Ternary, address.GlobalSectionAppskin[0], address.GlobalSectionAppskin[1], color.DefaultColor10);
            theme.SetElementColorComplicated(color.Ternary, address.GlobalSectionAppskin[0], address.GlobalSectionAppskin[1], color.DefaultColor13);
            
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor1);
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor2);
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor3);
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor4);
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor5);
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor6);
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor8);
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor9);
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor10);
            theme.SetElementColorComplicated(color.Secondary, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor12);

            
            
            // Semi colors fixes [ borders in sort of buttons ] [[ `bordering colors`, as you wish ]]:
            theme.SetElementColorComplicated(semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor14, true);
            theme.SetElementColorComplicated(semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor15, true);
            theme.SetElementColorComplicated(semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor16, true);
            theme.SetElementColorComplicated(semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor17, true);
            theme.SetElementColorComplicated(semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor18, true);
            theme.SetElementColorComplicated(semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor19, true);
            theme.SetElementColorComplicated(semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor20, true);
            theme.SetElementColorComplicated(semiColor.TernaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], color.DefaultColor21, true);
            //

            // Artifacts fixes [ which is inevitable after that colring method. ]:
            theme.SetElementColorComplicated(semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], semiColor.ArtifactsColor1);
            theme.SetElementColorComplicated(semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], semiColor.ArtifactsColor2);
            theme.SetElementColorComplicated(semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], semiColor.ArtifactsColor3);
            theme.SetElementColorComplicated(semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], semiColor.ArtifactsColor4);
            theme.SetElementColorComplicated(semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], semiColor.ArtifactsColor5);
            theme.SetElementColorComplicated(semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], semiColor.ArtifactsColor6);
            theme.SetElementColorComplicated(semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], semiColor.ArtifactsColor7);
            theme.SetElementColorComplicated(semiColor.SecondaryRGB, address.GlobalSectionSrclibs[0], address.GlobalSectionSrclibs[1], semiColor.ArtifactsColor8);

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