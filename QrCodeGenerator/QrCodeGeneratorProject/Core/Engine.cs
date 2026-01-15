using QrCodeGeneratorProject.Core.Interfaces;
using QrCodeGeneratorProject.Factory;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.IO.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;

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


        WiFiQrCodeMetadata metadata2 = new
            (
                ssid: "Figma",
                password: "asdadsda",
                FormatTypes.Png,
                AuthenticationTypes.Wep
            );
        
        QrCodeFactory acr = new QrCodeFactory();

        QrCodeResult res = acr.GenerateQrCode(metadata);

        this._writer.WriteBytes(res.ByteData, $"../../../Figma.{res.Format.ToString().ToLower()}");

    }
}