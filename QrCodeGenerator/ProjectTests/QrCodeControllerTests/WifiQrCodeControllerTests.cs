using Microsoft.AspNetCore.Mvc;
using Moq;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;
using WebApplication1.Controllers;
using WebApplication1.Services.Interfaces;

namespace UrlQrCodeMetadataTests.Url.QrCodeControllerTests;

[TestFixture]
public class WifiQrCodeControllerTests
{
    private Mock<IQrCodeFactory> _mockFactory;
    private Mock<IQrCodeResponseService> _mockResponseService;
    private WiFiQrCodeController _qrCodeController;

    [SetUp]
    public void SetUp()
    {
        this._mockFactory = new Mock<IQrCodeFactory>();
        this._mockResponseService = new Mock<IQrCodeResponseService>();
        this._qrCodeController = new WiFiQrCodeController(this._mockFactory.Object, this._mockResponseService.Object);
    }

    #region Deffrent Format Tests

    [TestCase(FormatTypes.Jpeg)]
    [TestCase(FormatTypes.Pdf)]
    [TestCase(FormatTypes.Svg)]
    [TestCase(FormatTypes.Png)]
    public void WiFiController_JpegFormat_ShouldReturnCorrectContentType(FormatTypes format)
    {
        WiFiQrCodeMetadata metadata = new
            (
                "Test",
                "Password123",
                format,
                AuthenticationTypes.Wpa
            );

        UrlQrCodeResult fakeResult = format == FormatTypes.Svg
            ? new UrlQrCodeResult("<svg></svg>", format)
            : new UrlQrCodeResult(new byte[] { 1 }, format);

        this._mockFactory
            .Setup(f => f.GenerateQrCode(It.IsAny<WiFiQrCodeMetadata>()))
            .Returns(fakeResult);

        this._mockResponseService
            .Setup(s => s.GenerateQrCodeResponse(It.IsAny<QrCodeResult>(), It.IsAny<FormatTypes>()))
            .Returns(new OkResult());
        
        this._qrCodeController.GenerateQr(metadata);
        
        this._mockResponseService
            .Verify(s => s.GenerateQrCodeResponse(It.IsAny<QrCodeResult>(), format), 
                Times.Once);
    }
    #endregion
}