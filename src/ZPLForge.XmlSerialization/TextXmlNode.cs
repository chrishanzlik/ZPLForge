using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    [XmlType(TypeName = "Text")]
    public class TextXmlNode : LabelContentXmlNode, IText
    {
        public TextXmlNode()
        {
            FontOrientation = ZPLForgeDefaults.Elements.Text.FontOrientation;
            FontStyle = ZPLForgeDefaults.Elements.Text.FontStyle;
            BlockMode = ZPLForgeDefaults.Elements.Text.BlockMode;
            BlockWidth = ZPLForgeDefaults.Elements.Text.BlockWidth;
            BlockLines = ZPLForgeDefaults.Elements.Text.BlockLines;
            BlockLineSpace = ZPLForgeDefaults.Elements.Text.BlockLineSpace;
            BlockAlignment = ZPLForgeDefaults.Elements.Text.BlockAlignment;
        }

        [XmlElement]
        public string Content { get; set; }

        [XmlElement]
        public Orientation FontOrientation { get; set; }

        [XmlElement]
        public Font FontStyle { get; set; }

        [XmlElement]
        public bool BlockMode { get; set; }

        [XmlElement]
        public int BlockWidth { get; set; }

        [XmlElement]
        public int BlockLines { get; set; }

        [XmlElement]
        public int BlockLineSpace { get; set; }

        [XmlElement]
        public BlockAlignment BlockAlignment { get; set; }

        [XmlElement]
        public int? CharHeight { get; set; }
        
        [XmlElement]
        public int? CharWidth { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFontOrientation() =>
            SerializeDefaults
            || !FontOrientation.Equals(ZPLForgeDefaults.Elements.Text.FontOrientation);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFontStyle() =>
            SerializeDefaults
            || !FontStyle.Equals(ZPLForgeDefaults.Elements.Text.FontStyle);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBlockMode() =>
            SerializeDefaults
            || !BlockMode.Equals(ZPLForgeDefaults.Elements.Text.BlockMode);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBlockWidth() =>
            SerializeDefaults
            || !BlockWidth.Equals(ZPLForgeDefaults.Elements.Text.BlockWidth);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBlockLines() =>
            SerializeDefaults
            || !BlockLines.Equals(ZPLForgeDefaults.Elements.Text.BlockLines);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBlockAlignment() =>
            SerializeDefaults
            || !BlockAlignment.Equals(ZPLForgeDefaults.Elements.Text.BlockAlignment);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBlockLineSpace() =>
            SerializeDefaults
            || !BlockLineSpace.Equals(ZPLForgeDefaults.Elements.Text.BlockLineSpace);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeCharHeight() =>
            SerializeDefaults
            || CharHeight.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeCharWidth() =>
            SerializeDefaults
            || CharWidth.HasValue;
    }
}
