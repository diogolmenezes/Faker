using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Generator
{
    public class EmailGenerator
    {        
        public static List<string> Providers { get; set; }

        static EmailGenerator()
        {            
            Providers  = new string[] { "gmail.com", "Yahoo.com", "Metatron.com.br", "Globo.com" }.ToList();
        }

        public static string Get(int number = 0, int maxLength = 0)
        {
            var name     = NameGenerator.Names[new Random().Next(0, NameGenerator.Names.Count-1)];
            var lastName = NameGenerator.LastNames[new Random().Next(0, NameGenerator.LastNames.Count-1)];
            var fullName = String.Format("{0}{1}", name, lastName);
            var provider = String.Format("@{0}", Providers[new Random().Next(0, Providers.Count-1)]);

            return StringGenerator.Get(fullName, provider, number, maxLength).Trim().Replace(" ", "_").ToLower();            
        }
    }
}
