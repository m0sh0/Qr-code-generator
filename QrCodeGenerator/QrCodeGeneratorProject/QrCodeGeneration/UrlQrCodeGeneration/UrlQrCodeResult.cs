namespace QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;

///<summary>
/// A class that holds the result of a URL QR code generation operation.
///</summary>
public class UrlQrCodeResult : QrCodeResult
{
    
    public UrlQrCodeResult(byte[] byteData, FormatTypes format) 
        : base(byteData, format) { }

    public UrlQrCodeResult(string stringData, FormatTypes format)
        : base(stringData, format) { }
}