using QrCodeGeneratorProject.DTO.Interfaces;
using QrCodeGeneratorProject.Factory.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration.UrlQrCodeGeneration;
using QrCodeGeneratorProject.QrCodeGeneration.WiFiQrCodeGeneration;
using QrCodeGeneratorProject.Utilities;

namespace QrCodeGeneratorProject.Factory;

public class GeneratorFactory : IGeneratorFactory
{

    private readonly Dictionary<Type, object> _generators = new()
    {
        {typeof(UrlQrCodeMetadata), new UrlQrCodeGenerator()},
        {typeof(WiFiQrCodeMetadata), new WiFiQrCodeGenerator()}
    };
    
    public IQrCodeGenerator<TMetadata> GetGenerator<TMetadata>() where TMetadata : IQrCodeMetadata
    {
        if (this._generators.TryGetValue(typeof(TMetadata), out var generator))
        {
            return generator as IQrCodeGenerator<TMetadata>;
        }

        throw new ArgumentException(string.Format(ExceptionMessages.NoGeneratorFound, typeof(TMetadata).Name));
    }
}