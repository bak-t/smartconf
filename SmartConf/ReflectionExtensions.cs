using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SmartConf
{
    internal static class ReflectionExtensions
    {
        public static bool IsSimplePropety(this PropertyInfo pi)
        {
            var propertyType = pi.PropertyType;
            return propertyType == typeof(string) || propertyType.IsValueType;
        }
    }
}