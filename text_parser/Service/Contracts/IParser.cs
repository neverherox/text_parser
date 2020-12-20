using System.IO;
namespace text_parser.Service.Contracts
{
    public interface IParser
    {
        IText Parse(TextReader reader);
    }
}
