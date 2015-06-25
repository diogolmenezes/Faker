using System;

namespace Faker.Util
{
    public class FakerRandom
    {
        public static Random rand = new Random();

        public static int Next(int min = 0, int max = 100)
        {
            return rand.Next(min, max);
        }
    }
}
