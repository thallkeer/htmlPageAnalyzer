using System;

namespace HtmlPageAnalyzer.Core
{
    /// <summary>
    /// Class is the result of analyzing one url
    /// </summary>
    public class TextAnalysisRecord
    {
        public int Id { get; set; }
        /// <summary>
        /// Analysis data
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Page url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Text analysis info
        /// </summary>
        public string Statistics { get; set; }

        public TextAnalysisRecord()
        {

        }

        public TextAnalysisRecord(DateTime date, string url, string statistics)
        {
            Date = date;
            Url = url;
            Statistics = statistics;
        }

        public TextAnalysisRecord(int id, DateTime date, string url, string statistics) : this(date, url, statistics)
        {
            Id = id;
        }
    }
}
