using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZPLForge.XmlSerialization.Tests
{
    internal static class SerializationHelper
    {
        public static async Task<string> SerializeToStringAsync<T>(T @object, bool serializeDefaults)
            where T : IDefaultSerializable
        {
            var serializer = new XmlSerializer(typeof(T));
            @object.SerializeDefaults = serializeDefaults;

            using var stream = new MemoryStream();
            serializer.Serialize(stream, @object);
            stream.Seek(0, SeekOrigin.Begin);

            using var reader = new StreamReader(stream);
            var xml =  await reader.ReadToEndAsync();

            return xml;
        }

        public static List<string> GetSerializableProperties<T>()
        {
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Select(x => (
                    Attr: x.GetCustomAttribute<XmlElementAttribute>(),
                    Info: x
                ))
                .Where(x => x.Attr != null)
                .Select(GetElementName)
                .Where(x => x != "Content")
                .ToList();

            return props;
        }

        private static string GetElementName((XmlElementAttribute Attr, PropertyInfo Info) data)
        {
            if (!string.IsNullOrEmpty(data.Attr.ElementName))
            {
                return data.Attr.ElementName;
            }
            else return data.Info.Name;
        }
    }
}
