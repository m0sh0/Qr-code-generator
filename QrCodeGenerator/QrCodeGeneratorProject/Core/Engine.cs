using QrCodeGeneratorProject.Core.Interfaces;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.IO.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
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
            text: "https://www.youtube.com/watch?v=soDuIX_jBWw",
            type: QrCodeTypes.Url,
            FormatTypes.Png,
            QRCodeGenerator.ECCLevel.Q
        );
        
        UrlQrCodeResult result = this._factory.GenerateQrCode(metadata);
        
        this._writer.WriteBytes(result.ByteData, "../../../youtube.png");
        
    }
}