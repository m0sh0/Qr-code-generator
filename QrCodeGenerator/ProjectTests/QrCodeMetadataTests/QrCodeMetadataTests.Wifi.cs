using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;

namespace QrCodeMetadataTests.Wifi;

[TestFixture]
public class WiFiQrCodeMetadataTests
{
    [Test]
    public void Constructor_ValidArguments_ShouldCreateObject()
    {
        var metadata = new WiFiQrCodeMetadata("MySSID", "MyPassword", FormatTypes.Pdf, AuthenticationTypes.Wpa2);

        Assert.That(metadata.Ssid, Is.EqualTo("MySSID"));
        Assert.That(metadata.Password, Is.EqualTo("MyPassword"));
        Assert.That(metadata.Format, Is.EqualTo(FormatTypes.Pdf));
        Assert.That(metadata.Authentication, Is.EqualTo(AuthenticationTypes.Wpa2));
    }

    [Test]
    public void Constructor_EmptySsid_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new WiFiQrCodeMetadata("", "password", FormatTypes.Svg, AuthenticationTypes.Wpa);
        });
    }

    [Test]
    public void Constructor_EmptyPassword_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new WiFiQrCodeMetadata("SSID", "", FormatTypes.Svg, AuthenticationTypes.Wpa);
        });
    }

    [Test]
    public void Constructor_InvalidFormat_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidFormat = (FormatTypes)999;
            _ = new WiFiQrCodeMetadata("SSID", "pass", invalidFormat, AuthenticationTypes.Wpa);
        });
    }

    [Test]
    public void Constructor_InvalidAuthType_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidAuth = (AuthenticationTypes)999;
            _ = new WiFiQrCodeMetadata("SSID", "pass", FormatTypes.Png, invalidAuth);
        });
    }
}