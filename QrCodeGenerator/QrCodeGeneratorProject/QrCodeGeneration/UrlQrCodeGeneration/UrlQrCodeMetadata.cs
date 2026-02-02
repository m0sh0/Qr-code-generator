using QrCodeGeneratorProject.DTO.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration.Interfaces;
using QrCodeGeneratorProject.Utilites;
using QRCoder;

namespace QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;

//<summary>
// A class that holds metadata for URL QR codes.
//</summary>

public class UrlQrCodeMetadata : IQrCodeMetadata
{
    
    private string _text;
    private FormatTypes _format;
    private QRCodeGenerator.ECCLevel _eccLevel;

    public UrlQrCodeMetadata(string text, FormatTypes format, QRCodeGenerator.ECCLevel eccLevel)
    {
        this.Text = text;
        this.Format = format;
        this.EccLevel = eccLevel;
    }

    public FormatTypes Format
    {
        get => this._format;
        private set
        {
            if (value != FormatTypes.Png && value != FormatTypes.Svg
                && value != FormatTypes.Jpeg && value != FormatTypes.Pdf)
            {
                throw new ArgumentException(ExceptionMessages.InvalidFormat);
            }   
            this._format = value;
        }
    }

    public string Text
    {
        get => this._text;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
            {
                throw new ArgumentException(ExceptionMessages.TextIsNullOrEmpty);
            }
            this._text = value;
        }
    }

    public QRCodeGenerator.ECCLevel EccLevel
    {
        get => this._eccLevel;
        private set
        {
            if (value != QRCodeGenerator.ECCLevel.L && value != QRCodeGenerator.ECCLevel.M
                && value != QRCodeGenerator.ECCLevel.Q && value != QRCodeGenerator.ECCLevel.H)
            {
                throw new ArgumentException(ExceptionMessages.InvalidEccLevel);
            }
            this._eccLevel = value;
        }
    }
}




