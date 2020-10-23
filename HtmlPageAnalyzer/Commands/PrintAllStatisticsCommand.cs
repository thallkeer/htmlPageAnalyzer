using HtmlPageAnalyzer.Core;
using HtmlPageAnalyzer.Core.DataInterfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlPageAnalyzer.Commands
{
    /// <summary>
    /// The command that displays all the previous recorded results of the analysis of the html page
    /// </summary>
    internal class PrintAllStatisticsCommand : ICommand
    {
        private readonly ITextAnalysisDao _dao;

        public PrintAllStatisticsCommand(ITextAnalysisDao dao)
        {
            this._dao = dao ?? throw new ArgumentException("Dao is null!");
        }

        public async Task Execute()
        {
            var stats = await _dao.GetAnalysisStatsAsync();
            if (stats == null || !stats.Any())
                Console.WriteLine("There are no any recorded analysis!");
            string bevel = new string('-', 20);
            stats.ForEach(record =>
            {
                Console.WriteLine($@"{record.Date}   {record.Url}");
                Console.WriteLine($@"{record.Statistics}");
                Console.WriteLine(bevel);
            });
        }
    }
}
