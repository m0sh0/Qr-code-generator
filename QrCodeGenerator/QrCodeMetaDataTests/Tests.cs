using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QRCoder;

namespace QrCodeTests.Url;

[TestClass]
public class UrlQrCodeMetadataTests
{
    [TestMethod]
    public void Constructor_ValidArguments_ShouldCreateObject()
    {
        var metadata = new UrlQrCodeMetadata("https://example.com", FormatTypes.Png, QRCodeGenerator.ECCLevel.Q);

        Assert.AreEqual("https://example.com", metadata.Text);
        Assert.AreEqual(FormatTypes.Png, metadata.Format);
        Assert.AreEqual(QRCodeGenerator.ECCLevel.Q, metadata.EccLevel);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_InvalidFormat_ShouldThrow()
    {
        var invalidFormat = (FormatTypes)999;
        _ = new UrlQrCodeMetadata("https://example.com", invalidFormat, QRCodeGenerator.ECCLevel.M);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_EmptyText_ShouldThrow()
    {
        _ = new UrlQrCodeMetadata("", FormatTypes.Png, QRCodeGenerator.ECCLevel.M);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_InvalidEccLevel_ShouldThrow()
    {
        var invalidLevel = (QRCodeGenerator.ECCLevel)999;
        _ = new UrlQrCodeMetadata("https://example.com", FormatTypes.Png, invalidLevel);
    }
}