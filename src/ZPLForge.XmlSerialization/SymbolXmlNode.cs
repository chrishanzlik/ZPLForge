using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    [XmlType(TypeName = "Symbol")]
    public class SymbolXmlNode : LabelContentXmlNode, ISymbol
    {
        public SymbolXmlNode()
        {
            FieldOrientation = ZPLForgeDefaults.Elements.Symbol.FieldOrientation;
        }

        [XmlElement]
        public Orientation FieldOrientation { get; set; }

        [XmlElement]
        public int? Height { get; set; }

        [XmlElement]
        public int? Width { get; set; }

        [XmlElement]
        public SymbolKind? Content { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFieldOrientation() =>
            SerializeDefaults
            || !FieldOrientation.Equals(ZPLForgeDefaults.Elements.Symbol.FieldOrientation);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeHeight() =>
            SerializeDefaults
            || Height.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeWidth() =>
            SerializeDefaults
            || Width.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeContent() => 
            SerializeDefaults
            || Content.HasValue;
    }
}
