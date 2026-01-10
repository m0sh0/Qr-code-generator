using QrCodeGeneratorProject.Renderers.Interfaces;
using QRCoder;
using Aspose.Words;

namespace QrCodeGeneratorProject.Renderers.Models;

public class JpegRenderer : IBinaryRenderer
{
    public byte[] Render(QRCodeData qrCodeData)
    {
        using BitmapByteQRCode bitmapRenderer = new(qrCodeData); 
        byte[] bitmap = bitmapRenderer.GetGraphic(20);
        
        using MemoryStream stream = new(bitmap);
        return stream.ToArray();
    }
}