using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ZPLForge.XmlSerialization.Helpers
{
    internal static class SimpleObjectMapper
    {
		private static readonly ConcurrentDictionary<string, List<(PropertyInfo source, PropertyInfo destination)>> maps =
			new ConcurrentDictionary<string, List<(PropertyInfo soure, PropertyInfo destination)>>();

		private static readonly ConcurrentDictionary<string, Func<object>> factories =
			new ConcurrentDictionary<string, Func<object>>();

		public static object MapFlat(object source, Type destinationType)
        {
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (destinationType == null) throw new ArgumentException(nameof(destinationType));

			var sourceType = source.GetType();
			var dictKey = sourceType.Name + destinationType.Name;
			
			if (!factories.ContainsKey(destinationType.Name))
            {
				factories[destinationType.Name] = Expression.Lambda<Func<object>>(Expression.New(destinationType)).Compile();
			}

			var destination = factories[destinationType.Name]();

			if (!maps.ContainsKey(dictKey))
			{
                maps[dictKey] = (
                    from src in GetProperties(sourceType)
                    from dest in GetProperties(destinationType)
                    where TypeIsNoCollection(src.PropertyType)
						&& src.Name == dest.Name
                        && src.CanRead
                        && dest.CanWrite
                        && src.PropertyType == dest.PropertyType
                    select (src, dest)
                ).ToList();
            }

			foreach (var map in maps[dictKey])
			{
				var sourceValue = map.source.GetValue(source);
				map.destination.SetValue(destination, sourceValue);
			}

			return destination;
		}

        private static bool TypeIsNoCollection(Type type)
        {
            var t = Nullable.GetUnderlyingType(type) ?? type;

			if (t == typeof(string)) return true;

			return !t.IsArray && !typeof(IEnumerable).IsAssignableFrom(t);
		}

        private static List<PropertyInfo> GetProperties(Type type)
        {
			return type
				.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
				.Concat(type
					.GetInterfaces()
					.SelectMany(x => x.GetProperties(BindingFlags.Public | BindingFlags.Instance)))
				.Distinct()
				.ToList();
		}
	}
}
