using QRCoder;
using System;
using System.Drawing;
using System.IO;
using QrCodeGeneratorProject.Core;
using QrCodeGeneratorProject.Core.Interfaces;
using QrCodeGeneratorProject.DTO;
using QrCodeGeneratorProject.Factory;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.IO;
using QrCodeGeneratorProject.IO.Interfaces;

namespace QrCodeGeneratorProject;


class Program
{
    static void Main(string[] args)
    {
        IWriter writer = new FileWriter();
        IQrCodeFactory factory = new QrCodeFactory();
        
        IEngine engine = new Engine(writer,factory);
        engine.Run();
    }
}