using YumToolkit.Core.Interfaces;
using YumToolkit.Global;

namespace YumToolkit.Core.Data {
    class _Color : IColor {
        // Customizable colors
        public byte[] Primary { get; set; }
        public byte[] Secondary { get; set; }
        public byte[] Ternary { get; set; }
        public byte[] Text { get; set; }
        public byte[] SelectablePrimary { get; set; }
        public byte[] SelectableSecondary { get; set; }

         public _Color() {
            Primary = [];
            Secondary = [];
            Ternary = [];
            Text = [];
            SelectablePrimary = [];
            SelectableSecondary = [];
        }
    }
}