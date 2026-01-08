using QrCodeGeneratorProject.QrCodeGeneration;
using QRCoder;

namespace QrCodeGeneratorProject.DTO.Interfaces;

public interface IQrCodeGenerator
{
    public QRCodeData GenerateQrCode(UrlQrCodeMetadata urlQrCodeMetadata);
}