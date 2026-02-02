using QrCodeGeneratorProject.DTO.Interfaces;
using QrCodeGeneratorProject.QrCodeGeneration.Interfaces;

namespace QrCodeGeneratorProject.Factory.Interfaces;

public interface IGeneratorFactory
{
    IQrCodeGenerator<T> GetGenerator<T>() where T : IQrCodeMetadata;
}