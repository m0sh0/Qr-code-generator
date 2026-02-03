using Microsoft.AspNetCore.Mvc;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;

namespace WebApplication1.Controllers;

public interface IQrCodeController
{
    public IActionResult GenerateQr([FromBody] UrlQrCodeMetadata metadata);
}