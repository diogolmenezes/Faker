using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Extension
{
    public static class TypeExtensions
    {
        public static bool IsString(this Type type)
        {
            Type[] allowedTypes = { typeof(string), typeof(String) };           
            return allowedTypes.Contains(type);
        }        

        public static bool IsBoolean(this Type type)
        {
            Type[] allowedTypes = { typeof(bool), typeof(Boolean), typeof(bool?), typeof(Boolean?) };
            return allowedTypes.Contains(type);
        }

        public static bool IsInteger(this Type type)
        {
            Type[] allowedTypes = { typeof(int), typeof(Int16), typeof(Int32), typeof(Int64), typeof(int?), typeof(Int16?), typeof(Int32?), typeof(Int64?) };
            return allowedTypes.Contains(type);
        }

        public static bool IsFloat(this Type type)
        {
            Type[] allowedTypes = { typeof(float), typeof(float?) };
            return allowedTypes.Contains(type);            
        }

        public static bool IsDouble(this Type type)
        {
            Type[] allowedTypes = { typeof(double), typeof(Double), typeof(double?), typeof(Double?) };
            return allowedTypes.Contains(type);
        }

        public static bool IsNumber(this Type type)
        {
            return IsInteger(type) || IsFloat(type) || IsDouble(type);
        }

        public static bool IsDateTime(this Type type)
        {
            Type[] allowedTypes = { typeof(DateTime), typeof(DateTime?) };
            return allowedTypes.Contains(type);
        }

        public static bool IsList(this Type type)
        {
            Type[] allowedTypes = { typeof(IList<>), typeof(List<>), typeof(ICollection<>), typeof(IEnumerable<>), typeof(Enumerable) };
            return (type.IsGenericType && allowedTypes.Contains(type.GetGenericTypeDefinition()));               
        }
    }
}
