using QRCoder;

namespace QrCodeGeneratorProject;


class Program
{
    static void Main()
    {
        // IWriter writer = new FileWriter();
        // IQrCodeFactory factory = new QrCodeFactory();
        //
        // IEngine engine = new Engine(writer,factory);
        // engine.Run();
        
        
        var wifiPayload =  new PayloadGenerator.WiFi
            (
                ssid: "MyWifiNetwork",
                password: "MyWifiPassword", 
                PayloadGenerator.WiFi.Authentication.nopass, 
                isHiddenSSID: false,
                escapeHexStrings: true
            );
        
        QRCodeData qrCodeData = QRCodeGenerator.GenerateQrCode(wifiPayload, QRCodeGenerator.ECCLevel.Q);
        string qrCodeAsSvg = new SvgQRCode(qrCodeData).GetGraphic(20);
        File.WriteAllText("../../../Wifi.svg",qrCodeAsSvg);
    }
}