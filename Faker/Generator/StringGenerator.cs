using Faker.Interface;
using System;

namespace Faker.Generator
{
    public class StringGenerator : IStringGenerator
    {
        public string Get(string prefix = "FakeObject", string suffix = null, int number = 1, int maxLength = 0)
        {
            var id   = number == 0 ? "" : String.Format("{0}", number);
            var fake = String.Format("{0} {1} {2}", prefix, suffix, id);

            if (maxLength > 0 && maxLength < fake.Length)
                return fake.Substring(0, maxLength);

            return fake;
        }

        public string Get(string text, int maxLength)
        {
            return Get(text, null, 0, maxLength);
        }

        public string Get(int number = 1, int maxLength = 0)
        {
            return Get(null, null, number, maxLength);
        }
    }
}
