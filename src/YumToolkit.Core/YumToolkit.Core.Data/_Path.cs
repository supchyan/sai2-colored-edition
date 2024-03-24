using YumToolkit.Core.Interfaces;

namespace YumToolkit.Core.Data {
    class _Path : IPath {
        public string ThemesFolder { get; }
        public string ThemesExtension { get; }
        public string GitHubLink { get; }
        public _Path() {
            ThemesFolder = "./Themes";
            ThemesExtension = ".json";
            GitHubLink = "https://github.com/supchyan/yum2-theme-toolkit";
        }
    }
}