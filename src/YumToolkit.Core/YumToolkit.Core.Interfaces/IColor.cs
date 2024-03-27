namespace YumToolkit.Core.Interfaces {
    interface IColor {
        // Customizable colors
        byte[] Primary { get; set; }
        byte[] Secondary { get; set; }
        byte[] Ternary { get; set; }
        byte[] Text { get; set; }
        byte[] SelectablePrimary { get; set; }
        byte[] SelectableSecondary { get; set; }
    }
}