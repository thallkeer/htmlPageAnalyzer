using System.Threading.Tasks;

namespace HtmlPageAnalyzer.Commands
{
    /// <summary>
    /// Interface for user commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes command
        /// </summary>
        Task Execute();
    }
}
