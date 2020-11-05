using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    public abstract class LabelContentXmlNode : ILabelContent, IDefaultSerializable
    {
        public LabelContentXmlNode()
        {
            PositionX = ZPLForgeDefaults.Elements.PositionX;
            PositionY = ZPLForgeDefaults.Elements.PositionY;
            FieldOrigin = ZPLForgeDefaults.Elements.FieldOrigin;
            FieldReversePrint = ZPLForgeDefaults.Elements.FieldReversePrint;
        }

        bool IDefaultSerializable.SerializeDefaults { get; set; }
        protected bool SerializeDefaults => (this as IDefaultSerializable).SerializeDefaults;

        [XmlElement]
        public int PositionX { get; set; }

        [XmlElement]
        public int PositionY { get; set; }

        [XmlElement]
        public FieldOrigin FieldOrigin { get; set; }

        [XmlElement]
        public bool FieldReversePrint { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePositionX() =>
            SerializeDefaults
            || !PositionX.Equals(ZPLForgeDefaults.Elements.PositionX);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePositionY() =>
            SerializeDefaults
            || !PositionY.Equals(ZPLForgeDefaults.Elements.PositionY);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFieldOrigin() =>
            SerializeDefaults
            || !FieldOrigin.Equals(ZPLForgeDefaults.Elements.FieldOrigin);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFieldReversePrint() =>
            SerializeDefaults
            || !FieldReversePrint.Equals(ZPLForgeDefaults.Elements.FieldReversePrint);
    }
}
