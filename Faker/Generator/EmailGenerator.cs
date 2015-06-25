using Faker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Generator
{
    public class EmailGenerator : IStringGenerator
    {        
        public static List<string> Providers { get; set; }

        public EmailGenerator()
        {            
            Providers  = new string[] { "gmail.com", "Yahoo.com", "Metatron.com.br", "Globo.com" }.ToList();
        }

        public string Get(int number = 0, int maxLength = 0)
        {
            var name     = NameGenerator.Names[new Random().Next(0, NameGenerator.Names.Count-1)];
            var lastName = NameGenerator.LastNames[new Random().Next(0, NameGenerator.LastNames.Count-1)];
            var fullName = String.Format("{0}{1}", name, lastName);
            var provider = String.Format("@{0}", Providers[new Random().Next(0, Providers.Count-1)]);

            return new StringGenerator().Get(fullName, provider, number, maxLength).Trim().Replace(" ", "_").ToLower();            
        }
    }
}
