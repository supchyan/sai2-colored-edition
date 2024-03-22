namespace YumToolkit.Core.Data {
    public static class _ServiceMessage {
        public static string TmpFileIsNotExists { get; }
        public static string OriginalFileIsNotExists { get; }
        public static string DefaultThemeHasBeenRestored { get; }
        public static string ThemeHasBeenApplied { get; }
        public static string ExitMessage { get; }
        static _ServiceMessage() {
            ExitMessage = "Press any key to continue...";
            TmpFileIsNotExists = $"[ ERROR ] {_Name.tmp} is not found. {ExitMessage}";
            OriginalFileIsNotExists = $"[ ERROR ] {_Name.original} is not found. {ExitMessage}";
            DefaultThemeHasBeenRestored = $"[ OK ] Default theme has been restored. {ExitMessage}";
            ThemeHasBeenApplied = $"[ OK ] Theme has been applied. {ExitMessage}";
        }
    }
}