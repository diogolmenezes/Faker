using System;
using System.Collections.Generic;

namespace Faker
{
    public static class TypeExtensions
    {
        public static bool IsString(this Type type)
        {
            return type == typeof(String) || type == typeof(string);
        }        

        public static bool IsBoolean(this Type type)
        {
            bool notNullTypes = type == typeof(bool) || type == typeof(Boolean);
            bool nullTypes    = type == typeof(bool?) || type == typeof(Boolean?);
            return notNullTypes || nullTypes;
        }

        public static bool IsInteger(this Type type)
        {
            bool notNullTypes = type == typeof(int) || type == typeof(Int16) || type == typeof(Int32) || type == typeof(Int64);
            bool nullTypes    = type == typeof(int?) || type == typeof(Int16?) || type == typeof(Int32?) || type == typeof(Int64?);
            return notNullTypes || nullTypes;
        }

        public static bool IsFloat(this Type type)
        {
            bool notNullTypes = type == typeof(float);
            bool nullTypes    = type == typeof(float?);
            return notNullTypes || nullTypes;
        }

        public static bool IsDouble(this Type type)
        {
            bool notNullTypes = type == typeof(double) || type == typeof(Double);
            bool nullTypes    = type == typeof(double?) || type == typeof(Double?);
            return notNullTypes || nullTypes;
        }

        public static bool IsNumber(this Type type)
        {
            return IsInteger(type) || IsFloat(type) || IsDouble(type);
        }

        public static bool IsDateTime(this Type type)
        {
            bool notNullTypes = type == typeof(DateTime);
            bool nullTypes    = type == typeof(DateTime?);
            return notNullTypes || nullTypes;
        }

        public static bool IsList(this Type type)
        {
            bool isGenericList = false;

            if (type.IsGenericType && ((type.GetGenericTypeDefinition() == typeof(List<>)) || (type.GetGenericTypeDefinition() == typeof(IList<>))))
                isGenericList = true;

            return isGenericList;
        }
    }
}
