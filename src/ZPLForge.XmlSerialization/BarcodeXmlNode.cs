using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    [XmlType(TypeName = "Barcode")]
    public class BarcodeXmlNode : LabelContentXmlNode, IBarcode
    {
        public BarcodeXmlNode()
        {
            BarcodeType = ZPLForgeDefaults.Elements.Barcode.BarcodeType;
            BarcodeOrientation = ZPLForgeDefaults.Elements.Barcode.BarcodeOrientation;
            PrintInterpretationLine = ZPLForgeDefaults.Elements.Barcode.PrintInterpretationLine;
            PrintInterpretationLineAboveCode = ZPLForgeDefaults.Elements.Barcode.PrintInterpretationLineAboveCode;
            ModuleWidth = ZPLForgeDefaults.Elements.Barcode.ModuleWidth;
            WideBarToNarrowBar = ZPLForgeDefaults.Elements.Barcode.WideBarToNarrowBar;
            FieldHeight = ZPLForgeDefaults.Elements.Barcode.FieldHeight;
            UCCCheckDigit = ZPLForgeDefaults.Elements.Barcode.UCCCheckDigit;
            PrintCheckDigit = ZPLForgeDefaults.Elements.Barcode.PrintCheckDigit;
            Mod43CheckDigit = ZPLForgeDefaults.Elements.Barcode.Mod43CheckDigit;
        }


        [XmlElement]
        public string Content { get; set; }

        [XmlElement]
        public BarcodeType BarcodeType { get; set; }

        [XmlElement]
        public Orientation BarcodeOrientation { get; set; }

        [XmlElement]
        public int? Height { get; set; }

        [XmlElement]
        public bool PrintInterpretationLine { get; set; }

        [XmlElement]
        public bool PrintInterpretationLineAboveCode { get; set; }

        [XmlIgnore]
        public ModuleWidth ModuleWidth { get; set; }
        [XmlElement("ModuleWidth")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ModuleWidthString
        {
            get => ((int)ModuleWidth).ToString();
            set => ModuleWidth = (ModuleWidth)int.Parse(value);
        }


        [XmlIgnore]
        public BarDistance WideBarToNarrowBar { get; set; }

        [XmlElement("WideBarToNarrowBar")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string WideBarToNarrowBarString
        {
            get => WideBarToNarrowBar.Ratio.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
            set => WideBarToNarrowBar = BarDistance.Parse(value);
        }

        [XmlElement]
        public int FieldHeight { get; set; }

        [XmlElement]
        public bool UCCCheckDigit { get; set; }

        [XmlElement]
        public bool PrintCheckDigit { get; set; }

        [XmlElement]
        public bool Mod43CheckDigit { get; set; }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBarcodeType() =>
            SerializeDefaults
            || !BarcodeType.Equals(ZPLForgeDefaults.Elements.Barcode.BarcodeType);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBarcodeOrientation() =>
            SerializeDefaults 
            || !BarcodeOrientation.Equals(ZPLForgeDefaults.Elements.Barcode.BarcodeOrientation);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePrintInterpretationLine() =>
            SerializeDefaults
            || !PrintInterpretationLine.Equals(ZPLForgeDefaults.Elements.Barcode.PrintInterpretationLine);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePrintInterpretationLineAboveCode() =>
            SerializeDefaults
            || !PrintInterpretationLineAboveCode.Equals(ZPLForgeDefaults.Elements.Barcode.PrintInterpretationLineAboveCode);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeModuleWidthString() =>
            SerializeDefaults
            || !ModuleWidth.Equals(ZPLForgeDefaults.Elements.Barcode.ModuleWidth);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeHeight() =>
            SerializeDefaults
            || Height.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeUCCCheckDigit() =>
            SerializeDefaults
            || !UCCCheckDigit.Equals(ZPLForgeDefaults.Elements.Barcode.UCCCheckDigit);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFieldHeight() =>
            SerializeDefaults
            || !FieldHeight.Equals(ZPLForgeDefaults.Elements.Barcode.FieldHeight);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeWideBarToNarrowBarString() =>
            SerializeDefaults
            || !WideBarToNarrowBar.Equals(ZPLForgeDefaults.Elements.Barcode.WideBarToNarrowBar);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePrintCheckDigit() =>
            SerializeDefaults
            || !PrintCheckDigit.Equals(ZPLForgeDefaults.Elements.Barcode.PrintCheckDigit);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeMod43CheckDigit() =>
            SerializeDefaults
            || !Mod43CheckDigit.Equals(ZPLForgeDefaults.Elements.Barcode.Mod43CheckDigit);
    }
}
