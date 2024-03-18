namespace YumToolkit.Core.Data {
    public static class _ServiceMessage {
        public static string TmpFileIsNotExists { get; }
        public static string OriginalFileIsNotExists { get; }
        public static string ExitMessage { get; }
        static _ServiceMessage() {
            ExitMessage = "Press any key to exit...";
            TmpFileIsNotExists = $"[ ERROR ] {_Name.tmp} is not found. {ExitMessage}";
            OriginalFileIsNotExists = $"[ ERROR ] {_Name.original} is not found. {ExitMessage}";
        }
    }
}