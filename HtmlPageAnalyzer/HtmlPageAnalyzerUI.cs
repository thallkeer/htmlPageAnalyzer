using HtmlPageAnalyzer.Commands;
using NLog;
using System;
using System.Threading.Tasks;

namespace HtmlPageAnalyzer
{
    public class HtmlPageAnalyzerUI
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public async Task Run()
        {            
            ICommand command;
            while (true)
            {
                var menu = new Menu();
                menu.PrintMenu();
                command = menu.GetNextCommand();
                try
                {
                    await command.Execute();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}
