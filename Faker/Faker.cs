using Faker.Extension;
using Faker.Factory;
using Faker.Generator;
using Faker.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Faker
{
    public class Faker<T>
    {
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
            number   = number == 0 ? 1 : number;
            var fake = Fake(number);
            
            // defining custom properties
            if(exp != null)
                exp(fake);

            return fake;
        }

        public IList<T> CreateMany(int total, Action<T> exp = null)
        {
            var list = Enumerable.Range(0, total).Select(x => Create(x + 1, exp)).ToList();

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
