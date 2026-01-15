using QrCodeGeneratorProject.Utilites;

namespace QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;

public class WiFiQrCodeResult : QrCodeResult
{
    public WiFiQrCodeResult(byte[] byteData, FormatTypes format)
        : base(byteData, format) { }

    public WiFiQrCodeResult(string stringData, FormatTypes format)
        : base(stringData, format) { }
}