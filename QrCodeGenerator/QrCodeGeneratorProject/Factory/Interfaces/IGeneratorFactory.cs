using QrCodeGeneratorProject.DTO.Interfaces;

namespace QrCodeGeneratorProject.Factory.Interfaces;

public interface IGeneratorFactory
{
    IQrCodeGenerator<T> GetGenerator<T>() where T : IQrCodeMetadata;
}