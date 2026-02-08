using QrCodeGeneratorProject.DTO.Interfaces;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;
using QrCodeGeneratorProject.Renderers.Interfaces;
using QrCodeGeneratorProject.Renderers.Models;
using QrCodeGeneratorProject.Utilities;
using QRCoder;

namespace QrCodeGeneratorProject.Factory;

///<summary>
/// A class that generates QR codes based on the provided metadata.
///</summary>
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
    
    ///<summary>
    ///Generates QR code based on the provided metadata.
    ///</summary>
    public QrCodeResult GenerateQrCode(IQrCodeMetadata metadata)
    {
        switch (metadata)
        {
            case WiFiQrCodeMetadata wifi:
                var wifiGenerator = this._generatorFactory.GetGenerator<WiFiQrCodeMetadata>();
                
                QRCodeData generatedWifi = wifiGenerator.GenerateQrCode(wifi);
                
                if (this._byteRenderers.ContainsKey(wifi.Format))
                {
                    IBinaryRenderer wifiRenderer = this._byteRenderers[wifi.Format];
                    byte[] rendered = wifiRenderer.Render(generatedWifi);

                    return new WiFiQrCodeResult(rendered, wifi.Format);
                }
                if (this._textRenderers.ContainsKey(wifi.Format))
                {
                    ITextRenderer wifiRenderer = this._textRenderers[wifi.Format];
                    string rendered = wifiRenderer.Render(generatedWifi);
                    
                    return new WiFiQrCodeResult(rendered, wifi.Format);
                }
                break;
            
            case UrlQrCodeMetadata url:
                var urlGenerator = this._generatorFactory.GetGenerator<UrlQrCodeMetadata>();
                QRCodeData generatedUrl = urlGenerator.GenerateQrCode(url);

                if (this._byteRenderers.ContainsKey(url.Format))
                {
                    IBinaryRenderer urlRenderer = this._byteRenderers[url.Format];
                    byte[] renderedUrl = urlRenderer.Render(generatedUrl);
                    
                    return new UrlQrCodeResult(renderedUrl, url.Format);
                }

                if (this._textRenderers.ContainsKey(url.Format))
                {
                    ITextRenderer urlRenderer = this._textRenderers[url.Format];
                    string renderedUrl = urlRenderer.Render(generatedUrl);
                    
                    return new UrlQrCodeResult(renderedUrl, url.Format);
                }

                break;
        }
        throw new NotSupportedException(ExceptionMessages.UnsupportedMetadataType);
    }
}
