using System.Xml.Serialization;

namespace ZPLForge.XmlSerialization
{
    public interface IDefaultSerializable
    {
        [XmlIgnore]
        bool SerializeDefaults { get; set; }
    }
}
