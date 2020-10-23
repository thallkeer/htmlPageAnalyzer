using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlPageAnalyzer.Core
{
    /// <summary>
    /// Supports text analysis
    /// </summary>
    public class TextAnalyzer
    {
        private static readonly char[] delimiters = new char[] {' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n',
'\r', '\t' };

        private readonly string _text;

        public TextAnalyzer(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Nothing to analyze, text is empty!");
            _text = text;
        }

        /// <summary>
        /// Counts the number of repetitions for each word in the text
        /// </summary>
        /// <returns>Returns a dictionary, the key of which is a word, and the value is the number of its repetitions in the text</returns>
        public Dictionary<string, int> CountWordRepetitions()
        {
            var words = _text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return words.GroupBy(w => w).ToDictionary(k => k.Key, v => v.Count());
        }
    }
}
