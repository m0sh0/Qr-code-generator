using QrCodeGeneratorProject.DTO.Interfaces;
using QRCoder;

namespace QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
///<summary>
/// A class that generates QR codes for URLs.
///</summary>
public class UrlQrCodeGenerator : IQrCodeGenerator<UrlQrCodeMetadata>
{
    public QRCodeData GenerateQrCode(UrlQrCodeMetadata urlQrCodeMetadata)
    {
        PayloadGenerator.Url urlPayload = new(urlQrCodeMetadata.Text);
                
        QRCodeData urlQrCodeData = QRCodeGenerator
            .GenerateQrCode(urlPayload, urlQrCodeMetadata.EccLevel);
        
        return urlQrCodeData;
    }
}