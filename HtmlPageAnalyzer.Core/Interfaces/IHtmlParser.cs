namespace HtmlPageAnalyzer.Core
{
    /// <summary>
    /// Interface for classes that can extract viewable text from html page
    /// </summary>
    public interface IHtmlParser
    {
        /// <summary>
        /// Extracts viewable text from html file of given path
        /// </summary>
        /// <param name="filePath">Path to html file</param>
        /// <returns>Lis</returns>
        string ParseHtmlFile(string filePath);
    }
}