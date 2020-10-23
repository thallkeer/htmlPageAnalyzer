using System;
using System.Threading.Tasks;

namespace HtmlPageAnalyzer.Commands
{
    /// <summary>
    /// Application shutdown command
    /// </summary>
    internal class ExitCommand : ICommand
    {
        public Task Execute()
        {
            Environment.Exit(1);
            return Task.CompletedTask;
        }
    }
}
