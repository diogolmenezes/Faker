using System.ComponentModel.DataAnnotations;

namespace Faker.Test.Entity
{
    public class Worker
    {
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Mail { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }        
    }
}
