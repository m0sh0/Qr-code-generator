using System.Drawing;
using QrCodeGeneratorProject.Core.Interfaces;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.IO.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;
using QrCodeGeneratorProject.Renderers.Interfaces;
using QrCodeGeneratorProject.Renderers.Models;
using QRCoder;

namespace QrCodeGeneratorProject.Core;

public class Engine : IEngine
{
    private readonly IWriter _writer;
    private readonly IQrCodeFactory _factory;
    
    public Engine(IWriter writer, IQrCodeFactory factory)
    {
        this._writer = writer;
        this._factory = factory;
    }
    
    public void Run() {

        UrlQrCodeMetadata metadata = new
        (
            text: "https://www.figma.com/files/team/1593625816809015669/recents-and-sharing?fuid=1593625814914515783",
            type: QrCodeTypes.Url,
            FormatTypes.Png,
            QRCodeGenerator.ECCLevel.Q
        );
        
        UrlQrCodeResult result = this._factory.GenerateQrCode(metadata);
        
        this._writer.WriteBytes(result.ByteData, $"../../../Figma.{metadata.Format.ToString().ToLower()}");
        
        
        // PayloadGenerator.WiFi generator = new PayloadGenerator.WiFi("My-WiFis-Name", "s3cr3t-p4ssw0rd", PayloadGenerator.WiFi.Authentication.WPA);
        // string payload = generator.ToString();
        //
        // QRCodeGenerator qrGenerator = new QRCodeGenerator();
        // QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
        // IBinaryRenderer renderer = new PngRenderer();
        // byte[] qrCodeImage = renderer.Render(qrCodeData);
        // this._writer.WriteBytes(qrCodeImage, "../../../wifi.png");
        // QRCode qrCode = new QRCode(qrCodeData);
        // Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20);
        
       // WiFiQrCodeMetadata m = new("Wifi-name", "password", FormatTypes.Png, AuthenticationTypes.Wpa2);



    }
}