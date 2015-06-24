using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Generator
{
    public class IntegerGenerator
    {        
        public static int Get(int min = 0, int max = 100)
        {
            return new Random().Next(min, max);
        }
    }
}
