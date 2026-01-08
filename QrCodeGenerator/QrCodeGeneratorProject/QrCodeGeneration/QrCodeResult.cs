using QrCodeGeneratorProject.Utilites;

namespace QrCodeGeneratorProject.QrCodeGeneration;

//<summary>
// A class that holds the result of a QR code generation operation.
//</summary>
public class QrCodeResult
{
    private const string DefaultFileName = "QrCode";
    private string? _suggestedFileName;
    private byte[] _byteData;
    private string _stringData;

    public QrCodeResult(byte[] byteData, FormatTypes format)
    {
        this.ByteData = byteData;
        this.Format = format;
        this.SuggestedFileName = $"{DefaultFileName}.{format.ToString().ToLower()}";
    }

    public QrCodeResult(byte[] byteData, FormatTypes format, string suggestedFileName)
        : this(byteData, format)
    {
        this.SuggestedFileName = suggestedFileName;  
    }

    public QrCodeResult(string stringData, FormatTypes format)
    {
        this.StringData = stringData;
        this.Format = format;
        this.SuggestedFileName = $"{DefaultFileName}.{format.ToString().ToLower()}";
    }

    public QrCodeResult(string stringData, FormatTypes format, string suggestedFileName)
        : this(stringData, format)
    {
        this.SuggestedFileName = suggestedFileName;  
    }
    
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

    public FormatTypes Format { get; }

    public string? SuggestedFileName
    {
        get => this._suggestedFileName;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(ExceptionMessages.FileNameNullOrEmpty);
            }

            if (!CheckValidFilename(value) || value.StartsWith('.'))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCharacterInFilename);
            }
            
            
            if (value.LastIndexOf('.') == -1)
            {
                this._suggestedFileName = $"{value}.{this.Format.ToString().ToLower()}";
            }
            else
            {
                string correctedFilename = value.Remove(value.LastIndexOf('.'));
                this._suggestedFileName = $"{correctedFilename}.{this.Format.ToString().ToLower()}";
            }
        }
    }

    
    private bool CheckValidFilename(string filename)
    {
        if (filename.Any(c => Path.GetInvalidFileNameChars().Contains(c)))
        {
            return false;
        }
        return true;
    }
}