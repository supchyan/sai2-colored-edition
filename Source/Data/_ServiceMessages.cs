namespace YumToolkit.Data {
    public class _ServiceMessages {
        static _FileName fileName = new _FileName();
        public string DevFileIsNotExists { get; }
        public string ClassicFileIsNotExists { get; }
        public _ServiceMessages() {
            DevFileIsNotExists = $"{fileName.dev} is not found. Operation cancelled...";
            ClassicFileIsNotExists = $"{fileName.classic} is not found. Operation cancelled...";
        }
    }
}