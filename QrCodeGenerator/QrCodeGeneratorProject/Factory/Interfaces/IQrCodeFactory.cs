using QrCodeGeneratorProject.DTO.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;

namespace QrCodeGeneratorProject.Factory.Interfaces;

public interface IQrCodeFactory
{
    public QrCodeResult GenerateQrCode(IQrCodeMetadata metadata);
}