﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MediasrDownloader : DownloaderBase
    {
        public MediasrDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "www.mediasr.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"article-view-content-div\"]")
                .Descendants("img")
                .Where(x => x.GetAttributeValue("src", "").Contains("/news/photo"))
                .Select(x => $"http://www.mediasr.co.kr{x.GetAttributeValue("src", "")}");
        }
    }
}
