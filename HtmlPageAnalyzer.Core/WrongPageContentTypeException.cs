using System;

namespace HtmlPageAnalyzer
{
    /// <summary>
    /// Represents error that occur when the content type of a web page does not match the required 
    /// </summary>
    public class WrongPageContentTypeException : Exception
    {
        public WrongPageContentTypeException(string message) : base(message)
        {
        }
    }
}
