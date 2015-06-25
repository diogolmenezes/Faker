using Faker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Generator
{
    public class NameGenerator : IStringGenerator
    {
        public static List<string> Names     { get; set; }
        public static List<string> LastNames { get; set; }

        public NameGenerator()
        {
            Names     = new string[] { "Diogo", "Rafael", "Renato", "Elton", "Marcelo", "Andrei", "Philip", "Jhonatan", "Mayane", "Cinthia", "Roberta", "Flavia", "Beatriz", "Suzana", "Rômulo", "Brian", "Joe", "Carlos", "Joaquim", "João"}.ToList();
            LastNames = new string[] { "Silva", "Menezes", "Rodrigues", "Malizia", "Teixeira", "Ruiz", "Andrade", "Silveira", "Oliveira", "Pimentel", "Chaves", "Faria", "Santos", "Senna", "Leite", "Rosa", "Moraes", "Penaterim", "Fazano", "Fagundes" }.ToList();
        }

        public string Get(int number = 0, int maxLength = 0)
        {
            var name     = Names[new Random().Next(0, Names.Count-1)];
            var lastName = LastNames[new Random().Next(0, LastNames.Count-1)];

            return new StringGenerator().Get(name, lastName, number, maxLength);
        }
    }
}
