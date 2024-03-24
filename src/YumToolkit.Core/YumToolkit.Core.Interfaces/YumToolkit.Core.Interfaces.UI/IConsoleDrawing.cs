namespace YumToolkit.Core.Interfaces.UI {
    interface IConsoleDrawing {
        int Choice { get; set; }
        bool isSelected { get; set; }
        int MaxListValue { get; }
        List<string> ThemesList { get; }

        Thread ASCIImation { get; }
        // Protects interface from `break lines` when drawing animation
        bool InterfaceHasBeenDrawn { get; set; }
    }
}