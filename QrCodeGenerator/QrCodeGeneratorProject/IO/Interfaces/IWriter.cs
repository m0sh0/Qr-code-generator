namespace QrCodeGeneratorProject.IO.Interfaces;

public interface IWriter
{
    public void WriteBytes(byte[] data, string fileName);
    public void WriteString(string data, string fileName);
}