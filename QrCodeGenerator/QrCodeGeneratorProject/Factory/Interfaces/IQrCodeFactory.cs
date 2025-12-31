using QrCodeGeneratorProject.DTO;

namespace QrCodeGeneratorProject.Factory.Interfaces;

public interface IQrCodeFactory
{
    public QrCodeResult GenerateQrCode(QrCodeMetadata metadata);
}