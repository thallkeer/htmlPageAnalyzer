using HtmlPageAnalyzer.Core;
using HtmlPageAnalyzer.Core.DataInterfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlPageAnalyzer.Commands
{
    /// <summary>
    /// The command that parses the text of the html page
    /// </summary>
    internal class AnalyzePageCommand : ICommand
    {
        private readonly WebPageLoader _webPageLoader;
        private readonly HtmlParser _htmlParser;
        private readonly ITextAnalysisDao _dao;

        public AnalyzePageCommand(WebPageLoader webPageLoader, HtmlParser htmlParser, ITextAnalysisDao dao)
        {
            this._webPageLoader = webPageLoader ?? throw new ArgumentException("Page loader is null!");
            this._htmlParser = htmlParser ?? throw new ArgumentException("Html parser is null!");
            this._dao = dao ?? throw new ArgumentException("Dao is null!");
        }

        public async Task Execute()
        {
            string inputUrl = string.Empty;
            string filePath = string.Empty;
            string text = string.Empty;

            Console.WriteLine("Please enter a web page url");
            inputUrl = Console.ReadLine();

            Console.WriteLine("Trying to load web page");
            filePath = await _webPageLoader.DownloadPageAsync(inputUrl);
            Console.WriteLine("Page was successfully loaded");

            Console.WriteLine("File parsing");
            text = _htmlParser.ParseHtmlFile(filePath);

            Console.WriteLine("Calculating statistics");
            var textAnalyzer = new TextAnalyzer(text);
            var wordStats = textAnalyzer.CountWordRepetitions();

            Console.WriteLine($"Statistics for URL: {inputUrl}");

            StringBuilder statInfo = new StringBuilder();
            wordStats.OrderByDescending(kvp => kvp.Value)
                .ForEach(kvp => statInfo.AppendLine($"{kvp.Key} - {kvp.Value}"));

            Console.WriteLine(statInfo);

            Console.WriteLine($"Saving statistics to database");
            await _dao.SaveAnalysisStatsAsync(new TextAnalysisRecord(DateTime.Now, inputUrl, statInfo.ToString()));            
        }
    }
}
