using Microsoft.AspNetCore.Mvc;
using Moq;
using QrCodeGeneratorProject.DTO.Interfaces;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QRCoder;
using WebApplication1.Controllers;
using WebApplication1.Services.Interfaces;

namespace UrlQrCodeMetadataTests.Url.QrCodeControllerTests;

[TestFixture]
public class UrlQrCodeControllerTests
{
    private Mock<IQrCodeFactory> _mockFactory;
    private Mock<IQrCodeResponseService> _mockResponseService;
    private UrlQrCodeController _controller;

    [SetUp]
    public void SetUp()
    {
        this._mockFactory = new Mock<IQrCodeFactory>();
        this._mockResponseService = new Mock<IQrCodeResponseService>();

        this._controller = new UrlQrCodeController(_mockFactory.Object, _mockResponseService.Object);
    }

    #region Basic Flow Tests

    [Test]
    public void GenerateQr_ValidMetadata_ShouldCallFactoryAndService()
    {
        UrlQrCodeMetadata metadata = new(
            "https://example.com",
            FormatTypes.Png,
            QRCodeGenerator.ECCLevel.M
        );

        UrlQrCodeResult qrCodeResult = new(new byte[] { 10, 20, 30 }, FormatTypes.Png);
        var expectedResponse = new Microsoft.AspNetCore.Mvc.OkResult();

        this._mockFactory
            .Setup(f => f.GenerateQrCode(It.IsAny<UrlQrCodeMetadata>()))
            .Returns(qrCodeResult);

        this._mockResponseService
            .Setup(s => s.GenerateQrCodeResponse(qrCodeResult, metadata.Format))
            .Returns(expectedResponse);

        var response = this._controller.GenerateQr(metadata);

        Assert.That(response, Is.SameAs(expectedResponse));
        this._mockFactory.Verify(
            f => f.GenerateQrCode(It.Is<IQrCodeMetadata>(m => ReferenceEquals(m, metadata))),
            Times.Once
        );
        this._mockResponseService.Verify(
            s => s.GenerateQrCodeResponse(qrCodeResult, metadata.Format),
            Times.Once
        );
    }
    #endregion

    #region Different Format Tests

    [TestCase(FormatTypes.Png)]
    [TestCase(FormatTypes.Jpeg)]
    [TestCase(FormatTypes.Pdf)]
    [TestCase(FormatTypes.Svg)]
    public void GenerateQr_DifferentFormats_ShouldPassFormatToService(FormatTypes format)
    {
        UrlQrCodeMetadata metadata = new UrlQrCodeMetadata(
            "https://example.com",
            format,
            QRCodeGenerator.ECCLevel.M
        );
        
        QrCodeResult fakeResult = format == FormatTypes.Svg
            ? new UrlQrCodeResult("<svg></svg>", format)
            : new UrlQrCodeResult(new byte[] { 1 }, format);
        
        this._mockFactory
            .Setup(f => f.GenerateQrCode(It.IsAny<UrlQrCodeMetadata>()))
            .Returns(fakeResult);

        this._mockResponseService
            .Setup(s => s.GenerateQrCodeResponse(It.IsAny<QrCodeResult>(), It.IsAny<FormatTypes>()))
            .Returns(new OkResult());


        this._controller.GenerateQr(metadata);
        
        this._mockResponseService.Verify(
            s => s.GenerateQrCodeResponse(It.IsAny<QrCodeResult>(), format),
            Times.Once
        );
    }

    #endregion

    #region Order Of Operations Tests
    
