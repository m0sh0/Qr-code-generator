using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.QrCodeGeneration;
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

        var metadata = new QrCodeMetadata(expectedText, expectedType, expectedFormat, expectedEccLevel);

        Assert.That(metadata.Text, Is.EqualTo(expectedText));
        Assert.That(metadata.Type, Is.EqualTo(expectedType));
        Assert.That(metadata.Format, Is.EqualTo(expectedFormat));
        Assert.That(metadata.EccLevel, Is.EqualTo(expectedEccLevel));
    }
    
    [Test]
    public void ConstructorShouldThrowWhenTextIsEmpty()
    {
        Assert.That(
            () => new QrCodeMetadata(string.Empty, QrCodeTypes.Url, FormatTypes.Png, QRCodeGenerator.ECCLevel.L),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.TextIsNullOrEmpty));
    }

    [Test]
    public void ConstructorShouldThrowWhenTextIsNull()
    {
        Assert.That(
            () => new QrCodeMetadata(null, QrCodeTypes.Url, FormatTypes.Png, QRCodeGenerator.ECCLevel.L),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.TextIsNullOrEmpty));
    }

    [Test]
    public void ConstructorShouldThrowWhenTextIsWhitespace()
    {
        Assert.That(
            () => new QrCodeMetadata("   ", QrCodeTypes.Url, FormatTypes.Png, QRCodeGenerator.ECCLevel.L),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.TextIsNullOrEmpty));
    }

    [Test]
    public void ConstructorShouldThrowWhenTypeIsInvalid()
    {
        Assert.That(
            () => new QrCodeMetadata(DefaultText, (QrCodeTypes)100, FormatTypes.Png, QRCodeGenerator.ECCLevel.L),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidQrCodeType));
    }

    [Test]
    public void ConstructorShouldThrowWhenFormatIsInvalid()
    {
        Assert.That(
            () => new QrCodeMetadata(DefaultText, QrCodeTypes.Url, (FormatTypes)100, QRCodeGenerator.ECCLevel.L),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidFormat));
    }

    
    [Test]
    public void ConstructorShouldThrowWhenEccLevelIsInvalid()
    {
        Assert.That(
            () => new QrCodeMetadata(DefaultText, QrCodeTypes.Url, FormatTypes.Png, (QRCodeGenerator.ECCLevel)100),
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidEccLevel));
    }

    [Test]
    public void ConstructorShouldSucceedWithValidUrlType()
    {
        Assert.DoesNotThrow(() => 
            new QrCodeMetadata(DefaultText, QrCodeTypes.Url, FormatTypes.Png, QRCodeGenerator.ECCLevel.L));
    }

    [Test]
    public void ConstructorShouldSucceedWithValidWifiType()
    {
        string wifiPayload = "WIFI:T:WPA;S:MyNetwork;P:MyPassword;;";
        
        Assert.DoesNotThrow(() => 
            new QrCodeMetadata(wifiPayload, QrCodeTypes.Wifi, FormatTypes.Png, QRCodeGenerator.ECCLevel.L));
    }

    [Test]
    public void ConstructorShouldSucceedWithSvgFormat()
    {
        Assert.DoesNotThrow(() => 
            new QrCodeMetadata(DefaultText, QrCodeTypes.Url, FormatTypes.Svg, QRCodeGenerator.ECCLevel.L));
    }

    [Test]
    public void ConstructorShouldSucceedWithEccLevelM()
    {
        Assert.DoesNotThrow(() => 
            new QrCodeMetadata(DefaultText, QrCodeTypes.Url, FormatTypes.Png, QRCodeGenerator.ECCLevel.M));
    }

    [Test]
    public void ConstructorShouldSucceedWithEccLevelQ()
    {
        Assert.DoesNotThrow(() => 
            new QrCodeMetadata(DefaultText, QrCodeTypes.Url, FormatTypes.Png, QRCodeGenerator.ECCLevel.Q));
    }

    [Test]
    public void ConstructorShouldSucceedWithEccLevelH()
    {
        Assert.DoesNotThrow(() => 
            new QrCodeMetadata(DefaultText, QrCodeTypes.Url, FormatTypes.Png, QRCodeGenerator.ECCLevel.H));
    }
    
}