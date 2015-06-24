using System;

namespace Faker.Generator
{
    public class DateTimeGenerator
    {
        public DateTime Get()
        {
            DateTime start = new DateTime(1995, 1, 1);
            Random gen     = new Random();

            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
