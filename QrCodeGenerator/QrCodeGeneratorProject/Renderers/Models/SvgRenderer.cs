using QrCodeGeneratorProject.Renderers.Interfaces;
using QRCoder;

namespace QrCodeGeneratorProject.Renderers.Models;

public class SvgRenderer : IRenderer<string>
{
    public string Render(QRCodeData qrCodeData)
    {
        SvgQRCode qrCode = new(qrCodeData);
        string qrCodeImage = qrCode.GetGraphic(20);
        return qrCodeImage;
    }
}