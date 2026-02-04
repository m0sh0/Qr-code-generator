using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QRCoder;

namespace UrlQrCodeMetadataTests.Url;

[TestFixture]
public class UrlQrCodeMetadataTests
{
    [Test]
    public void Constructor_ValidArguments_ShouldCreateObject()
    {
        UrlQrCodeMetadata metadata = new("https://example.com", FormatTypes.Png, QRCodeGenerator.ECCLevel.Q);

        Assert.That(metadata.Text, Is.EqualTo("https://example.com"));
        Assert.That(metadata.Format, Is.EqualTo(FormatTypes.Png));
        Assert.That(metadata.EccLevel, Is.EqualTo(QRCodeGenerator.ECCLevel.Q));
    }

    [Test]
    public void Constructor_InvalidFormat_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            FormatTypes invalidFormat = (FormatTypes)999;
            _ = new UrlQrCodeMetadata("https://example.com", invalidFormat, QRCodeGenerator.ECCLevel.M);
        });
    }

    [Test]
    public void Constructor_EmptyText_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new UrlQrCodeMetadata("", FormatTypes.Png, QRCodeGenerator.ECCLevel.M);
        });
    }

    [Test]
    public void Constructor_InvalidEccLevel_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidLevel = (QRCodeGenerator.ECCLevel)999;
            _ = new UrlQrCodeMetadata("https://example.com", FormatTypes.Png, invalidLevel);
        });
    }
}