using HtmlPageAnalyzer.Core;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HtmlPageAnalyzer.Tests
{
    public class WebPageLoaderTests
    {
        IWebPageLoader webPageLoader;
        [SetUp]
        public void Setup()
        {
            webPageLoader = new WebPageLoader();
        }

        [Test]
        public async Task DownloadPageAsync_WhenUrlIsCorrect_ShouldDownloadPage()
        {
            string filePath = await webPageLoader.DownloadPageAsync(@"https://www.simbirsoft.com/");
            FileAssert.Exists(filePath);        
        }

        [Test]
        public void DownloadPageAsync_WhenUrlIsNotCorrect_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await webPageLoader.DownloadPageAsync("google.com"));
        }

        [Test]
        public void DownloadPageAsync_WhenResponseContentTypeIsNotHtml_ShouldThrowWrongPageContentType()
        {
            string urlWithPdf = @"https://viduus.net/wp-content/uploads/2018/02/Rihter-Dzh.-CLR-via-C.-Programmirovanie-na-platforme-Microsoft-.NET-Framework-4.5-na-yazyke-C-Master-klass-2013.pdf";
            Assert.ThrowsAsync<WrongPageContentTypeException>(async () => await webPageLoader.DownloadPageAsync(urlWithPdf));            
        }
    }
}