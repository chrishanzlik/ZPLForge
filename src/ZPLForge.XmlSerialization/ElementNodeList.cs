using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using ZPLForge.Contracts;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    public class ElementNodeList : List<LabelContentXmlNode>, IXmlSerializable
    {
        public ElementNodeList()
        {
        }

        public ElementNodeList(IEnumerable<ILabelContent> source)
        {
            foreach(var obj in source)
            {
                var objType = obj.GetType();

                var map = MappingTable.Find(objType);

                if (map == null)
                    throw new InvalidOperationException("Not supported mapping type.");

                Add((LabelContentXmlNode)SimpleObjectMapper.MapFlat(obj, map.XmlNodeType));
            };
        }

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            var nodes = XElement.Parse(reader.ReadOuterXml()).Elements().ToList();
            foreach(var node in nodes)
            {
                var map = MappingTable.Find(node.Name.LocalName);

                if (map == null)
                    throw new InvalidOperationException("Not supported mapping type.");

                var serializer = new XmlSerializer(map.XmlNodeType);
                
                using (var nodeReader = node.CreateReader())
                    Add((LabelContentXmlNode)serializer.Deserialize(nodeReader));
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach(var item in this)
            {
                var type = item.GetType();
                var serializer = new XmlSerializer(type);
                serializer.Serialize(writer, item);
            }
        }
    }
}
