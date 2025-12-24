using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.Renderers.Models;
using QrCodeGeneratorProject.Utilites;
using QRCoder;

namespace QrCodeGeneratorProject.Factory;

public class QrCodeFactory : IQrCodeFactory
{
    public QrCodeResult GenerateQrCode(QrCodeMetadata metadata)
    {
        switch (metadata.Format)
        {
            case FormatTypes.Png:
                
                QRCodeData qrCodeData = GenerateUrlQrCode(metadata);
                byte[] qrCodeImage = new PngRenderer().Render(qrCodeData);
                
                return new QrCodeResult(qrCodeImage, metadata.Format);
            
            default:
                throw new NotImplementedException(ExceptionMessages.QrCodeFormatNotSupported);
            
        }
        
        return null;
    }
    
    public QRCodeData GenerateUrlQrCode(QrCodeMetadata metadata)
    {
        PayloadGenerator.Url urlPayload = new(metadata.Text);
                
        QRCodeData urlQrCodeData = QRCodeGenerator
            .GenerateQrCode(urlPayload, metadata.EccLevel);
        
        return urlQrCodeData;
    }
}