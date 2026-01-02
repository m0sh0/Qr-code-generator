using System;
using QrCodeGeneratorProject.Utilites;
using QRCoder;

namespace QrCodeGeneratorProject.DTO;

public class QrCodeMetadata
{
    
    private string _text;

    public QrCodeMetadata(string text, QrCodeTypes type, FormatTypes format, QRCodeGenerator.ECCLevel eccLevel)
    {
        this.Text = text;
        this.Type = type;
        this.Format = format;
        this.EccLevel = eccLevel;
    }
    
    public QrCodeTypes Type { get; private set; }
    public FormatTypes Format { get; private set; }
    public string Text
    {
        get => this._text;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(ExceptionMessages.TextIsNullOrEmpty);
            }
            this._text = value;
        }
    }
    public QRCodeGenerator.ECCLevel EccLevel { get; private set; }
}




