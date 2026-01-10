using QrCodeGeneratorProject.Renderers.Interfaces;
using QRCoder;

namespace QrCodeGeneratorProject.Renderers.Models;

//<summary>
// A class that renders QR codes as PNG images.
//</summary>
public class PngRenderer : IBinaryRenderer
{
    //<summary>
    //Renders QR code as a PNG image.
    //</summary>
    public object Render(QRCodeData qrCodeData)
    {
        using PngByteQRCode pngRenderer = new(qrCodeData);
        byte[] qrCodeImage = pngRenderer.GetGraphic(20);
        
        return qrCodeImage;
    }
    
}