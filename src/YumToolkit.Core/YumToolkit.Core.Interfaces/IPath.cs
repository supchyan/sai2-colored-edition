namespace YumToolkit.Core.Interfaces {
    interface IPath {
        string ThemesFolder { get; }
        string JsonExtension { get; }
        string GitHubLink { get; }
        string DataFolder { get; }
        string saiAddressFile { get; }
        string saiColorARGBFile { get; }
        string saiColorRGBFile { get; }
    }
}