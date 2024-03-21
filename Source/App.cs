using System.Drawing;
using YumToolkit.Core;
using YumToolkit.Core.Data;

namespace YumToolkit {
    class App {
        static void Main(string[] args) {
            if(!OperatingSystem.IsWindows()) {
                Console.WriteLine($"This program cannot be run on {Environment.OSVersion}.");
                return;
            }

            if(!File.Exists(_Name.original)) {
                _Console.WriteLine(_ServiceMessage.OriginalFileIsNotExists, ConsoleColor.DarkRed);
                Console.ReadKey();
                return;
            }

            // Creating backup file to restore data if needed;
            if(!File.Exists(_Name.old)) {
                _File.CreateOldFile();
            }

            // Creating tmp .exe to replace binary data inside;
            if(!File.Exists(_Name.tmp)) {
                _File.CreateTmpFile();
            }

            // Replace binary colors
            // _Theme.SetElementColor(_Color.Secondary, _Address.ActiveCanvasBackground);
            // _Theme.SetElementColor(_Color.Secondary, _Address.ActiveCanvasBackground2);
            // _Theme.SetElementColor(_Color.Secondary, _Address.ActiveCanvasBackground3);
            // _Theme.SetElementColor(_Color.Secondary, _Address.ActiveCanvasBackground4);

            _Theme.SetElementColor(_Color.Primary, _Address.InActiveCanvasBackground);
            _Theme.SetElementColor(_Color.Primary, _Address.BehindLayersUIBackground);
            _Theme.SetElementColor(_Color.Secondary, _Address.GlobalBorders);
            _Theme.SetElementColor(_Color.Secondary, _Address.GlobalBorders2);
            _Theme.SetElementColor(_Color.Primary, _Address.BrushBorders);
            _Theme.SetElementColor(_Color.Secondary, _Address.Separator);
            _Theme.SetElementColor(_Color.Secondary, _Address.TopBar);
            _Theme.SetElementColor(_Color.LightGrey, _Address.TopBarText);
            _Theme.SetElementColor(_Color.Secondary, _Address.ContextMenu);
            _Theme.SetElementColor(_Color.LightGrey, _Address.ContextMenuText);
            _Theme.SetElementColor(_Color.Primary, _Address.SlidersVertical);
            _Theme.SetElementColor(_Color.Primary, _Address.SlidersHorizontal);
            _Theme.SetElementColor(_Color.Secondary, _Address.ResizeWindowGrabber);
            _Theme.SetElementColor(_Color.Secondary, _Address.TabsResizeGrabberVertical);
            _Theme.SetElementColor(_Color.Secondary, _Address.TabsResizeGrabberHorizontal);
            _Theme.SetElementColor(_Color.Secondary, _Address.ScaleAngleSliders);
            _Theme.SetElementColor(_Color.Secondary, _Address.SlidersInActiveBackground);
            _Theme.SetElementColor(_Color.Primary, _Address.SlidersActiveBackground);
            _Theme.SetElementColor(_Color.Primary, _Address.SlidersActiveBackgroundHoveredFocused);
            _Theme.SetElementColor(_Color.Secondary, _Address.SlidersColor);
            _Theme.SetElementColor(_Color.Secondary, _Address.BookmarkBackgroundAndOutlinesSomewhere);
            _Theme.SetElementColor(_Color.Secondary, _Address.RadioButtonsBackground);
            _Theme.SetElementColor(_Color.LightGrey, _Address.FileMenuScrollableText);
            _Theme.SetElementColor(_Color.LightGrey, _Address.FileMenuTilesText);
            _Theme.SetElementColor(_Color.LightGrey, _Address.BrushesText);
            _Theme.SetElementColor(_Color.LightGrey, _Address.BrushesSpecialText);
            _Theme.SetElementColor(_Color.LightGrey, _Address.BrushesTabsText);
            _Theme.SetElementColor(_Color.LightGrey, _Address.BrushesCirclesText);
            
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.BrushesFileMenuTilesScrollableListsBackground[0], _Address.BrushesFileMenuTilesScrollableListsBackground[1], _Color.White);
            
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor1);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor2);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor3);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor4);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor5);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor6);
            _Theme.SetElementColorComplicated(_Color.Secondary, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor7);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor8);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor9);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor10);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor11);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor12);

            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionAppskin[0], _Address.GlobalSectionAppskin[1], _Color.DefaultColor10);
            _Theme.SetElementColorComplicated(_Color.Elements, _Address.GlobalSectionAppskin[0], _Address.GlobalSectionAppskin[1], _Color.DefaultColor13);
            
            // Semi colors fixes
            _Theme.SetElementColorComplicated([_Color.Secondary[0],_Color.Secondary[1],_Color.Secondary[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor14, true);
            _Theme.SetElementColorComplicated([_Color.Secondary[0],_Color.Secondary[1],_Color.Secondary[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor15, true);
            _Theme.SetElementColorComplicated([_Color.Secondary[0],_Color.Secondary[1],_Color.Secondary[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor16, true);
            _Theme.SetElementColorComplicated([_Color.Secondary[0],_Color.Secondary[1],_Color.Secondary[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor17, true);
            _Theme.SetElementColorComplicated([_Color.Secondary[0],_Color.Secondary[1],_Color.Secondary[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor18, true);
            _Theme.SetElementColorComplicated([_Color.Secondary[0],_Color.Secondary[1],_Color.Secondary[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor19, true);
            _Theme.SetElementColorComplicated([_Color.Secondary[0],_Color.Secondary[1],_Color.Secondary[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor20, true);
            _Theme.SetElementColorComplicated([_Color.Elements[0],_Color.Elements[1],_Color.Elements[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.DefaultColor21, false);
            //

            // Artefacts fixes
            _Theme.SetElementColorComplicated([_Color.Elements[0],_Color.Elements[1],_Color.Elements[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.ArtefactsColor1);
            _Theme.SetElementColorComplicated([_Color.Elements[0],_Color.Elements[1],_Color.Elements[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.ArtefactsColor2);
            _Theme.SetElementColorComplicated([_Color.Elements[0],_Color.Elements[1],_Color.Elements[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.ArtefactsColor3);
            _Theme.SetElementColorComplicated([_Color.Elements[0],_Color.Elements[1],_Color.Elements[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.ArtefactsColor4);
            _Theme.SetElementColorComplicated([_Color.Elements[0],_Color.Elements[1],_Color.Elements[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.ArtefactsColor5);
            _Theme.SetElementColorComplicated([_Color.Elements[0],_Color.Elements[1],_Color.Elements[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.ArtefactsColor6);
            _Theme.SetElementColorComplicated([_Color.Elements[0],_Color.Elements[1],_Color.Elements[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.ArtefactsColor7);
            _Theme.SetElementColorComplicated([_Color.Elements[0],_Color.Elements[1],_Color.Elements[2]], _Address.GlobalSectionSrclibs[0], _Address.GlobalSectionSrclibs[1], _Color.ArtefactsColor8);
            
            _Theme.SaveTheme();
            

            // Removing unnecessary file.
            if(File.Exists(_Name.tmp)) {
                _File.DeleteTmpFile();
            }

            Console.ReadKey();
            return;

            // console preparations
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Yum2Tools";
            Console.CursorVisible = false;

            // ui
            _Console.Drawing.CONSOLE_DRAW_MAIN();

            // while(true) {
            //     var current_key = Console.ReadKey().Key;
            //     if(current_key is ConsoleKey.DownArrow) _Console.Drawing.CONSOLE_SELECT_EXIT();
            //     if(current_key is ConsoleKey.UpArrow) _Console.Drawing.CONSOLE_SELECT_START();
            //     if(current_key is ConsoleKey.Enter) {
            //         if(!_Console.Drawing.exit_proc) {
            //             break;

            //         } else Environment.Exit(0);
            //     }
            // }

            Console.ReadKey();
        }
    }
}