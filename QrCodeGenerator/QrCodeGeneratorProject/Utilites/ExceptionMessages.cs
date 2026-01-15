namespace QrCodeGeneratorProject.Utilites;

public class ExceptionMessages
{
    public const string TextIsNullOrEmpty = "Text is null or empty.";
    public const string FileNameNullOrEmpty = "Filename is  null or empty.";
    public const string InvalidCharacterInFilename = "Invalid character in filename.";
    public const string QrCodeFormatNotSupported = "QrCode format is not supported.";
    public const string DataNullOrEmpty = "Data is empty.";
    public const string InvalidQrCodeType = "Invalid QRCode type.";
    public const string InvalidEccLevel = "Invalid ECC level.";
    public const string InvalidFormat = "Invalid format.";
    public const string InvalidAuthentication = "Invalid authentication.";
    public const string SsidIsNullOrEmpty = "SSID is null or empty.";
    public const string PasswordNullOrEmpty = "Password is null or empty.";
    public const string NoGeneratorFound = "No generator registered for type {0}";
    public const string UnsupportedMetadataType = "Unsupported metadata type.";
}