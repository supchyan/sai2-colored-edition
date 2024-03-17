namespace YumToolkit.Core.Data {
    public class _Address {
        public static _Address GetAddress = new _Address();
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
        public int GlobalResizeGrabber { get; }
        public int TabsResizeGrabberVertical { get; }
        public int TabsResizeGrabberHorizontal { get; }
        public int ScaleAngleSliders { get; }
        
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
            GlobalResizeGrabber = "0x00535280".GetDecimalAddress();
            TabsResizeGrabberVertical = "0x00535E28".GetDecimalAddress();
            TabsResizeGrabberHorizontal = "0x00535CD8".GetDecimalAddress();
            ScaleAngleSliders = "0x00536C00".GetDecimalAddress();
        }
    }
}