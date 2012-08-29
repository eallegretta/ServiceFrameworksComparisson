using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using WebSite.Services.Contracts;

namespace WebSite.Services.Impl
{
    public class QuotesService: IQuotesService
    {
        public string GetRandomQuoteOfTheDay()
        {
            var webClient = new WebClient();

            var rawText = webClient.DownloadString("http://www.iheartquotes.com/api/v1/random");

            var quoteOfTheDay = new StringBuilder();

            using (var reader = new StringReader(rawText))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("["))
                        break;

                    quoteOfTheDay.Append(line);
                }
            }

            return quoteOfTheDay.ToString();
        }
    }
}