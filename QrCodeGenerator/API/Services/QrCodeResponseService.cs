using Microsoft.AspNetCore.Mvc;
using QrCodeGeneratorProject.QrCodeGeneration;
using WebApplication1.Services.Interfaces;
using System.Text;

namespace WebApplication1.Services;

public class QrCodeResponseService : IQrCodeResponseService
{
    public IActionResult GenerateQrCodeResponse(QrCodeResult qrCodeResult, FormatTypes format)
    {
        if (format == FormatTypes.Svg)
        {
            byte[] svgBytes = Encoding.UTF8.GetBytes(qrCodeResult.StringData);
            
            return new FileContentResult(svgBytes, GetContentType(format))
            {
                FileDownloadName = GetFileName(format)
            };
        }

        return new FileContentResult(qrCodeResult.ByteData, GetContentType(format))
        {
            FileDownloadName = GetFileName(format)
        };
    }
    
    private static string GetContentType(FormatTypes format)
    {
        return format switch
        {
            FormatTypes.Png => "image/png",
            FormatTypes.Jpeg => "image/jpeg",
            FormatTypes.Svg => "image/svg+xml",
            FormatTypes.Pdf => "application/pdf",
            _ => "application/octet-stream"
        };
    }
    
    private static string GetFileName(FormatTypes format)
        => $"QrCode.{format.ToString().ToLower().ToLowerInvariant()}";
}