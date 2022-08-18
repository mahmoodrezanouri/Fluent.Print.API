
namespace Fluent.Print.API
{
    public interface IPrintCommand
    {
        void Print(IFluentPrintDocumentBuilder document);
    }
}
