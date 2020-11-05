using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    [XmlType("Ellipse")]
    public class EllipseXmlNode : LabelContentXmlNode, IEllipse
    {
        public EllipseXmlNode()
        {
            Width = ZPLForgeDefaults.Elements.Ellipse.Width;
            Height = ZPLForgeDefaults.Elements.Ellipse.Height;
            BorderThickness = ZPLForgeDefaults.Elements.Ellipse.BorderThickness;
            BorderColor = ZPLForgeDefaults.Elements.Ellipse.BorderColor;
        }


        [XmlElement]
        public int Width { get; set; }

        [XmlElement]
        public int Height { get; set; }

        [XmlElement]
        public int BorderThickness { get; set; }

        [XmlElement]
        public LabelColor BorderColor { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeWidth() =>
            SerializeDefaults
            || !Width.Equals(ZPLForgeDefaults.Elements.Ellipse.Width);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeHeight() =>
            SerializeDefaults
            || !Height.Equals(ZPLForgeDefaults.Elements.Ellipse.Height);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBorderThickness() =>
            SerializeDefaults
            || !BorderThickness.Equals(ZPLForgeDefaults.Elements.Ellipse.BorderThickness);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBorderColor() =>
            SerializeDefaults
            || !BorderColor.Equals(ZPLForgeDefaults.Elements.Ellipse.BorderColor);
    }
}
