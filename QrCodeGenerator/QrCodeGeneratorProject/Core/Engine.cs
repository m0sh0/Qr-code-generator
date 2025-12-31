using QrCodeGeneratorProject.Core.Interfaces;
using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.Factory;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.IO;
using QrCodeGeneratorProject.IO.Interfaces;
using QrCodeGeneratorProject.Renderers.Interfaces;
using QRCoder;

namespace QrCodeGeneratorProject.Core;

public class Engine : IEngine
{
    private readonly IWriter _writer;
    private readonly IQrCodeFactory _factory;
    private readonly IRenderer _renderer;
    
    public Engine(IWriter writer, IQrCodeFactory factory)
    {
        this._writer = writer;
        this._factory = factory;
    }
    
    public void Run()
    {
        // using QRCodeGenerator qrGenerator = new();
        // using QRCodeData qrCodeData = qrGenerator
        //     .CreateQrCode("https://ucha.se/abonament?gad_source=1&gad_campaignid=20630923570&gbraid=0AAAAADxKgSXclc33BdIgKbiaPWdG3_qg2&gclid=Cj0KCQiAo4TKBhDRARIsAGW29bdS56hNfextWrb7QRHMg3IlShr5nod7LO0ZCqOxVDqQZXk-84UrFCsaAs8IEALw_wcB", QRCodeGenerator.ECCLevel.Q);
        //
        // BitmapByteQRCode qrCode = new(qrCodeData);
        // byte[] qrCodeImage = qrCode.GetGraphic(20);
        //
        // File.WriteAllBytes("../../../Image.png", qrCodeImage);
        //
        // QrCodeMetadata metadata = new("ajsdas", QrCodeTypes.Url, FormatTypes.Png, QRCodeGenerator.ECCLevel.H);
        //
        // QrCodeResult q = new(new byte[] {1,2,3}, FormatTypes.Pdf);
        
        //var bookmarkPayload = new PayloadGenerator.Url("https://github.com/Shane32/QRCoder");

        // // Generate the QR code data from the payload
        // using QRCodeData qrCodeData = QRCodeGenerator.GenerateQrCode(bookmarkPayload);
        //
        // // Or override the ECC level
        // using var qrCodeData2 = QRCodeGenerator.GenerateQrCode(bookmarkPayload, QRCodeGenerator.ECCLevel.H);
        //
        // // Render the QR code
        // using PngByteQRCode pngRenderer = new PngByteQRCode(qrCodeData);
        // byte[] qrCodeImage = pngRenderer.GetGraphic(20);
        //
        // File.WriteAllBytes("../../../Image.png", qrCodeImage);
        //
        // QrCodeMetadata metadata = 
        //     new("https://ontheline.trincoll.edu/images/bookdown/sample-local-pdf.pdf", QrCodeTypes.Url, FormatTypes.Pdf, QRCodeGenerator.ECCLevel.H);
        //
        // QrCodeResult result = this._factory.GenerateQrCode(metadata);
        //
        // this._writer.Write(result.Data, "../../../Image.pdf");
        
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
        SvgQRCode qrCode = new SvgQRCode(qrCodeData);
        string qrCodeAsSvg = qrCode.GetGraphic(20);
        
        File.WriteAllText("../../../Test.svg",qrCodeAsSvg);
        

    }
}