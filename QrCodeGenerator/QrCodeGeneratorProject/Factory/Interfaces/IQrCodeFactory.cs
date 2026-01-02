using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.QrCodeGeneration;

namespace QrCodeGeneratorProject.Factory.Interfaces;

public interface IQrCodeFactory
{
    public QrCodeResult GenerateQrCode(QrCodeMetadata metadata);
}