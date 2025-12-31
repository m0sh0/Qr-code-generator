using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.Renderers.Interfaces;
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
                
                IRenderer pngRenderer = new PngRenderer();
                QRCodeData urlQrCodeData = GenerateUrlQrCode(metadata);
                byte[] qrCodeImage = pngRenderer.Render(urlQrCodeData);
                
                return new QrCodeResult(qrCodeImage, metadata.Format);
            
            case FormatTypes.Pdf:
                
                IRenderer pdfRenderer = new SvgRenderer();
                PayloadGenerator.Url urlPayload = new(metadata.Text);
                QRCodeData pdfQrCodeData = QRCodeGenerator.GenerateQrCode(urlPayload);
                byte[] pdfQrCodeImage = pdfRenderer.Render(pdfQrCodeData);
                
                return new QrCodeResult(pdfQrCodeImage, metadata.Format);
            default:
                throw new NotSupportedException(ExceptionMessages.QrCodeFormatNotSupported);
        }
    }
    
    public QRCodeData GenerateUrlQrCode(QrCodeMetadata metadata)
    {
        PayloadGenerator.Url urlPayload = new(metadata.Text);
                
        QRCodeData urlQrCodeData = QRCodeGenerator
            .GenerateQrCode(urlPayload, metadata.EccLevel);
        
        return urlQrCodeData;
    }
}