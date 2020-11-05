using System;
using System.IO;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.XmlSerialization.Helpers;

namespace ZPLForge.XmlSerialization
{
    public sealed class LabelXmlSerializer
    {
        private readonly XmlSerializer serializer;

        public LabelXmlSerializer()
        {
            serializer = new XmlSerializer(typeof(LabelXmlNode));
        }

        public void Serialize(Stream stream, ILabel label, bool serializeDefaults = false)
        {
            if (label == null)
                throw new ArgumentNullException(nameof(label));

            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            var labelXmlNode = (LabelXmlNode)SimpleObjectMapper.MapFlat(label, typeof(LabelXmlNode));
            (labelXmlNode as IDefaultSerializable).SerializeDefaults = serializeDefaults;
            labelXmlNode.Version = VersionProvider.ProductVersion;

            foreach (LabelContent element in label.Content)
            {
                LabelContentXmlNode node = (LabelContentXmlNode)SimpleObjectMapper.MapFlat(element, MappingTable.ElementToXmlType(element.GetType()));
                (node as IDefaultSerializable).SerializeDefaults = serializeDefaults;
                labelXmlNode.Content.Add(node);
            }

            serializer.Serialize(stream, labelXmlNode);
        }

        public Label Deserialize(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            var xmlNode = (LabelXmlNode)serializer.Deserialize(stream);
            return CreateLabelFromNode(xmlNode);
        }

        private Label CreateLabelFromNode(LabelXmlNode xmlNode)
        {
            var element = (Label)SimpleObjectMapper.MapFlat(xmlNode, typeof(Label));

            foreach (LabelContentXmlNode node in xmlNode.Content)
            {
                var nodeType = node.GetType();
                var o = (ILabelContent)SimpleObjectMapper.MapFlat(node, MappingTable.XmlToElementType(nodeType));
                element.Content.Add(o);
            }

            return element;
        }
    }
}
