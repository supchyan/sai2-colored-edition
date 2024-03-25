using YumToolkit.Core.Interfaces;
using YumToolkit.Global;

namespace YumToolkit.Core.Data {
    /// <summary>
    /// Read colors and addresses.md before modifying this!
    /// </summary>
    class _Address : IAddress {
        public int InActiveText { get; }
        public int InActiveCanvasBackground { get; }
        public int BehindLayersUIBackground { get; }
        public int ActiveCanvasBackground { get; }
        public int ActiveCanvasBackground2 { get; }
        public int ActiveCanvasBackground3 { get; }
        public int ActiveCanvasBackground4 { get; }
        public int GlobalBorders { get; }
        public int GlobalBorders2 { get; }
        public int BrushBorders { get; }
        public int Separator { get; }
        public int TopBar { get; }
        public int TopBarText { get; }
        public int TopBarTextHovered { get; }
        public int TopBarTextFocused { get; }
        public int ContextMenu { get; }
        public int ContextMenuText { get; }
        public int ContextMenuTextHovered { get; }
        public int ContextMenuTextFocused { get; }
        public int SlidersVertical { get; }
        public int SlidersHorizontal { get; }
        public int ResizeWindowGrabber { get; }
        public int TabsResizeGrabberVertical { get; }
        public int TabsResizeGrabberHorizontal { get; }
        public int ScaleAngleSliders { get; }
        public int SlidersInActiveBackground { get; }
        public int SlidersActiveBackground { get; }
        public int SlidersActiveBackgroundHoveredFocused { get; }
        public int SlidersColor { get; }
        public int BookmarkBackgroundAndOutlinesSomewhere { get; }
        public int MinimizeApplicationIcon { get; }
        public int MaximizeApplicationIcon { get; }
        public int CloseApplicationIcon { get; }
        public int RadioButtonsBackground { get; }
        public int FileMenuScrollableText { get; }
        public int FileMenuTilesText { get; }
        public int BrushesText { get; }
        public int BrushesSpecialText { get; }
        public int BrushesTabsText { get; }
        public int BrushesCirclesText { get; }
        public int[] BrushesFileMenuTilesScrollableListsBackground { get; }
        public int[] LayerServiceButtons { get; }
        public int[] GlobalSectionText { get; }
        public int[] GlobalSectionAppskin { get; }
        public int[] GlobalSectionSrclibs { get; }
        public _Address() {
            InActiveText = "0x001BC95B".GetDecimalAddress();
            InActiveCanvasBackground = "0x00534688".GetDecimalAddress();
            BehindLayersUIBackground = "0x0053468C".GetDecimalAddress();
            ActiveCanvasBackground = "0x0018838B".GetDecimalAddress();
            ActiveCanvasBackground2 = "0x001880AC".GetDecimalAddress();
            ActiveCanvasBackground3 = "0x0018A004".GetDecimalAddress();
            ActiveCanvasBackground4 = "0x0001AE93".GetDecimalAddress();
            GlobalBorders = "0x00534678".GetDecimalAddress();
            GlobalBorders2 = "0x0053467C".GetDecimalAddress();
            BrushBorders = "0x00534680".GetDecimalAddress();
            Separator = "0x00534684".GetDecimalAddress();
            TopBar = "0x005349D0".GetDecimalAddress();
            TopBarText = "0x00534A98".GetDecimalAddress();
            TopBarTextHovered = "0x00534AA0".GetDecimalAddress();
            TopBarTextFocused = "0x00534AA8".GetDecimalAddress();
            ContextMenu = "0x00534B60".GetDecimalAddress();
            ContextMenuText = "0x00534C18".GetDecimalAddress();
            ContextMenuTextHovered = "0x00534C20".GetDecimalAddress();
            ContextMenuTextFocused = "0x00534C28".GetDecimalAddress();
            SlidersVertical = "0x00535018".GetDecimalAddress();
            SlidersHorizontal = "0x00534ED8".GetDecimalAddress();
            ResizeWindowGrabber = "0x00535280".GetDecimalAddress();
            TabsResizeGrabberVertical = "0x00535E28".GetDecimalAddress();
            TabsResizeGrabberHorizontal = "0x00535CD8".GetDecimalAddress();
            ScaleAngleSliders = "0x00536C00".GetDecimalAddress();
            SlidersInActiveBackground = "0x0031B4B8".GetDecimalAddress();
            SlidersActiveBackground = "0x0031B498".GetDecimalAddress();
            SlidersActiveBackgroundHoveredFocused = "0x0031B49C".GetDecimalAddress();
            SlidersColor = "0x0031B4C0".GetDecimalAddress();
            BookmarkBackgroundAndOutlinesSomewhere = "0x003709B0".GetDecimalAddress();
            MinimizeApplicationIcon = "0x00535568".GetDecimalAddress();
            MaximizeApplicationIcon = "0x00535590".GetDecimalAddress();
            CloseApplicationIcon = "0x005355E0".GetDecimalAddress();
            RadioButtonsBackground = "0x0053644C".GetDecimalAddress();
            FileMenuScrollableText = "0x00370A40".GetDecimalAddress();
            FileMenuTilesText = "0x00370B30".GetDecimalAddress();
            BrushesText = "0x00370760".GetDecimalAddress();
            BrushesSpecialText = "0x00370768".GetDecimalAddress();
            BrushesTabsText = "0x003706D0".GetDecimalAddress();
            BrushesCirclesText = "0x00370900".GetDecimalAddress();
            
            BrushesFileMenuTilesScrollableListsBackground = ["0x004D1038".GetDecimalAddress(), "0x004D1C33".GetDecimalAddress()];
            LayerServiceButtons = ["0x004DD400".GetDecimalAddress(), "0x004FC2AF".GetDecimalAddress()];
            
            GlobalSectionText = ["0x00000400".GetDecimalAddress(), "0x00257F4F".GetDecimalAddress()];
            GlobalSectionAppskin = ["0x00340000".GetDecimalAddress(), "0x004D0FFF".GetDecimalAddress()];
            GlobalSectionSrclibs = ["0x004D1000".GetDecimalAddress(), "0x0053E3FF".GetDecimalAddress()];
        }
    }
}