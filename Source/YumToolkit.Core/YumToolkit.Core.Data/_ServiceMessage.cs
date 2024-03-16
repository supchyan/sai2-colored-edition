namespace YumToolkit.Core.Data {
    public class _ServiceMessage : _YumTools {
        public string DevFileIsNotExists { get; }
        public string ClassicFileIsNotExists { get; }
        public string ExitMessage { get; }
        public _ServiceMessage() {
            DevFileIsNotExists = $"{GetFileName.Dev} is not found. Operation cancelled...";
            ClassicFileIsNotExists = $"{GetFileName.Classic} is not found. Operation cancelled...";
            ExitMessage = "Press any key to exit...";
        }
    }
}