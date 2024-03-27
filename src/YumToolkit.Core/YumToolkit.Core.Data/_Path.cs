using YumToolkit.Core.Interfaces;

namespace YumToolkit.Core.Data {
    class _Path : IPath {
        public string ThemesFolder { get; }
        public string JsonExtension { get; }
        public string GitHubLink { get; }
        public string DataFolder { get; }
        public string saiAddressFile { get; }
        public string saiColorARGBFile { get; }
        public string saiColorRGBFile { get; }
        public _Path() {
            ThemesFolder = "./themes";
            JsonExtension = ".json";
            GitHubLink = "https://github.com/supchyan/yum2-theme-toolkit";
            DataFolder = "./data";
            saiAddressFile = $"{DataFolder}/Address{JsonExtension}";
            saiColorARGBFile = $"{DataFolder}/ColorARGB{JsonExtension}";
            saiColorRGBFile = $"{DataFolder}/ColorRGB{JsonExtension}";
        }
    }
}