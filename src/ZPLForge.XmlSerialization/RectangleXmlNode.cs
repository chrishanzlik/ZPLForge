using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    [XmlType("Rectangle")]
    public class RectangleXmlNode : LabelContentXmlNode, IRectangle
    {
        public RectangleXmlNode()
        {
            Width = ZPLForgeDefaults.Elements.Rectangle.Width;
            Height = ZPLForgeDefaults.Elements.Rectangle.Height;
            BorderThickness = ZPLForgeDefaults.Elements.Rectangle.BorderThickness;
            BorderColor = ZPLForgeDefaults.Elements.Rectangle.BorderColor;
            CornerRounding = ZPLForgeDefaults.Elements.Rectangle.CornerRounding;
        }


        [XmlElement]
        public int Width { get; set; }

        [XmlElement]
        public int Height { get; set; }

        [XmlElement]
        public int BorderThickness { get; set; }

        [XmlElement]
        public LabelColor BorderColor { get; set; }

        [XmlElement]
        public int CornerRounding { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeWidth() =>
            SerializeDefaults
            || !Width.Equals(ZPLForgeDefaults.Elements.Rectangle.Width);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeHeight() =>
            SerializeDefaults
            || !Height.Equals(ZPLForgeDefaults.Elements.Rectangle.Height);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBorderThickness() =>
            SerializeDefaults
            || !BorderThickness.Equals(ZPLForgeDefaults.Elements.Rectangle.BorderThickness);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBorderColor() =>
            SerializeDefaults
            || !BorderColor.Equals(ZPLForgeDefaults.Elements.Rectangle.BorderColor);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeCornerRounding() =>
            SerializeDefaults
            || !CornerRounding.Equals(ZPLForgeDefaults.Elements.Rectangle.CornerRounding);
    }
}
