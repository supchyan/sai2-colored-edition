namespace YumToolkit.Core.Interfaces {
    interface IAddress {
        int InActiveText { get; }
        int InActiveCanvasBackground { get; }
        int BehindLayersUIBackground { get; }
        int ActiveCanvasBackground { get; }
        int ActiveCanvasBackground2 { get; }
        int ActiveCanvasBackground3 { get; }
        int ActiveCanvasBackground4 { get; }
        int GlobalBorders { get; }
        int GlobalBorders2 { get; }
        int BrushBorders { get; }
        int Separator { get; }
        int TopBar { get; }
        int TopBarText { get; }
        int TopBarTextHovered { get; }
        int TopBarTextFocused { get; }
        int ContextMenu { get; }
        int ContextMenuText { get; }
        int ContextMenuTextHovered { get; }
        int ContextMenuTextFocused { get; }
        int SlidersVertical { get; }
        int SlidersHorizontal { get; }
        int ResizeWindowGrabber { get; }
        int TabsResizeGrabberVertical { get; }
        int TabsResizeGrabberHorizontal { get; }
        int ScaleAngleSliders { get; }
        int SlidersInActiveBackground { get; }
        int SlidersActiveBackground { get; }
        int SlidersActiveBackgroundHoveredFocused { get; }
        int SlidersColor { get; }
        int BookmarkBackgroundAndOutlinesSomewhere { get; }
        int MinimizeApplicationIcon { get; }
        int MaximizeApplicationIcon { get; }
        int CloseApplicationIcon { get; }
        int RadioButtonsBackground { get; }
        int FileMenuScrollableText { get; }
        int FileMenuTilesText { get; }
        int BrushesText { get; }
        int BrushesSpecialText { get; }
        int BrushesTabsText { get; }
        int BrushesCirclesText { get; }
        int[] BrushesFileMenuTilesScrollableListsBackground { get; }
        int[] LayerServiceButtons { get; }
        int[] GlobalSectionText { get; }
        int[] GlobalSectionAppskin { get; }
        int[] GlobalSectionSrclibs { get; }
        int[] HoveredEmptyBrushesBackground { get; }
        int[] HoveredLayersBackground { get; }
    }
}