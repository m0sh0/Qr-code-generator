using QrCodeGeneratorProject.Renderers.Interfaces;
using QRCoder;

namespace QrCodeGeneratorProject.Renderers.Models;

public class SvgRenderer : IRenderer
{
    public byte[] Render(QRCodeData qrCodeData)
    {
        // using SvgQRCode svgRenderer = new(qrCodeData);
        // string[] qrCodeImage = svgRenderer.GetGraphic(20);
        // return qrCodeImage;
        throw new NotImplementedException();
    }
}