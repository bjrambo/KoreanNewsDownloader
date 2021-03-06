﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class JoinsDownloader : DownloaderBase
    {
        public JoinsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "isplus.live.joins.com", "dcnewsj.joins.com", "koreajoongangdaily.joins.com", "news.jtbc.joins.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[0])
            {
                return base.GetArticleImages();
            }
            else if (Uri.Host == HostUrls[1])
            {
                return Document.DocumentNode
                    .SelectNodes("//*[@class=\"image\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("data-src", ""));
            }
            else if (Uri.Host == HostUrls[2])
            {
                return Document.DocumentNode
                    .SelectSingleNode("//*[@id=\"articlebody\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""));
            }

            return Document.DocumentNode
                .SelectNodes("//div[@class=\"jtbc_img\"]/div/img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
