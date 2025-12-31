using QRCoder;

namespace QrCodeGeneratorProject.Renderers.Interfaces;

public interface IRenderer<TOutput>
{
    public TOutput Render(QRCodeData qrCodeData);
}