using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.DTO.Interfaces;
using QRCoder;

namespace QrCodeGeneratorProject.QrCodeGeneration;
//<summary>
// A class that generates QR codes for URLs.
//</summary>
public class UrlQrCodeGenerator : IQrCodeGenerator
{
    public QRCodeData GenerateQrCode(UrlQrCodeMetadata urlQrCodeMetadata)
    {
        PayloadGenerator.Url urlPayload = new(urlQrCodeMetadata.Text);
                
        QRCodeData urlQrCodeData = QRCodeGenerator
            .GenerateQrCode(urlPayload, urlQrCodeMetadata.EccLevel);
        
        return urlQrCodeData;
    }
}