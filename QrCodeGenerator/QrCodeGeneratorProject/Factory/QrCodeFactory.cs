using QrCodeGeneratorProject.DTO;
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
    
    //<summary>
    //Generates QR code based on the provided metadata.
    //</summary>
    public QrCodeResult GenerateQrCode(QrCodeMetadata metadata)
    {
        switch (metadata.Format)
        {
            case FormatTypes.Png:
                
                IRenderer<byte[]> pngRenderer = new PngRenderer();
                QRCodeData pngQrCodeData = this._urlQrCodeGenerator.GenerateQrCode(metadata);
                byte[] qrCodeImage = pngRenderer.Render(pngQrCodeData);
                
                return new QrCodeResult(qrCodeImage, metadata.Format);
            
            case FormatTypes.Svg:
                
                IRenderer<string> svgRenderer = new SvgRenderer();
                QRCodeData svgQrCodeData = this._urlQrCodeGenerator.GenerateQrCode(metadata);
                string svgCodeImage = svgRenderer.Render(svgQrCodeData);
                
                return new QrCodeResult(svgCodeImage, metadata.Format);
            
            case FormatTypes.Pdf:
                
                IRenderer<byte[]> pdfRenderer = new PdfRenderer();
                QRCodeData pdfQrCodeData = this._urlQrCodeGenerator.GenerateQrCode(metadata);
                byte[] pdfCodeImage = pdfRenderer.Render(pdfQrCodeData);
                
                return new QrCodeResult(pdfCodeImage, metadata.Format);
            
            default:
                throw new NotSupportedException(ExceptionMessages.QrCodeFormatNotSupported);
        }
    }
}