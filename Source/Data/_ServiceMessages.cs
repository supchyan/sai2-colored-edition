namespace YumToolkit.Data {
    public class _ServiceMessages {
        static _FileName sai_FileName = new _FileName();
        public string DevFileIsNotExists { get; }
        public string ClassicFileIsNotExists { get; }
        public _ServiceMessages() {
            DevFileIsNotExists = $"{sai_FileName.dev} is not found. Operation cancelled...";
            ClassicFileIsNotExists = $"{sai_FileName.classic} is not found. Operation cancelled...";
        }
    }
}