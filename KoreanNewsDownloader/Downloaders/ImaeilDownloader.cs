﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ImaeilDownloader : DownloaderBase
    {
        public ImaeilDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "news.imaeil.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@class=\"img_box img_center\"]")
                .Descendants("img")
                .Select(x => $"https://news.imaeil.com{x.GetAttributeValue("src", "")}");
        }
    }
}
