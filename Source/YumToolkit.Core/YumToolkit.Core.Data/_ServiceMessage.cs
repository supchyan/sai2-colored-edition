namespace YumToolkit.Core.Data {
    public static class _ServiceMessage {
        public static string ExitMessage { get; }
        public static string ThemeFolderIsNotExist { get; }
        public static string OldFileIsNotExist { get; }
        public static string TmpFileIsNotExist { get; }
        public static string OriginalFileIsNotExist { get; }
        public static string DefaultThemeHasBeenRestored { get; }
        public static string ThemeHasBeenApplied { get; }
        public static string OriginalFileIsBusy { get; }
        
        static _ServiceMessage() {
            ExitMessage = "Press any key to continue...";
            ThemeFolderIsNotExist = $"[ ERROR ] '{_Path.ThemesFolder}' folder could not be found. {ExitMessage}";
            OldFileIsNotExist = $"[ ERROR ] Backup file could not be found. {ExitMessage}";
            TmpFileIsNotExist = $"[ ERROR ] {_Name.tmp} could not be found. {ExitMessage}";
            OriginalFileIsNotExist = $"[ ERROR ] {_Name.original} could not be found. {ExitMessage}";
            DefaultThemeHasBeenRestored = $"[ OK ] Default theme has been restored. {ExitMessage}";
            ThemeHasBeenApplied = $"[ OK ] Theme has been applied. {ExitMessage}";
            OriginalFileIsBusy = $"[ ERROR ] {_Name.original} is busy and can't be reached. Try again later. {ExitMessage}";
        }
    }
}