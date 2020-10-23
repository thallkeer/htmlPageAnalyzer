using CsQuery;
using System;
using System.IO;
using System.Text;

namespace HtmlPageAnalyzer.Core
{
    /// <summary>
    /// Parses the html file
    /// </summary>
    public class HtmlParser : IHtmlParser
    { 
        /// <summary>
        /// Parses the html file by given path and returns viewable text
        /// </summary>
        /// <param name="filePath">Path to html file</param>
        /// <returns>Text from web page</returns>
        public string ParseHtmlFile(string filePath)
        {
            if (Path.GetExtension(filePath) != ".html")
                throw new ArgumentException("File at given path must be a html file");
            using var fs = new FileStream(filePath, FileMode.Open);
            CQ dom = CQ.Create(fs);
            StringBuilder pageText = new StringBuilder();
            ExtractViewableText(dom.Document.ChildNodes, ref pageText);
            return pageText.ToString();
        }

        private void ExtractViewableText(INodeList nodes, ref StringBuilder text)
        {
            foreach (IDomObject node in nodes)
            {
                if (node.NodeType == NodeType.TEXT_NODE)
                {
                    string nodeValue = node.NodeValue?.Trim();
                    if (!string.IsNullOrEmpty(nodeValue))
                    {
                        var parNodeName = node.ParentNode?.NodeName?.ToLower();
                        if (parNodeName != null && parNodeName != "script" && parNodeName != "style" && parNodeName != "body")
                        {
                            text.AppendLine(nodeValue.ToUpper());                            
                        }
                    }
                }
                var childNodes = node.ChildNodes;
                if (childNodes != null)
                {
                    ExtractViewableText(childNodes, ref text);
                }
            }
        }
    }
}
