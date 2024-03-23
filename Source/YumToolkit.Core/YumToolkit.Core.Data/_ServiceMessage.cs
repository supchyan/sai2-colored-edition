namespace YumToolkit.Core.Data {
    public class _ServiceMessage {
        public static _ServiceMessage Get;
        public string ExitMessage { get; private set; } = string.Empty;
        public string ThemeFolderIsNotExist { get; private set; } = string.Empty;
        public string OldFileIsNotExist { get; private set; } = string.Empty;
        public string TmpFileIsNotExist { get; private set; } = string.Empty;
        public string OriginalFileIsNotExist { get; private set; } = string.Empty;
        public string DefaultThemeHasBeenRestored { get; private set; } = string.Empty;
        public string ThemeHasBeenApplied { get; private set; } = string.Empty;
        public string OriginalFileIsBusy { get; private set; } = string.Empty;
        
        static _ServiceMessage() {
            Get = new _ServiceMessage();
            Get.ExitMessage = "Press any key to continue...";
            Get.ThemeFolderIsNotExist = $"[ ERROR ] '{_Path.Get.ThemesFolder}' folder could not be found. {Get.ExitMessage}";
            Get.OldFileIsNotExist = $"[ ERROR ] Backup file could not be found. {Get.ExitMessage}";
            Get.TmpFileIsNotExist = $"[ ERROR ] {_Name.Get.tmp} could not be found. {Get.ExitMessage}";
            Get.OriginalFileIsNotExist = $"[ ERROR ] {_Name.Get.original} could not be found. {Get.ExitMessage}";
            Get.DefaultThemeHasBeenRestored = $"[ OK ] Default theme has been restored. {Get.ExitMessage}";
            Get.ThemeHasBeenApplied = $"[ OK ] Theme has been applied. {Get.ExitMessage}";
            Get.OriginalFileIsBusy = $"[ ERROR ] {_Name.Get.original} is busy and can't be reached. Try again later. {Get.ExitMessage}";
            
        }
    }
}