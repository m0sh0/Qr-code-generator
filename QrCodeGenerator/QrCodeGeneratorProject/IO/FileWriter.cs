using QrCodeGeneratorProject.IO.Interfaces;

namespace QrCodeGeneratorProject.IO;

public class FileWriter : IWriter
{
    public void Write(byte[] data, string fileName) => File.WriteAllBytes(fileName, data);
}