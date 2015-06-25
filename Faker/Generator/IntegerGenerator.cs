using Faker.Interface;
using Faker.Util;

namespace Faker.Generator
{
    public class IntegerGenerator : IGenerator<int>
    {        
        public int Get(int min = 0, int max = 100)
        {
            return FakerRandom.Next(min, max);
        }

        public int Get()
        {
            return Get(0, 100);
        }
    }
}
