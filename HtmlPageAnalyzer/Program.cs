using System.Threading.Tasks;

namespace HtmlPageAnalyzer
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var program = new HtmlPageAnalyzerUI();
            await program.Run();
        }
    }
}
