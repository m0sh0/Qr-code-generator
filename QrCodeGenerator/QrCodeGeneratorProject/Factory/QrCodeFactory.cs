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
                
                IRenderer<byte[]> pngRenderer = new PngRenderer();
                QRCodeData pngQrCodeData = GenerateUrlQrCode(metadata);
                byte[] qrCodeImage = pngRenderer.Render(pngQrCodeData);
                
                return new QrCodeResult(qrCodeImage, metadata.Format);
            
            case FormatTypes.Svg:
                
                IRenderer<string> svgRenderer = new SvgRenderer();
                QRCodeData svgQrCodeData = GenerateUrlQrCode(metadata);
                string svgCodeImage = svgRenderer.Render(svgQrCodeData);
                
                return new QrCodeResult(svgCodeImage, metadata.Format);
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