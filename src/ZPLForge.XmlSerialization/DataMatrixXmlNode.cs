using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    [XmlType("DataMatrix")]
    public class DataMatrixXmlNode : LabelContentXmlNode, IDataMatrix
    {
        public DataMatrixXmlNode()
        {
            AspectRatio = ZPLForgeDefaults.Elements.DataMatrix.AspectRatio;
            Format = ZPLForgeDefaults.Elements.DataMatrix.Format;
            ErrorCorrection = ZPLForgeDefaults.Elements.DataMatrix.ErrorCorrection;
            EscapeCharacter = ZPLForgeDefaults.Elements.DataMatrix.EscapeCharacter;
        }

        
        [XmlElement]
        public string Content { get; set; }

        [XmlElement]
        public int DimensionalHeight { get; set; }

        [XmlElement]
        public DataMatrixErrorCorrection ErrorCorrection { get; set; }

        [XmlElement]
        public DataMatrixFormat Format { get; set; }

        [XmlElement]
        public char EscapeCharacter { get; set; }

        [XmlElement]
        public DataMatrixAspectRatio AspectRatio { get; set; }

        [XmlElement]
        public int ColumnsToEncode { get; set; }

        [XmlElement]
        public int RowsToEndode { get; set; }


        #region Should?
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeDimensionalHeight() =>
            SerializeDefaults
            || !DimensionalHeight.Equals(0);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeColumnsToEncode() =>
            SerializeDefaults
            || !ColumnsToEncode.Equals(0);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeRowsToEndode() =>
            SerializeDefaults
            || !RowsToEndode.Equals(0);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeAspectRatio() =>
            SerializeDefaults
            || !AspectRatio.Equals(ZPLForgeDefaults.Elements.DataMatrix.AspectRatio);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFormat() =>
            SerializeDefaults
            || !Format.Equals(ZPLForgeDefaults.Elements.DataMatrix.Format);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeErrorCorrection() =>
            SerializeDefaults
            || !ErrorCorrection.Equals(ZPLForgeDefaults.Elements.DataMatrix.ErrorCorrection);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeEscapeCharacter() =>
            SerializeDefaults
            || !EscapeCharacter.Equals(ZPLForgeDefaults.Elements.DataMatrix.EscapeCharacter);
        #endregion
    }
}
