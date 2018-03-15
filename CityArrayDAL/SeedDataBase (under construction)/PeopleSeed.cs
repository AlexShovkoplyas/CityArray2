using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using AngleSharp.Parser.Html;
using CityArrayDAL.Model;


namespace CityArrayDAL.SeedDataBase
{
    static class PeopleSeed
    {
        public static List<Person> GetSimpsonsCharacters()
        {
            var characters = new List<Person>();

            string url = @"https://en.wikipedia.org/wiki/List_of_The_Simpsons_characters";
            var doc = HtmlDoc.GetHtmlDocument(url);

            var table = doc.All
                .First(m => m.LocalName == "table" &&
                            m.PreviousElementSibling.FirstElementChild.Id == "Characters").QuerySelector("tbody");

            foreach (var characterTr in table.Children)
            {
                try
                {
                    var person = new Person()
                    {
                        FirstName = characterTr.QuerySelector("td:nth-child(1)").Text().Split(' ')[0],
                        LastName = characterTr.QuerySelector("td:nth-child(1)").Text().Split(' ')[1],
                        BirthDay = DateTime.Parse(characterTr.QuerySelector("td:nth-child(5)").Text()),
                        NickName = characterTr.QuerySelector("td:nth-child(1)").Text(),
                        //Nationality = new Country() { Name = "USA" }
                    };

                    characters.Add(person);
                }
                catch (Exception)
                {
                }
            }
            return characters;
        }

        
    }
}