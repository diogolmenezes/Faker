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
            var entity     = (T)Activator.CreateInstance(typeof(T));
            var properties = typeof(T).GetProperties();


            foreach(var property in properties)
                FillProperty(entity, property, number);


            return entity;
        }

        /// <summary>
        /// Fill the property with ramdom fake data
        /// </summary>
        /// <param name="entity">Entity do fill</param>
        /// <param name="property">Property to fill</param>
        /// <param name="number">Sequence number</param>
        private void FillProperty(T entity, PropertyInfo property, int number)
        {
            var type        = property.PropertyType;

            if (property.CanWrite)
            {

                if (type.IsString())
                {
                    var length = GetMaxLength(property);
                    property.SetValue(entity, StringGenerator.Get(prefix: property.Name, number: number, maxLength: length), null);
                }
                else if (type.IsNumber())
                    property.SetValue(entity, new Random().Next(0, 100), null);
                else if (type.IsDateTime())
                    property.SetValue(entity, new DateTimeGenerator().Get(), null);
                else
                    TrySetDefaultValue(entity, property, type);
            }
        }

        /// <summary>
        /// Try to set default value for the property
        /// </summary>
        private static void TrySetDefaultValue(T entity, PropertyInfo property, Type type)
        {
            try
            {
                if (type.IsList())
                    property.SetValue(entity, Activator.CreateInstance(type), null);
                else
                {
                    // use faker constructor
                    Type genericType = typeof(Faker<>).MakeGenericType(type);
                    var faker        = Activator.CreateInstance(genericType);
                    var fakeObject   = genericType.GetMethod("Create").Invoke(faker, new object[] { 1 });

                    property.SetValue(entity, fakeObject, null);
                }
            }
            catch
            {                
                try
                {
                    // use default constructor
                    property.SetValue(entity, Activator.CreateInstance(type), null);
                }
                catch
                {                    
                    //ignore
                }
            }
        }

        /// <summary>
        /// Get MaxLength ou StringLenght annotations
        /// </summary>
        private int GetMaxLength(PropertyInfo property)
        {
            var maxLengthAttribute    = (MaxLengthAttribute)property.GetCustomAttribute(typeof(MaxLengthAttribute));
            var stringLengthAttribute = (StringLengthAttribute)property.GetCustomAttribute(typeof(StringLengthAttribute));
            var maxLength             = (maxLengthAttribute != null) ? maxLengthAttribute.Length : 0;
            var stringLength          = (stringLengthAttribute != null) ? stringLengthAttribute.MaximumLength : 0;
            var length                = (maxLength == stringLength || maxLength > stringLength) ? maxLength : stringLength;

            return length;
        }       
    }
}
