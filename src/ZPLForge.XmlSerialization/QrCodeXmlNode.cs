using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    [XmlType("QrCode")]
    public class QrCodeXmlNode : LabelContentXmlNode, IQrCode
    {
        public QrCodeXmlNode()
        {
            QrModel = ZPLForgeDefaults.Elements.QrCode.QrModel;
            MagnificationFactor = ZPLForgeDefaults.Elements.QrCode.MagnificationFactor;
            ErrorCorrection = ZPLForgeDefaults.Elements.QrCode.ErrorCorrection;
            MaskValue = ZPLForgeDefaults.Elements.QrCode.MaskValue;
        }

        
        [XmlElement]
        public string Content { get; set; }

        [XmlIgnore]
        public QrModel QrModel { get; set; }

        [XmlElement("QrModel")]
        public string QrModelString
        {
            get => ((int)QrModel).ToString();
            set => QrModel = (QrModel)int.Parse(value);
        }

        [XmlIgnore]
        public Magnification MagnificationFactor { get; set; }

        [XmlElement("MagnificationFactor")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MagnificationFactorString
        {
            get => ((int)MagnificationFactor).ToString();
            set => MagnificationFactor = (Magnification)int.Parse(value);
        }

        [XmlElement]
        public ErrorCorrection ErrorCorrection { get; set; }

        [XmlElement]
        public int MaskValue { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeQrModelString() =>
            SerializeDefaults
            || !QrModel.Equals(ZPLForgeDefaults.Elements.QrCode.QrModel);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeMagnificationFactorString() =>
            SerializeDefaults
            || !MagnificationFactor.Equals(ZPLForgeDefaults.Elements.QrCode.MagnificationFactor);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeErrorCorrection() =>
            SerializeDefaults
            || !ErrorCorrection.Equals(ZPLForgeDefaults.Elements.QrCode.ErrorCorrection);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeMaskValue() =>
            SerializeDefaults
            || !MaskValue.Equals(ZPLForgeDefaults.Elements.QrCode.MaskValue);
    }
}
