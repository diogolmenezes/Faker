using Faker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker
{
    public class Faker<T>
    {
        /// <summary>
        /// Add a aditional number to generated data.
        /// <example>Name 1, Name 2, Name 3</example>
        /// </summary>
        public bool UseSequenceNumbers { get; set; }

        public Faker() : this(false) { }        

        public Faker(bool useSequenceNumbers)
        {
            UseSequenceNumbers = useSequenceNumbers;
        }

        private bool IsIFakerInterface
        {
            get
            {
                return typeof(T).GetInterfaces().Contains(typeof(IFaker<T>));
            }
        }

        public T Create(Action<T> exp = null)
        {
            return Create(0, exp);
        }
        
        public T Create(int number, Action<T> exp = null)
        {
            if(UseSequenceNumbers)
                number   = number == 0 ? 1 : number;

            var fake = Fake(number);
            
            // defining custom properties
            if(exp != null)
                exp(fake);

            return fake;
        }

        public IList<T> CreateMany(int total, Action<T> exp = null)
        {
            var list = Enumerable.Range(0, total).Select(x => Create((UseSequenceNumbers) ? x + 1 : 0, exp)).ToList();

            return list;
        }

        private T Fake(int number)
        {
            if (IsIFakerInterface)
            {
                IFaker<T> faker = (IFaker<T>) ((T)Activator.CreateInstance(typeof(T)));
                faker.Fake(number);
                return (T)faker;
            }
            else
                return FakeByReflection(number);
        }

        /// <summary>
        /// Creates an nem fake object
        /// </summary>
        /// <param name="number">Sequence number</param>
        private T FakeByReflection(int number)
        {            
            var entity         = (T)Activator.CreateInstance(typeof(T));
            var properties     = typeof(T).GetProperties();
            var propertyFiller = new PropertyFiller<T>();

            foreach(var property in properties)
                 propertyFiller.Fill(entity, property, number);

            return entity;
        }
    }
}
