namespace text_parser.Service.Contracts
{
    public interface ITextWriter
    {
        void WriteText(IText text, string fileName);
    }
}
