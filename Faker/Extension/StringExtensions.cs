using System.Linq;

namespace Faker.Extension
{
    public static class StringExtensions
    {
        public static bool IsMailField(this string fieldName)
        {
            string[] values = { "email", "mail" };

            return fieldName != null && values.Contains(fieldName.ToLower());
        }

        public static bool IsNameField(this string fieldName)
        {
            string[] values = { "name", "nome", "fullname", "nomecompleto" };

            return fieldName != null &&  values.Contains(fieldName.ToLower());
        }

        public static bool IsLoginField(this string fieldName)
        {
            string[] values = { "login" };

            return fieldName != null &&  values.Contains(fieldName.ToLower());
        }

        public static bool IsIdField(this string fieldName)
        {
            string[] values = { "id" };

            return fieldName != null &&  values.Contains(fieldName.ToLower());
        }
    }
}
