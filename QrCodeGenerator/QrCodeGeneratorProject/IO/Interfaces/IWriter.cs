namespace QrCodeGeneratorProject.IO.Interfaces;

public interface IWriter
{
    public void Write(byte[] data, string fileName);
}