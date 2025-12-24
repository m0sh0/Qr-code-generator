using QRCoder;

namespace QrCodeGeneratorProject.Renderers.Interfaces;

public interface IRenderer
{
    public byte[] Render(QRCodeData qrCodeData);
}