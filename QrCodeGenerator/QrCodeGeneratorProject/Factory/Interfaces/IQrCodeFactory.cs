using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;

namespace QrCodeGeneratorProject.Factory.Interfaces;

public interface IQrCodeFactory
{
    public UrlQrCodeResult GenerateQrCode(UrlQrCodeMetadata metadata);
}