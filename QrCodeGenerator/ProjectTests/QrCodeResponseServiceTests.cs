using System.Text;
using Microsoft.AspNetCore.Mvc;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using WebApplication1.Services;

namespace UrlQrCodeMetadataTests.Url;

/// <summary>
/// Tests for QrCodeResponseService
/// </summary>
[TestFixture]
public class QrCodeResponseServiceTests
{
    private QrCodeResponseService _service;
    
    [SetUp]
    public void Setup()
    {
        this._service = new QrCodeResponseService();
    }

    #region  PNG Format Tests

    [Test]
    public void GenerateQrCodeResponse_PngFormat_ShouldReturnCorrectContentType()
    {
        byte[] fakeBytes = { 1, 2, 3, 4, 5 };
        UrlQrCodeResult qrCodeResult = new(fakeBytes, FormatTypes.Png);
        
        IActionResult result = this._service.GenerateQrCodeResponse(qrCodeResult, FormatTypes.Png);
        
        FileContentResult fileResult = this._service.GenerateQrCodeResponse(qrCodeResult, FormatTypes.Png) as FileContentResult;
        
        Assert.That(fileResult.ContentType, Is.EqualTo("image/png"));
        Assert.That(fileResult.FileDownloadName, Is.EqualTo("QrCode.png"));
        Assert.That(fileResult.FileContents, Is.EqualTo(fakeBytes));
    }
    #endregion

    #region SVG Format Tests

    [Test]
    public void GenerateQrCodeResponse_SvgFormat_ShouldConvertStringToBytes()
    {
        string fakeSvgString = "<svg><rect width=\"10\" height=\"10\"/></svg>";
        UrlQrCodeResult qrCodeResult = new(fakeSvgString, FormatTypes.Svg);
        
        IActionResult fileResult = this._service.GenerateQrCodeResponse(qrCodeResult, FormatTypes.Svg);
        
        FileContentResult fileContentResult = fileResult as FileContentResult;
        Assert.That(fileContentResult.ContentType, Is.EqualTo("image/svg+xml"));
        Assert.That(fileContentResult.FileDownloadName, Is.EqualTo("QrCode.svg"));
        
        byte[] excpectedBytes = Encoding.UTF8.GetBytes(fakeSvgString);
        Assert.That(fileContentResult.FileContents, Is.EqualTo(excpectedBytes));
    }

    #endregion

    #region All Formats Tests

    [TestCase(FormatTypes.Png, "image/png", "QrCode.png")]
    [TestCase(FormatTypes.Jpeg, "image/jpeg", "QrCode.jpeg")]
    [TestCase(FormatTypes.Pdf, "application/pdf", "QrCode.pdf")]
    [TestCase(FormatTypes.Svg, "image/svg+xml", "QrCode.svg")]
    public void GenerateQrCodeResponse_AllFormats_ShouldHaveCorrectProperties(
        FormatTypes format,
        string expectedContentType,
        string expectedFileName)
    {
        QrCodeResult qrCodeResult = format == FormatTypes.Svg
            ? new UrlQrCodeResult("<svg></svg>", format)
            : new UrlQrCodeResult(new byte[1], format);
        
        IActionResult result = this._service.GenerateQrCodeResponse(qrCodeResult, format);
        
        FileContentResult fileResult = result as FileContentResult;
        
        Assert.That(fileResult.ContentType, Is.EqualTo(expectedContentType));
        Assert.That(fileResult.FileDownloadName, Is.EqualTo(expectedFileName));
    }
    
    #endregion
}