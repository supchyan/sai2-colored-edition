namespace YumToolkit.Core.Interfaces {
    interface IServiceMessage {
        string ExitMessage { get; }
        string ThemeFolderIsNotExist { get; }
        string OldFileIsNotExist { get; }
        string TmpFileIsNotExist { get; }
        string OriginalFileIsNotExist { get; }
        string DefaultThemeHasBeenRestored { get; }
        string ThemeHasBeenApplied { get; }
        string OriginalFileIsBusy { get; }
    }
}