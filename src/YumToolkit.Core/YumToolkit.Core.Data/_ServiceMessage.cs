using YumToolkit.Core.Interfaces;
using YumToolkit.Global;

namespace YumToolkit.Core.Data {
    class _ServiceMessage : _Globals, IServiceMessage {
        public string ExitMessage { get; }
        public string ThemeFolderIsNotExist { get; }
        public string OldFileIsNotExist { get; }
        public string TmpFileIsNotExist { get; }
        public string OriginalFileIsNotExist { get; }
        public string DefaultThemeHasBeenRestored { get; }
        public string ThemeHasBeenApplied { get; }
        public string OriginalFileIsBusy { get; }
        public _ServiceMessage() {
            ExitMessage = "Press any key to continue...";
            ThemeFolderIsNotExist = $"[ ERROR ] '{path.ThemesFolder}' folder could not be found. {ExitMessage}";
            OldFileIsNotExist = $"[ ERROR ] Backup file could not be found. {ExitMessage}";
            TmpFileIsNotExist = $"[ ERROR ] {name.tmp} could not be found. {ExitMessage}";
            OriginalFileIsNotExist = $"[ ERROR ] {name.original} could not be found. {ExitMessage}";
            DefaultThemeHasBeenRestored = $"[ OK ] Default theme has been restored. {ExitMessage}";
            ThemeHasBeenApplied = $"[ OK ] Theme has been applied. {ExitMessage}";
            OriginalFileIsBusy = $"[ ERROR ] {name.original} is busy and can't be reached. Try again later. {ExitMessage}";
        }
    }
}