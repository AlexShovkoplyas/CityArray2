using System;
using System.Net;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace CityArrayDAL.SeedDataBase
{
    public static class HtmlDoc
    {
        internal static IHtmlDocument GetHtmlDocument(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Didn't reach http source!");

            using (var stream = response.GetResponseStream())
            {
                return new HtmlParser().Parse(stream);
            }
        }
    }
}