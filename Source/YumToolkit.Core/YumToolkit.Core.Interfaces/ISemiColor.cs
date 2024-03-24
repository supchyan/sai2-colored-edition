namespace YumToolkit.Core.Interfaces {
    interface ISemiColor {
        byte[] SecondaryRGB { get; set; }
        byte[] TernaryRGB { get; set; }
        byte[] ArtifactsColor1 { get; }
        byte[] ArtifactsColor2 { get; }
        byte[] ArtifactsColor3 { get; }
        byte[] ArtifactsColor4 { get; }
        byte[] ArtifactsColor5 { get; }
        byte[] ArtifactsColor6 { get; }
        byte[] ArtifactsColor7 { get; }
        byte[] ArtifactsColor8 { get; }
    }
}