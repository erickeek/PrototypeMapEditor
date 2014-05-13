using System;
using System.Collections.Generic;
using System.Linq;

namespace Prototype.Core.Helper
{
    public static class EnumHelper
    {
        public static T ToEnum<T>(this string enumString) where T : struct
        {
            if (String.IsNullOrEmpty(enumString) || !typeof(T).IsEnum)
                throw new Exception("T must be a enum.");

            try
            {
                return (T)System.Enum.Parse(typeof(T), enumString);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static List<int> EnumValues<T>(this IEnumerable<T> enums) where T : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new Exception("T must be a enum.");

            return enums.Cast<int>().ToList();
        }

        public static List<string> EnumNames<T>(this IEnumerable<T> enums) where T : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new Exception("T must be a enum.");

            return enums.Cast<string>().ToList();
        }
    }
}