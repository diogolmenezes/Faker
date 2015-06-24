
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Faker.Test.Entity
{
    public class Car
    {
        [MaxLength(20)]
        public string Model { get; set; }

        [MaxLength(10)]
        public string Color { get; set; }

        public int? Year { get; set; }

        public DateTime CreatedAt { get; set; }

        public User Owner   { get; set; }

        public string Owner_Id { get; set; }

        public List<string> Skils { get; set; }
    }
}
