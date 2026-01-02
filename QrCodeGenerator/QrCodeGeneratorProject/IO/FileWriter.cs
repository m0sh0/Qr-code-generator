using QrCodeGeneratorProject.IO.Interfaces;

namespace QrCodeGeneratorProject.IO;

public class FileWriter : IWriter
{
    public void WriteBytes(byte[] data, string fileName) => File.WriteAllBytes(fileName, data);
    public void WriteString(string data, string fileName) => File.WriteAllText(fileName, data);
}