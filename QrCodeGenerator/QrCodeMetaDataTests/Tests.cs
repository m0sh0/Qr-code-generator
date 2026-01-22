using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QrCodeGeneratorProject.Utilites;
using QRCoder;

namespace QrCodeMetaDataTests;

public class Tests
{
    private const string DefaultText = "https://www.example.com";
    [Test]
    public void ConstructorShouldSetAllPropertiesCorrectly()
    {
        const string expectedText = DefaultText;
        const QrCodeTypes expectedType = QrCodeTypes.Url;
        const FormatTypes expectedFormat = FormatTypes.Svg;
        const QRCodeGenerator.ECCLevel expectedEccLevel = QRCodeGenerator.ECCLevel.Q;

        var metadata = new UrlQrCodeMetadata(expectedText, expectedFormat, expectedEccLevel);

        Assert.That(metadata.Text, Is.EqualTo(expectedText));
        Assert.That(metadata.Format, Is.EqualTo(expectedFormat));
        Assert.That(metadata.EccLevel, Is.EqualTo(expectedEccLevel));
    }
    
    [Test]
    public void ConstructorShouldThrowWhenTextIsEmpty()
    {
        Assert.That(
            () => new UrlQrCodeMetadata(string.Empty,  FormatTypes.Png, QRCodeGenerator.ECCLevel.L),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.TextIsNullOrEmpty));
    }

    [Test]
    public void ConstructorShouldThrowWhenTextIsNull()
    {
        Assert.That(
            () => new UrlQrCodeMetadata(null, FormatTypes.Png, QRCodeGenerator.ECCLevel.L),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.TextIsNullOrEmpty));
    }

    [Test]
    public void ConstructorShouldThrowWhenTextIsWhitespace()
    {
        Assert.That(
            () => new UrlQrCodeMetadata("   ", FormatTypes.Png, QRCodeGenerator.ECCLevel.L),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.TextIsNullOrEmpty));
    }
    
    [Test]
    public void ConstructorShouldThrowWhenFormatIsInvalid()
    {
        Assert.That(
            () => new UrlQrCodeMetadata(DefaultText, (FormatTypes)100, QRCodeGenerator.ECCLevel.L),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidFormat));
    }

    
    [Test]
    public void ConstructorShouldThrowWhenEccLevelIsInvalid()
    {
        Assert.That(
            () => new UrlQrCodeMetadata(DefaultText, FormatTypes.Png, (QRCodeGenerator.ECCLevel)100),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidEccLevel));
    }
    
    [Test]
    public void ConstructorShouldSucceedWithSvgFormat()
    {
        Assert.DoesNotThrow(() => 
            new UrlQrCodeMetadata(DefaultText, FormatTypes.Svg, QRCodeGenerator.ECCLevel.L));
    }

    [Test]
    public void ConstructorShouldSucceedWithEccLevelM()
    {
        Assert.DoesNotThrow(() => 
            new UrlQrCodeMetadata(DefaultText, FormatTypes.Png, QRCodeGenerator.ECCLevel.M));
    }

    [Test]
    public void ConstructorShouldSucceedWithEccLevelQ()
    {
        Assert.DoesNotThrow(() => 
            new UrlQrCodeMetadata(DefaultText, FormatTypes.Png, QRCodeGenerator.ECCLevel.Q));
    }

    [Test]
    public void ConstructorShouldSucceedWithEccLevelH()
    {
        Assert.DoesNotThrow(() => 
            new UrlQrCodeMetadata(DefaultText, FormatTypes.Png, QRCodeGenerator.ECCLevel.H));
    }
    
}