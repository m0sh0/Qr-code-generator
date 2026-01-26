using Microsoft.AspNetCore.Mvc;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class QrCodeController : ControllerBase
{
    private readonly IQrCodeFactory _qrCodeFactory;

    public QrCodeController(IQrCodeFactory qrCodeFactory)
    {
        this._qrCodeFactory = qrCodeFactory;
    }

    [HttpPost("generate")]
    public IActionResult GenerateQr([FromBody] UrlQrCodeMetadata metadata)
    {
        QrCodeResult result = this._qrCodeFactory.GenerateQrCode(metadata);

        return File(result.ByteData, "application/octet-stream", "Test.png");
    }
}