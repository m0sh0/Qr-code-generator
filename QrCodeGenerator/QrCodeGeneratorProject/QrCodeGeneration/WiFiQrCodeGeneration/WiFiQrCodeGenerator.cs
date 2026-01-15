using QrCodeGeneratorProject.DTO.Interfaces;

using QRCoder;

namespace QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;

public class WiFiQrCodeGenerator : IQrCodeGenerator<WiFiQrCodeMetadata>
{

    public QRCodeData GenerateQrCode(WiFiQrCodeMetadata wiFiQrCodeMetadata)
    {
        PayloadGenerator.WiFi generator = 
            new(wiFiQrCodeMetadata.Ssid, wiFiQrCodeMetadata.Password, PayloadGenerator.WiFi.Authentication.WPA);
        string payload = generator.ToString();
        
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);

        return qrCodeData;
    }
}