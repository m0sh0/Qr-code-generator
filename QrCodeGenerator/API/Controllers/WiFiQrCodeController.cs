using Microsoft.AspNetCore.Mvc;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WiFiQrCodeController : ControllerBase
{
    private readonly IQrCodeFactory _qrCodeFactory;

    public WiFiQrCodeController(IQrCodeFactory qrCodeFactory)
    {
        this._qrCodeFactory = qrCodeFactory;    
    }

    [HttpPost("generate")]
    public IActionResult GenerateQr([FromBody] WiFiQrCodeMetadata metadata)
    {
        QrCodeResult result = this._qrCodeFactory.GenerateQrCode(metadata);
        string contentType = GetContentType(metadata.Format);
        string fileName = GetFileName(metadata.Format);
        
        return GetAppropriateResult(result, contentType, fileName);
    }
    
    private IActionResult GetAppropriateResult(QrCodeResult result, string contentType, string fileName)
    {
        if (result.IsBinary)
        {
            return File
            (
                result.ByteData, 
                contentType, 
                fileName
            );
        }
        
        return File
        (
            System.Text.Encoding.UTF8.GetBytes(result.StringData),
            contentType,
            fileName
        );
    }
    private static string GetContentType(FormatTypes format)
    {
        switch (format)
        {
            case FormatTypes.Png: return "image/png";
            case FormatTypes.Jpeg: return "image/jpeg";
            case FormatTypes.Svg: return "image/svg+xml";
            case FormatTypes.Pdf: return "application/pdf";
            default: return "application/octet-stream";
        }
    }
    
    private static string GetFileName(FormatTypes format)
        => $"QrCode.{format.ToString().ToLower().ToLowerInvariant()}";
}