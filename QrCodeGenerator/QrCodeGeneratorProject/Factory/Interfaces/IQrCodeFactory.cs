using QrCodeGeneratorProject.DTO.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.Interfaces;

namespace QrCodeGeneratorProject.Factory.Interfaces;

public interface IQrCodeFactory
{
    public QrCodeResult GenerateQrCode(IQrCodeMetadata metadata);
}