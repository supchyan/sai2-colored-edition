namespace YumToolkit.Core.Data {
    public class _ServiceMessage {
        public static _ServiceMessage GetMessage = new _ServiceMessage();
        public string DevFileIsNotExists { get; }
        public string ClassicFileIsNotExists { get; }
        public string ExitMessage { get; }
        public _ServiceMessage() {
            ExitMessage = "Press any key to exit...";
            DevFileIsNotExists = $"[ ERROR ] {_Name.GetFileName.Dev} is not found. {ExitMessage}";
            ClassicFileIsNotExists = $"[ ERROR ] {_Name.GetFileName.Classic} is not found. {ExitMessage}";
        }
    }
}