using QrCodeGeneratorProject.DTO.Interfaces;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;
using QrCodeGeneratorProject.Renderers.Interfaces;
using QrCodeGeneratorProject.Renderers.Models;
using QrCodeGeneratorProject.Utilites;
using QRCoder;

namespace QrCodeGeneratorProject.Factory;

//<summary>
// A class that generates QR codes based on the provided metadata.
//</summary>
public class QrCodeFactory : IQrCodeFactory
{
    private readonly IQrCodeGenerator<UrlQrCodeMetadata> _urlQrCodeGenerator = new UrlQrCodeGenerator();
    private readonly IQrCodeGenerator<WiFiQrCodeMetadata> _wiFiQrCodeGenerator = new WiFiQrCodeGenerator();
    private readonly IGeneratorFactory _generatorFactory = new GeneratorFactory();
    
    private readonly Dictionary<FormatTypes, IBinaryRenderer> _byteRenderers = new()
    {
        { FormatTypes.Jpeg, new JpegRenderer() },
        { FormatTypes.Png, new PngRenderer() },
        { FormatTypes.Pdf, new PdfRenderer() }
    };
    private readonly Dictionary<FormatTypes, ITextRenderer> _textRenderers = new()
    {
        { FormatTypes.Svg, new SvgRenderer() }
    };
    
    //<summary>
    //Generates QR code based on the provided metadata.
    //</summary>
    public QrCodeResult GenerateQrCode(IQrCodeMetadata metadata)
    {
        switch (metadata)
        {
            case WiFiQrCodeMetadata wifi:
                var wifiGenerator = this._generatorFactory.GetGenerator<WiFiQrCodeMetadata>();
                
                QRCodeData generatedWifi = wifiGenerator.GenerateQrCode(wifi);
                IBinaryRenderer wifiRenderer = this._byteRenderers[wifi.Format];
                byte[] rendered = wifiRenderer.Render(generatedWifi);
                
                return new WiFiQrCodeResult(rendered, wifi.Format);
            
            case UrlQrCodeMetadata url:
                var urlGenerator = this._generatorFactory.GetGenerator<UrlQrCodeMetadata>();

                QRCodeData generatedUrl = urlGenerator.GenerateQrCode(url);
                IBinaryRenderer urlRenderer = this._byteRenderers[url.Format];
                byte[] renderedUrl = urlRenderer.Render(generatedUrl);
                
                return new UrlQrCodeResult(renderedUrl, url.Format);
            
            default:
                return null;
        }
    }
    
// Just in case if anything goes wrong
    // public UrlQrCodeResult GenerateQrCode(UrlQrCodeMetadata metadata)
    // {
    //
    //     switch (metadata.Format)
    //     {
    //         case FormatTypes.Png:
    //         case FormatTypes.Jpeg:
    //         case FormatTypes.Pdf:
    //
    //             IBinaryRenderer pngRenderer = this._byteRenderers[metadata.Format];
    //             QRCodeData qrCodeData = this._urlQrCodeGenerator.GenerateQrCode(metadata);
    //             byte[] pngCodeImage = pngRenderer.Render(qrCodeData);
    //
    //             return new UrlQrCodeResult(pngCodeImage, metadata.Format);
    //
    //         case FormatTypes.Svg:
    //
    //             ITextRenderer svgRenderer = this._textRenderers[metadata.Format];
    //             QRCodeData svgQrCodeData = this._urlQrCodeGenerator.GenerateQrCode(metadata);
    //             string svgCodeImage = svgRenderer.Render(svgQrCodeData);
    //
    //             return new UrlQrCodeResult(svgCodeImage, metadata.Format);
    //
    //         default:
    //             throw new NotSupportedException(ExceptionMessages.QrCodeFormatNotSupported);
    //     }
    // }

}
