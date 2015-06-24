using System;

namespace Faker.Generator
{
    public class StringGenerator
    {
        public static string Get(string prefix = "FakeObject", string suffix = null, int number = 1, int maxLength = 0)
        {
            var id   = number == 0 ? "" : String.Format("{0}", number);
            var fake = String.Format("{0} {1} {2}", prefix, suffix, id);

            if (maxLength > 0 && maxLength < fake.Length)
                return fake.Substring(0, maxLength);

            return fake;
        }
    }
}
