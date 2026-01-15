using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QRCoder;

namespace QrCodeGeneratorProject.DTO.Interfaces;

public interface IQrCodeGenerator<TQrCodeMetadata>
{
    public QRCodeData GenerateQrCode(TQrCodeMetadata urlQrCodeMetadata);
}