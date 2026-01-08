using QrCodeGeneratorProject.Renderers.Interfaces;
using QRCoder;
using Aspose.Words;
using Aspose.Words.Drawing;

namespace QrCodeGeneratorProject.Renderers.Models;

//<summary>
// A class that renders QR codes as PDF documents.
//</summary>
public class PdfRenderer : IRenderer<byte[]>
{
    private readonly IRenderer<byte[]> _pngRenderer = new PngRenderer();
    
    public byte[] Render(QRCodeData qrCodeData)
    {
        // Generating png image bytes
        byte[] data = this._pngRenderer.Render(qrCodeData);

        // Create blank Aspose.Words Document
        Document doc = new();
        DocumentBuilder builder = new(doc);

        // Insert image into Aspose.Words document
        using (MemoryStream stream = new(data))
        {
            Shape shape = builder.InsertImage(stream);
            shape.WrapType = WrapType.None;
        }
        
        // Save the document as PDF
        using MemoryStream pdfStream = new();
        doc.Save(pdfStream, SaveFormat.Pdf);
        
        return pdfStream.ToArray();
    }
}