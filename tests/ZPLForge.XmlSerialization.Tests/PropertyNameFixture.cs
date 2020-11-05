using System.Collections.Generic;

namespace ZPLForge.XmlSerialization.Tests
{
    public class PropertyNameFixture<T>
    {
        public IReadOnlyCollection<string> PropertyNames { get; set; }

        public PropertyNameFixture()
        {
            PropertyNames = SerializationHelper.GetSerializableProperties<T>().AsReadOnly();
        }
    }
}
