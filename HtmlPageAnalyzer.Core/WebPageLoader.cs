using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace HtmlPageAnalyzer.Core
{
    /// <summary>
    /// Downloads and save the web page
    /// </summary>
    public class WebPageLoader : IWebPageLoader
    {
        /// <summary>
        /// Loads the page at the given url and saves it to a file. 
        /// Returns the path to the created file.
        /// </summary>
        /// <param name="url">Web page url</param>
        /// <returns>The path to the created file</returns>
        public async Task<string> DownloadPageAsync(string url)
        {
            if (!ValidateUrl(url))
                throw new ArgumentException("Given url is not valid!");
            string fileName = @$"page-{Guid.NewGuid()}.html";
            var request = WebRequest.Create(url);
            var response = await request?.GetResponseAsync();
            string contentType = response?.ContentType;
            if (string.IsNullOrEmpty(contentType) || !contentType.Contains("text/html"))
                throw new WrongPageContentTypeException("The content of the provided url must be an html page!");
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                File.AppendAllText(fileName, reader.ReadToEnd());
            }            
            return fileName;
        }

        private bool ValidateUrl(string input) => Uri.TryCreate(input, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttps;
    }
}
