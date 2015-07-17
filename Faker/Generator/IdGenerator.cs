using Faker.Interface;
using System;

namespace Faker.Generator
{
    public class IdGenerator : IStringGenerator
    {
        public IdGenerator()
        {
        }

        public string Get(int number = 0, int maxLength = 0)
        {
            var id = Guid.NewGuid().ToString("N");
            
            if (maxLength > 0 && maxLength < id.Length)
                id = id.Substring(0, maxLength);

            return id;
        }
    }
}
