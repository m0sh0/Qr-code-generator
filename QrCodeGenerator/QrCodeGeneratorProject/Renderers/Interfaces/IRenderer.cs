using QRCoder;

namespace QrCodeGeneratorProject.Renderers.Interfaces;

public interface IRenderer
{
    public object Render(QRCodeData qrCodeData);
}