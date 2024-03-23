using YumToolkit.Global;

namespace YumToolkit.Core.Data {
    class _Address {
        public static _Address Get { get; private set; }
        public int InActiveText { get; private set; }
        public int InActiveCanvasBackground { get; private set; }
        public int BehindLayersUIBackground { get; private set; }
        public int ActiveCanvasBackground { get; private set; }
        public int ActiveCanvasBackground2 { get; private set; }
        public int ActiveCanvasBackground3 { get; private set; }
        public int ActiveCanvasBackground4 { get; private set; }
        public int GlobalBorders { get; private set; }
        public int GlobalBorders2 { get; private set; }
        public int BrushBorders { get; private set; }
        public int Separator { get; private set; }
        public int TopBar { get; private set; }
        public int TopBarText { get; private set; }
        public int TopBarTextHovered { get; private set; }
        public int TopBarTextFocused { get; private set; }
        public int ContextMenu { get; private set; }
        public int ContextMenuText { get; private set; }
        public int ContextMenuTextHovered { get; private set; }
        public int ContextMenuTextFocused { get; private set; }
        public int SlidersVertical { get; private set; }
        public int SlidersHorizontal { get; private set; }
        public int ResizeWindowGrabber { get; private set; }
        public int TabsResizeGrabberVertical { get; private set; }
        public int TabsResizeGrabberHorizontal { get; private set; }
        public int ScaleAngleSliders { get; private set; }
        public int SlidersInActiveBackground { get; private set; }
        public int SlidersActiveBackground { get; private set; }
        public int SlidersActiveBackgroundHoveredFocused { get; private set; }
        public int SlidersColor { get; private set; }
        public int BookmarkBackgroundAndOutlinesSomewhere { get; private set; }
        public int MinimizeApplicationIcon { get; private set; }
        public int MaximizeApplicationIcon { get; private set; }
        public int CloseApplicationIcon { get; private set; }
        public int RadioButtonsBackground { get; private set; }
        public int FileMenuScrollableText { get; private set; }
        public int FileMenuTilesText { get; private set; }
        public int BrushesText { get; private set; }
        public int BrushesSpecialText { get; private set; }
        public int BrushesTabsText { get; private set; }
        public int BrushesCirclesText { get; private set; }
        public int[] BrushesFileMenuTilesScrollableListsBackground { get; private set; } = [];
        public int[] LayerServiceButtons { get; private set; } = [];
        public int[] GlobalSectionAppskin { get; private set; } = [];
        public int[] GlobalSectionSrclibs { get; private set; } = [];
        
        static _Address() {
            Get = new _Address {
                InActiveText = "0x001BC95B".GetDecimalAddress(),
                InActiveCanvasBackground = "0x00534688".GetDecimalAddress(),
                BehindLayersUIBackground = "0x0053468C".GetDecimalAddress(),
                ActiveCanvasBackground = "0x0018838B".GetDecimalAddress(),
                ActiveCanvasBackground2 = "0x001880AC".GetDecimalAddress(),
                ActiveCanvasBackground3 = "0x0018A004".GetDecimalAddress(),
                ActiveCanvasBackground4 = "0x0001AE93".GetDecimalAddress(),
                GlobalBorders = "0x00534678".GetDecimalAddress(),
                GlobalBorders2 = "0x0053467C".GetDecimalAddress(),
                BrushBorders = "0x00534680".GetDecimalAddress(),
                Separator = "0x00534684".GetDecimalAddress(),
                TopBar = "0x005349D0".GetDecimalAddress(),
                TopBarText = "0x00534A98".GetDecimalAddress(),
                TopBarTextHovered = "0x00534AA0".GetDecimalAddress(),
                TopBarTextFocused = "0x00534AA8".GetDecimalAddress(),
                ContextMenu = "0x00534B60".GetDecimalAddress(),
                ContextMenuText = "0x00534C18".GetDecimalAddress(),
                ContextMenuTextHovered = "0x00534C20".GetDecimalAddress(),
                ContextMenuTextFocused = "0x00534C28".GetDecimalAddress(),
                SlidersVertical = "0x00535018".GetDecimalAddress(),
                SlidersHorizontal = "0x00534ED8".GetDecimalAddress(),
                ResizeWindowGrabber = "0x00535280".GetDecimalAddress(),
                TabsResizeGrabberVertical = "0x00535E28".GetDecimalAddress(),
                TabsResizeGrabberHorizontal = "0x00535CD8".GetDecimalAddress(),
                ScaleAngleSliders = "0x00536C00".GetDecimalAddress(),
                SlidersInActiveBackground = "0x0031B4B8".GetDecimalAddress(),
                SlidersActiveBackground = "0x0031B498".GetDecimalAddress(),
                SlidersActiveBackgroundHoveredFocused = "0x0031B49C".GetDecimalAddress(),
                SlidersColor = "0x0031B4C0".GetDecimalAddress(),
                BookmarkBackgroundAndOutlinesSomewhere = "0x003709B0".GetDecimalAddress(),
                MinimizeApplicationIcon = "0x00535568".GetDecimalAddress(),
                MaximizeApplicationIcon = "0x00535590".GetDecimalAddress(),
                CloseApplicationIcon = "0x005355E0".GetDecimalAddress(),
                RadioButtonsBackground = "0x0053644C".GetDecimalAddress(),
                FileMenuScrollableText = "0x00370A40".GetDecimalAddress(),
                FileMenuTilesText = "0x00370B30".GetDecimalAddress(),
                BrushesText = "0x00370760".GetDecimalAddress(),
                BrushesSpecialText = "0x00370768".GetDecimalAddress(),
                BrushesTabsText = "0x003706D0".GetDecimalAddress(),
                BrushesCirclesText = "0x00370900".GetDecimalAddress(),
                
                BrushesFileMenuTilesScrollableListsBackground = ["0x004D1038".GetDecimalAddress(), "0x004D1C33".GetDecimalAddress()],
                LayerServiceButtons = ["0x004DD400".GetDecimalAddress(), "0x004FC2AF".GetDecimalAddress()],
                GlobalSectionAppskin = ["0x00340000".GetDecimalAddress(), "0x004D0FFF".GetDecimalAddress()],
                GlobalSectionSrclibs = ["0x004D1000".GetDecimalAddress(), "0x0053E3FF".GetDecimalAddress()],
            };
        }
    }
}

// BrushesFileMenuTilesScrollableListsBackground = [5050424, 5053491] ^