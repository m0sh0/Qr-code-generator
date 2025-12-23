using QRCoder;
using System;
using System.Drawing;
using System.IO;
using QrCodeGeneratorProject.DTO;

namespace QrCodeGeneratorProject;


class Program
{
    static void Main(string[] args)
    {
        using QRCodeGenerator qrGenerator = new();
        using QRCodeData qrCodeData = qrGenerator
            .CreateQrCode("https://ucha.se/abonament?gad_source=1&gad_campaignid=20630923570&gbraid=0AAAAADxKgSXclc33BdIgKbiaPWdG3_qg2&gclid=Cj0KCQiAo4TKBhDRARIsAGW29bdS56hNfextWrb7QRHMg3IlShr5nod7LO0ZCqOxVDqQZXk-84UrFCsaAs8IEALw_wcB", QRCodeGenerator.ECCLevel.Q);
        
        BitmapByteQRCode qrCode = new(qrCodeData);
        byte[] qrCodeImage = qrCode.GetGraphic(20);
        
        File.WriteAllBytes("../../../Image.png", qrCodeImage);
        
        QrCodeMetadata metadata = new("ajsdas", QrCodeTypes.Url, FormatTypes.Png, QRCodeGenerator.ECCLevel.H);

        QrCodeResult q = new(new byte[] {1,2,3}, FormatTypes.Pdf);
        ;
    }
}