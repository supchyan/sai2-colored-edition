namespace YumToolkit.Core.Interfaces {
    interface ISemiColor {
        byte[] PrimaryRGB { get; set; }
        byte[] SecondaryRGB { get; set; }
        byte[] TernaryRGB { get; set; }
        byte[] SelectablePrimaryRGB { get; set; }
        byte[] SelectableSecondaryRGB { get; set; }
        byte[] TernaryArtifactsColor1 { get; set; }
        byte[]  TernaryArtifactsColor2 { get; set; }
        byte[]  TernaryArtifactsColor3 { get; set; }
        byte[]  TernaryArtifactsColor4 { get; set; }
        byte[]  TernaryArtifactsColor5 { get; set; }
        byte[]  TernaryArtifactsColor6 { get; set; }
        byte[]  TernaryArtifactsColor7 { get; set; }
        byte[]  TernaryArtifactsColor8 { get; set; }
        byte[]  SecondaryArtifactsColor1 { get; set; }
        byte[]  SecondaryArtifactsColor2 { get; set; }
        byte[]  SecondaryArtifactsColor3 { get; set; }
        byte[]  SecondaryArtifactsColor4 { get; set; }
    }
}