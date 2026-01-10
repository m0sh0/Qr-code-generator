using QrCodeGeneratorProject.DTO.Interfaces;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration;
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
    private readonly IQrCodeGenerator _urlQrCodeGenerator = new UrlQrCodeGenerator();
    //private readonly Dictionary<FormatTypes, IRenderer<>> _renderers = new()
    //<summary>
    //Generates QR code based on the provided metadata.
    //</summary>
    public UrlQrCodeResult GenerateQrCode(UrlQrCodeMetadata metadata)
    {
        switch (metadata.Format)
        {
            case FormatTypes.Png:
            case FormatTypes.Jpeg:    
                
                IBinaryRenderer pngRenderer = new PngRenderer();
                QRCodeData qrCodeData = this._urlQrCodeGenerator.GenerateQrCode(metadata);
                byte[] pngCodeImage = pngRenderer.Render(qrCodeData) as byte[];
                
                return new UrlQrCodeResult(pngCodeImage, metadata.Format);
            
            case FormatTypes.Svg:
                
                ITextRenderer svgRenderer = new SvgRenderer();
                QRCodeData svgQrCodeData = this._urlQrCodeGenerator.GenerateQrCode(metadata);
                string svgCodeImage = svgRenderer.Render(svgQrCodeData) as string;
                
                return new UrlQrCodeResult(svgCodeImage, metadata.Format);
            
            case FormatTypes.Pdf:
                
                IBinaryRenderer pdfRenderer = new PdfRenderer();
                QRCodeData pdfQrCodeData = this._urlQrCodeGenerator.GenerateQrCode(metadata);
                byte[] pdfCodeImage = pdfRenderer.Render(pdfQrCodeData) as byte[];
                
                return new UrlQrCodeResult(pdfCodeImage, metadata.Format);
            
            default:
                throw new NotSupportedException(ExceptionMessages.QrCodeFormatNotSupported);
        }
    }
}