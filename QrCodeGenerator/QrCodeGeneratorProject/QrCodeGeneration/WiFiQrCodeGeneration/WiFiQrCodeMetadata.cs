using QrCodeGeneratorProject.DTO.Interfaces;
using QrCodeGeneratorProject.Utilites;

namespace QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;

public class WiFiQrCodeMetadata : IQrCodeMetadata
{
    private string _ssid;
    private string _password;
    private FormatTypes _format;
    private AuthenticationTypes _authentication;

    public WiFiQrCodeMetadata(string ssid, string password, FormatTypes format, AuthenticationTypes authentication)
    {
        this.Ssid = ssid;
        this.Password = password;
        this.Format = format;
        this.Authentication = authentication;
    }

    public string Ssid
    {
        get => this._ssid;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
            {
                throw new ArgumentException(ExceptionMessages.SsidIsNullOrEmpty);
            }
            this._ssid = value;
        }
    }
    
    public string Password
    {
        get => this._password;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
            {
                throw new ArgumentException(ExceptionMessages.PasswordNullOrEmpty);
            }
            this._password = value;
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

    public AuthenticationTypes Authentication
    {
        get => this._authentication;
        private set
        {
            if (value != AuthenticationTypes.Wep &&
                value != AuthenticationTypes.Wpa &&
                value != AuthenticationTypes.Wpa2)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAuthentication);
            }
            this._authentication = value;
        }
    }
    
}

public enum AuthenticationTypes
{
    Wep,
    Wpa,
    Wpa2
}