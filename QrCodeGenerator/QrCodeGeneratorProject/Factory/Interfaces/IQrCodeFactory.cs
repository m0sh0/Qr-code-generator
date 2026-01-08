using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.QrCodeGeneration;

namespace QrCodeGeneratorProject.Factory.Interfaces;

public interface IQrCodeFactory
{
    public UrlQrCodeResult GenerateQrCode(UrlQrCodeMetadata metadata);
}