    [Test]
    public void GenerateQr_ShouldCallFactoryBeforeService()
    {
        UrlQrCodeMetadata metadata = new UrlQrCodeMetadata(
            "https://example.com",
            FormatTypes.Png,
            QRCodeGenerator.ECCLevel.M
        );
        
        var callSequence =  new MockSequence();
        
        this._mockFactory.InSequence(callSequence)
            .Setup(f => f.GenerateQrCode(It.IsAny<UrlQrCodeMetadata>()))
            .Returns(new UrlQrCodeResult(new byte[] { 1 }, FormatTypes.Png));
        
        this._mockResponseService.InSequence(callSequence)
            .Setup(s => s.GenerateQrCodeResponse(It.IsAny<QrCodeResult>(), It.IsAny<FormatTypes>()))
            .Returns(new FileContentResult(new byte[] { 1 }, "image/png"));
        
        this._controller.GenerateQr(metadata);
        
        this._mockFactory.Verify(f => f.GenerateQrCode(It.IsAny<UrlQrCodeMetadata>()), Times.Once);
        this._mockResponseService.Verify(s => s.GenerateQrCodeResponse(It.IsAny<QrCodeResult>(), It.IsAny<FormatTypes>()), Times.Once);
    }
    
    #endregion
    
    #region Data Flow Tests

    [Test]
    public void GenerateQr_ShouldPassFactoryOutputToService()
    {
        UrlQrCodeMetadata metadata = new(
            "https://example.com",
            FormatTypes.Png,
            QRCodeGenerator.ECCLevel.M
        );

        byte[] specificBytes = new byte[] { 99, 88, 77, 66 };
        UrlQrCodeResult specificResult = new(specificBytes, FormatTypes.Png);
        
        this._mockFactory
            .Setup(f => f.GenerateQrCode(It.IsAny<UrlQrCodeMetadata>()))
            .Returns(specificResult);
        
        this._mockResponseService
            .Setup(s => s.GenerateQrCodeResponse(It.IsAny<QrCodeResult>(), It.IsAny<FormatTypes>()))
            .Returns(new FileContentResult(new byte[] { 1 }, "image/png"));
        
        this._controller.GenerateQr(metadata);
        
        this._mockResponseService
            .Verify(s => s.GenerateQrCodeResponse(
                It.Is<QrCodeResult>(r => r == specificResult),FormatTypes.Png),
                Times.Once);

    }
    #endregion
    
    #region Error Propagation Tests

    /// <summary>
    /// Test that exceptions from the factory are propagated
    /// </summary>
    [Test]
    public void GenerateQr_FactoryThrows_ShouldPropagateException()
    {
        UrlQrCodeMetadata metadata = new(
            "https://example.com",
            FormatTypes.Png,
            QRCodeGenerator.ECCLevel.M
        );

        this._mockFactory
            .Setup(f => f.GenerateQrCode(It.IsAny<UrlQrCodeMetadata>()))
            .Throws(new ArgumentException("Factory threw exception"));

        Assert.Throws<ArgumentException>
        (() => this._controller.GenerateQr(metadata)
        );

        this._mockResponseService.Verify(
            s => s.GenerateQrCodeResponse(It.IsAny<QrCodeResult>(), It.IsAny<FormatTypes>()),
            Times.Never
        );
    }
    
    /// <summary>
    /// Test that exceptions from service are propagated
    /// </summary>
    [Test] public void GenerateQr_ServiceThrows_ShouldPropagateException()
    {
        UrlQrCodeMetadata metadata = new(
            "https://example.com",
            FormatTypes.Png,
            QRCodeGenerator.ECCLevel.M );
        
        this._mockFactory
            .Setup(f => f.GenerateQrCode(It.IsAny<UrlQrCodeMetadata>()))
            .Returns(new UrlQrCodeResult(new byte[] { 1 }, FormatTypes.Png));
        
        this._mockResponseService
            .Setup(s => s.GenerateQrCodeResponse(It.IsAny<QrCodeResult>(), It.IsAny<FormatTypes>()))
            .Throws(new ArgumentException("Service threw exception"));
        
        Assert.Throws<ArgumentException>
        (
            () => this._controller.GenerateQr(metadata)
        );
    }
    }
    #endregion
