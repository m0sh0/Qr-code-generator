using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.DTO.Interfaces;
using QRCoder;

namespace QrCodeGeneratorProject.QrCodeGeneration;
//<summary>
// A class that generates QR codes for URLs.
//</summary>
public class UrlQrCodeGenerator : IQrCodeGenerator
{
    public QRCodeData GenerateQrCode(QrCodeMetadata qrCodeMetadata)
    {
        PayloadGenerator.Url urlPayload = new(qrCodeMetadata.Text);
                
        QRCodeData urlQrCodeData = QRCodeGenerator
            .GenerateQrCode(urlPayload, qrCodeMetadata.EccLevel);
        
        return urlQrCodeData;
    }
}