using Microsoft.AspNetCore.Mvc;
using QrCodeGeneratorProject.QrCodeGeneration;

namespace WebApplication1.Services.Interfaces;

public interface IQrCodeResponseService
{
    IActionResult GenerateQrCodeResponse(QrCodeResult qrCodeResult, FormatTypes format);
}