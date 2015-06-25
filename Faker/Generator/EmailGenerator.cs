using Faker.Interface;
using Faker.Util;
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
            var prefix   = new LoginGenerator().Get(number, maxLength);
            var provider = String.Format("@{0}", Providers[FakerRandom.Next(0, Providers.Count-1)]);
            var id       = number == 0 ? "" : String.Format("_{0}", number);
            var email    = String.Format("{0}{1}{2}", prefix, id, provider);            

            return new StringGenerator().Get(email, maxLength).Trim().Replace(" ", "_").ToLower();            
        }
    }
}
