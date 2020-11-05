using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    [XmlType(TypeName = "DiagonalLine")]
    public class DiagonalLineXmlNode : LabelContentXmlNode, IDiagonalLine
    {
        public DiagonalLineXmlNode()
        {
            Width = ZPLForgeDefaults.Elements.DiagonalLine.Width;
            Height = ZPLForgeDefaults.Elements.DiagonalLine.Height;
            BorderThickness = ZPLForgeDefaults.Elements.DiagonalLine.BorderThickness;
            BorderColor = ZPLForgeDefaults.Elements.DiagonalLine.BorderColor;
            InverseLeaningDirection = ZPLForgeDefaults.Elements.DiagonalLine.InverseLeaningDirection;
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
        public bool InverseLeaningDirection { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeWidth() =>
            SerializeDefaults
            || !Width.Equals(ZPLForgeDefaults.Elements.DiagonalLine.Width);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeHeight() =>
            SerializeDefaults
            || !Height.Equals(ZPLForgeDefaults.Elements.DiagonalLine.Height);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBorderThickness() =>
            SerializeDefaults
            || !BorderThickness.Equals(ZPLForgeDefaults.Elements.DiagonalLine.BorderThickness);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBorderColor() =>
            SerializeDefaults
            || !BorderColor.Equals(ZPLForgeDefaults.Elements.DiagonalLine.BorderColor);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeInverseLeaningDirection() =>
            SerializeDefaults
            || !InverseLeaningDirection.Equals(ZPLForgeDefaults.Elements.DiagonalLine.InverseLeaningDirection);
    }
}
