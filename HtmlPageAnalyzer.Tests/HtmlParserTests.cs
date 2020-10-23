using HtmlPageAnalyzer.Core;
using NUnit.Framework;
using System;
using System.IO;

namespace HtmlPageAnalyzer.Tests
{
    class HtmlParserTests
    {
        IHtmlParser parser;
        [SetUp]
        public void Setup()
        {
            parser = new HtmlParser();
        }

        [Test]
        public void ParseHtmlFile_WhenFileIsNotExists_ShouldThrow()
        {
            Assert.Throws<FileNotFoundException>(() => parser.ParseHtmlFile("notexistingfile.html"));
        }

        [Test]
        public void ParseHtmlFile_WhenNotHtmlFile_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => parser.ParseHtmlFile("nothtmlfile.txt"));
        }

        [Test]
        public void ParseHtmlFile_WhenValidHtmlFile_ShouldReturnText()
        {
            Assert.False(string.IsNullOrEmpty(parser.ParseHtmlFile(@"assets/SimbirSoft.html")));
        }
    }
}
