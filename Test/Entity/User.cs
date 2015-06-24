using Faker.Generator;
using Faker.Interface;
using System;

namespace Faker.Test.Entity
{
     public class User : IFaker<User> {

        public User()
        {
            Name = Guid.NewGuid().ToString("N");
        }

        public string Name  { get; set; }
        public string Email  { get; set; }
        public int Age  { get; set; }
        public DateTime CreatedAt  { get; set; }

        public void Fake(int number)
        {
            Name       = NameGenerator.Get();
            Email      = EmailGenerator.Get();
            Age        = new Random().Next(15, 100);
            CreatedAt  = new DateTimeGenerator().Get();        
        }
    }
}
