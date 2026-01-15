using QrCodeGeneratorProject.Utilites;

namespace QrCodeGeneratorProject.QrCodeGeneration;

public abstract class QrCodeResult
{
    private byte[] _byteData;
    private string _stringData;
    
    protected QrCodeResult(byte[] byteData, FormatTypes format)
    {
        this.ByteData = byteData;
        this.Format = format;
    }
    
    protected QrCodeResult(string stringData, FormatTypes format)
    {
        this.StringData = stringData;
        this.Format = format;
    }
    
    public FormatTypes Format { get; }
    
    
    public byte[] ByteData
    {
        get => this._byteData;
        private set
        {
            if (value.Length == 0)
            {
                throw new ArgumentException(ExceptionMessages.DataNullOrEmpty);
            }
            this._byteData = value;
        }
    }

    public string StringData
    {
        get => this._stringData;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(ExceptionMessages.DataNullOrEmpty);
            }
            this._stringData = value;
        }
    }
}