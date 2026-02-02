using QRCoder;
using Aspose.Words;
using QrCodeGeneratorProject.Core;
using QrCodeGeneratorProject.Core.Interfaces;
using QrCodeGeneratorProject.Factory;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.IO;
using QrCodeGeneratorProject.IO.Interfaces;

namespace QrCodeGeneratorProject;


class Program
{
    static void Main()
    {
        IWriter writer = new FileWriter();
        IQrCodeFactory factory = new QrCodeFactory();
        
        IEngine engine = new Engine(writer,factory);
        engine.Run();
        
    }
}