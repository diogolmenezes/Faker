using Faker.Extension;
using Faker.Factory;
using Faker.Generator;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Faker
{
    public class PropertyFiller<T>
    {
        public void Fill(T entity, PropertyInfo property, int number)
        {
            var type = property.PropertyType;

            if (property.CanWrite)
            {
                if (type.IsString())
                    FillStringProperty(entity, property, number);
                else if (type.IsNumber())
                    FillNumberProperty(entity, property, number);
                else if (type.IsDateTime())
                    FillDateProperty(entity, property, number);
                else
                    FillCustomProperty(entity, property, number);
            }
        }

        private void FillStringProperty(T entity, PropertyInfo property, int number)
        {
            var length = GetMaxLength(property);
            var value  = new GeneratorFactory().GetStringGenerator(property).Get(number, length);
            property.SetValue(entity, value, null); 
        }

        private void FillNumberProperty(T entity, PropertyInfo property, int number)
        {
            property.SetValue(entity, new IntegerGenerator().Get(0, 100), null);
        }

        private void FillDateProperty(T entity, PropertyInfo property, int number)
        {
            property.SetValue(entity, new DateTimeGenerator().Get(), null);
        }

        /// <summary>
        /// Try to construct new faker object or set default value for the property
        /// </summary>
        private void FillCustomProperty(T entity, PropertyInfo property, int number)
        {
            var type = property.PropertyType;

            try
            {
                if (type.IsList())
                    property.SetValue(entity, Activator.CreateInstance(type), null);
                else
                {
                    // use faker constructor
                    Type genericType = typeof(Faker<>).MakeGenericType(type);
                    var faker        = Activator.CreateInstance(genericType);

                    // Ex: call with int and string arguments
                    // obj.GetType().GetMethod("Foo", new Type[] { typeof(int), typeof(string)).Invoke(obj, new object[] { 42, "Hello" });
                    // Ex: call without arguments
                    // obj.GetType().GetMethod("Foo", new Type[0]).Invoke(obj, new object[0]);

                    var fakeObject   = genericType.GetMethod("Create", new Type[0]).Invoke(faker, new object[0]);

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
