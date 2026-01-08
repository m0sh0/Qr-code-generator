using QrCodeGeneratorProject.IO.Interfaces;

namespace QrCodeGeneratorProject.IO;

//<summary>
// A class that writes data to files.
//</summary>
public class FileWriter : IWriter
{
    //<summary>
    //Writes byte data to a file with the specified name.
    //</summary>
    public void WriteBytes(byte[] data, string fileName) => File.WriteAllBytes(fileName, data);
    
    //<summary>
    //Writes string data to a file with the specified name.
    //</summary>
    public void WriteString(string data, string fileName) => File.WriteAllText(fileName, data);
}