using Microsoft.AspNetCore.Mvc;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UrlQrCodeController : ControllerBase
{
    private readonly IQrCodeFactory _qrCodeFactory;
    private readonly IQrCodeResponseService _repsonseService;

    public UrlQrCodeController(IQrCodeFactory qrCodeFactory, IQrCodeResponseService responseService)
    {
        this._qrCodeFactory = qrCodeFactory;
        this._repsonseService = responseService;
    }

    [HttpPost("generate")]
    public IActionResult GenerateQr([FromBody] UrlQrCodeMetadata metadata)
    {
        QrCodeResult result = this._qrCodeFactory.GenerateQrCode(metadata);
        return this._repsonseService.GenerateQrCodeResponse(result, metadata.Format);
    }
}