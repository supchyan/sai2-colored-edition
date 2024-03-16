namespace YumToolkit.Data {
    public class _ServiceMessages {
        public string DevFileIsNotExists { get; }
        public string ClassicFileIsNotExists { get; }
        public _ServiceMessages() {
            DevFileIsNotExists = $"{_File.GetName.dev} is not found. Operation cancelled...";
            ClassicFileIsNotExists = $"{_File.GetName.classic} is not found. Operation cancelled...";
        }
    }
}