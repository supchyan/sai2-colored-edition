namespace YumToolkit.Core.Data {
    public class _ServiceMessages {
        public string DevFileIsNotExists { get; }
        public string ClassicFileIsNotExists { get; }
        public _ServiceMessages() {
            DevFileIsNotExists = $"{_File.GetName.Dev} is not found. Operation cancelled...";
            ClassicFileIsNotExists = $"{_File.GetName.Classic} is not found. Operation cancelled...";
        }
    }
}