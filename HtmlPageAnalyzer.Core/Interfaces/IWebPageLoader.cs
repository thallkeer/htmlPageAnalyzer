using System.Threading.Tasks;

namespace HtmlPageAnalyzer.Core
{
    /// <summary>
    /// Interface for classes that can download web pages by given url
    /// </summary>
    public interface IWebPageLoader
    {
        /// <summary>
        /// Loads the page at the given url and saves it to a file. 
        /// Returns the path to the created file.
        /// </summary>
        /// <param name="url">Web page url</param>
        /// <returns>The path to the created file</returns>
        Task<string> DownloadPageAsync(string url);
    }
}