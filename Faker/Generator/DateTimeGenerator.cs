using Faker.Interface;
using Faker.Util;
using System;

namespace Faker.Generator
{
    public class DateTimeGenerator : IGenerator<DateTime>
    {
        public DateTime Get()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(FakerRandom.Next(0, range));
        }
    }
}
