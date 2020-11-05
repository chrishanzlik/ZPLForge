using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    [XmlType("Image")]
    public class ImageXmlNode : LabelContentXmlNode, IImage
    {
        public ImageXmlNode()
        {
            Compression = ZPLForgeDefaults.Elements.Image.Compression;
        }

        [XmlElement]
        public CompressionType Compression { get; set; }

        [XmlElement]
        public int? BinaryByteCount { get; set; }

        [XmlElement]
        public int? GraphicFieldCount { get; set; }

        [XmlElement]
        public int? BytesPerRow { get; set; }

        [XmlElement]
        public string Content { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeCompression() =>
            SerializeDefaults
            || !Compression.Equals(ZPLForgeDefaults.Elements.Image.Compression);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBinaryByteCount() =>
            SerializeDefaults
            || BinaryByteCount.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGraphicFieldCount() =>
            SerializeDefaults
            || GraphicFieldCount.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBytesPerRow() =>
            SerializeDefaults
            || BytesPerRow.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeContent() =>
            SerializeDefaults
            || !string.IsNullOrEmpty(Content);
    }
}
