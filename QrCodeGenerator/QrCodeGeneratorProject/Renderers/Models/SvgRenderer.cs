using QrCodeGeneratorProject.Renderers.Interfaces;
using QRCoder;

namespace QrCodeGeneratorProject.Renderers.Models;
///<summary>
/// A class that renders QR codes as SVG images.
///</summary>
public class SvgRenderer : ITextRenderer
{
    ///<summary>
    ///Renders QR code as an SVG image.
    ///</summary>
    public string Render(QRCodeData qrCodeData)
    {
        SvgQRCode qrCode = new(qrCodeData);
        string qrCodeImage = qrCode.GetGraphic(20);
        return qrCodeImage;
    }
}