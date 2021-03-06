﻿using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewsletterCurator.HTMLScraper.Tests
{
    [TestClass]
    public class UnitTests
    {
        private readonly HttpClient httpClient;

        public UnitTests()
        {
            httpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.None
            });
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");


        }

        [TestMethod]
        public async Task ScrapeCdemiBlog()
        {
            var scraperService = new HTMLScraperService(httpClient);
            var urlMetaData = await scraperService.ScrapeMetadataAsync("https://blog.cdemi.io/whats-coming-in-c-8-0-nullable-reference-types/?src=NewsletterCuratorTest");

            Assert.AreEqual(urlMetaData.CanonicalURL, "https://blog.cdemi.io/whats-coming-in-c-8-0-nullable-reference-types/");
            Assert.AreEqual(urlMetaData.Images.Count, 2);
            Assert.AreEqual(urlMetaData.Summary, "One of the features being discussed for introduction in C# 8.0 is Nullable Reference Types. A proficient C# Developer might say \"What?! Aren't all reference types nullable?\" ");
            Assert.AreEqual(urlMetaData.Title, "What's Coming in C# 8.0? Nullable Reference Types");
        }
    }
}
