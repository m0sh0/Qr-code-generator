using System;
using System.IO;
using System.Linq;
using QrCodeGeneratorProject.Utilites;

namespace QrCodeGeneratorProject.DTO;

public class QrCodeResult
{
    private const string DefaultFileName = "QrCode";
    private string? _suggestedFileName;
    
    public QrCodeResult(byte[] data, FormatTypes format)
    {
        this.Data = data;
        this.Format = format;
        this._suggestedFileName = $"{DefaultFileName}.{format.ToString().ToLower()}";
    }

    public QrCodeResult(byte[] data, FormatTypes format, string suggestedFileName)
        : this(data, format)
    {
        this.SuggestedFileName = suggestedFileName;  
    }
    
    
    public byte[] Data { get; private set; }
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