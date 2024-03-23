namespace YumToolkit.Core.Data {
    class _Path {
        public static _Path Get;
        public string ThemesFolder { get; private set; } = string.Empty;
        public string ThemesExtension { get; private set; } = string.Empty;
        public string GitHubLink { get; private set; } = string.Empty;
        static _Path() {
            Get = new _Path {
                ThemesFolder = "./Themes",
                ThemesExtension = ".json",
                GitHubLink = "https://github.com/supchyan/yum2-theme-toolkit",
            };
        }
    }
}