namespace QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;

/// <summary>
/// A class that holds the result of a Wi-Fi QR code generation operation.
/// </summary>
public class WiFiQrCodeResult : QrCodeResult
{
    public WiFiQrCodeResult(byte[] byteData, FormatTypes format)
        : base(byteData, format) { }

    public WiFiQrCodeResult(string stringData, FormatTypes format)
        : base(stringData, format) { }
}