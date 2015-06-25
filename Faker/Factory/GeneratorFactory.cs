using Faker.Extension;
using Faker.Generator;
using Faker.Interface;
using System.Reflection;

namespace Faker.Factory
{
    public class GeneratorFactory
    {
        public IStringGenerator GetStringGenerator(PropertyInfo property)
        {
            if (property.Name.IsNameField())
                return new NameGenerator();

            if (property.Name.IsMailField())
                return new EmailGenerator();

            return new StringGenerator();
        }
    }
}
