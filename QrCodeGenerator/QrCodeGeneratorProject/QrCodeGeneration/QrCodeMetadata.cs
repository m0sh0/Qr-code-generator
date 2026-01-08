using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.Utilites;
using QRCoder;

namespace QrCodeGeneratorProject.QrCodeGeneration;

//<summary>
// A class that holds metadata for QR codes.
//</summary>

public class QrCodeMetadata
{
    
    private string _text;
    private QrCodeTypes _type;
    private FormatTypes _format;
    private QRCodeGenerator.ECCLevel _eccLevel;

    public QrCodeMetadata(string text, QrCodeTypes type, FormatTypes format, QRCodeGenerator.ECCLevel eccLevel)
    {
        this.Text = text;
        this.Type = type;
        this.Format = format;
        this.EccLevel = eccLevel;
    }

    public QrCodeTypes Type
    {
        get => this._type;
        private set
        {
            if (value != QrCodeTypes.Url && value != QrCodeTypes.Wifi)
            {
                throw new ArgumentException(ExceptionMessages.InvalidQrCodeType);
            }
            this._type = value;
        }
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
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
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




