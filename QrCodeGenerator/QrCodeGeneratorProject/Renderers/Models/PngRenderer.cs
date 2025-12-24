using QrCodeGeneratorProject.Renderers.Interfaces;
using QRCoder;

namespace QrCodeGeneratorProject.Renderers.Models;

public class PngRenderer : IRenderer
{
    public byte[] Render(QRCodeData qrCodeData)
    {
        using PngByteQRCode pngRenderer = new PngByteQRCode(qrCodeData);
        byte[] qrCodeImage = pngRenderer.GetGraphic(20);
        
        return qrCodeImage;
    }
    
}