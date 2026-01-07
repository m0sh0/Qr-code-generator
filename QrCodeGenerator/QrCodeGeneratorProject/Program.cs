using QRCoder;
using Aspose.Words;

namespace QrCodeGeneratorProject;


class Program
{
    static void Main()
    {
        // IWriter writer = new FileWriter();
        // IQrCodeFactory factory = new QrCodeFactory();
        //
        // IEngine engine = new Engine(writer,factory);
        // engine.Run();
        
        Document doc =  new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);
        
        builder.InsertImage("../../../../Test.png");

    }
}