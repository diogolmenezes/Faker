using Faker.Generator;
using Faker.Interface;
using System;

namespace Faker.Test.Entity
{
     public class User : IFaker<User> 
     {
        public string Name  { get; set; }
        public string Email  { get; set; }
        public int Age  { get; set; }
        public DateTime CreatedAt  { get; set; }

        public void Fake(int number)
        {
            Name       = NameGenerator.Get();
            Email      = EmailGenerator.Get();
            Age        = IntegerGenerator.Get(15, 99);
            CreatedAt  = DateTimeGenerator.Get();        
        }
    }
}
