using Faker.Interface;
using System;

namespace Faker.Generator
{
    public class IntegerGenerator : IGenerator<int>
    {        
        public int Get(int min = 0, int max = 100)
        {
            return new Random().Next(min, max);
        }

        public int Get()
        {
            return Get(0, 100);
        }
    }
}
