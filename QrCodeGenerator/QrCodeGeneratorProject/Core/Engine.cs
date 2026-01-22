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

    public void Run()
    {
        WiFiQrCodeMetadata metadata = new
        (
            "Ohana",
            "Ohana_123",
            FormatTypes.Pdf,
            AuthenticationTypes.Wpa2
        );

        UrlQrCodeMetadata metadat2 = new
        (
            "https://www.google.com",
            FormatTypes.Png,
            QRCodeGenerator.ECCLevel.Q
        );

        QrCodeResult result = this._factory.GenerateQrCode(metadat2);

        this._writer.WriteBytes(result.ByteData, $"../../../Google.{metadat2.Format.ToString().ToLowerInvariant()}");
    }
}