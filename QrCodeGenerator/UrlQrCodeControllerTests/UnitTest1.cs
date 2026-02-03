using Microsoft.AspNetCore.Mvc;
using Moq;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QRCoder;
using WebApplication1.Controllers;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;

namespace UrlQrCodeControllerTests;

//TODO: Add more tests and fix existing ones
[TestFixture]
public class UrlQrCodeControllerTests
{
    private Mock<IQrCodeFactory> _mockFactory;
    private Mock<IQrCodeResponseService> _mockResponseService;
    private UrlQrCodeController _controller;
    
    [SetUp]
    public void Setup()
    {
        this._mockFactory = new Mock<IQrCodeFactory>();
        this._mockResponseService = new Mock<IQrCodeResponseService>();
        this._controller = new UrlQrCodeController(this._mockFactory.Object, this._mockResponseService.Object);
    }

    #region PNG Tests

    [Test]
    public void GenerateQr_PngFormat_ShouldReturnFileWithCorrectContentType()
    {
        UrlQrCodeMetadata metadata = new(
            "https://example.com",
            FormatTypes.Png,
            QRCodeGenerator.ECCLevel.M
       );

        byte[] fakeBytes = new byte[] { 1, 2, 3, 4, 5 };
        UrlQrCodeResult fakeResult = new(fakeBytes, FormatTypes.Png);
        
        this._mockFactory
            .Setup(f => f.GenerateQrCode(It.IsAny<UrlQrCodeMetadata>()))
            .Returns(fakeResult);

        IActionResult result = this._controller.GenerateQr(metadata);
        
        Assert.That(result, Is.InstanceOf<FileContentResult>());
    }

    #endregion
}