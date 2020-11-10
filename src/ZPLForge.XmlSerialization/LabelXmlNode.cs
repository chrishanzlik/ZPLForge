using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using ZPLForge.Contracts;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization
{
    [Serializable]
    [XmlRoot("Label")]
    public class LabelXmlNode : ILabel, IDefaultSerializable
    {
        public LabelXmlNode()
        {
            BlackMarkOffset = ZPLForgeDefaults.Elements.Label.BlackMarkOffset;
            ReversePrintingColors = ZPLForgeDefaults.Elements.Label.ReversePrintingColors;
            Quantity = ZPLForgeDefaults.Elements.Label.Quantity;
            Encoding = ZPLForgeDefaults.Elements.Label.Encoding;
            PrintSpeed = ZPLForgeDefaults.Elements.Label.PrintSpeed;
            SlewSpeed = ZPLForgeDefaults.Elements.Label.SlewSpeed;
            BackfeedSpeed = ZPLForgeDefaults.Elements.Label.BackfeedSpeed;
            PauseAndCutValue = ZPLForgeDefaults.Elements.Label.PauseAndCutValue;
            OverridePauseCount = ZPLForgeDefaults.Elements.Label.OverridePauseCount;
            ReplicatesOfEachSerialNumber = ZPLForgeDefaults.Elements.Label.ReplicatesOfEachSerialNumber;
            CutOnError = ZPLForgeDefaults.Elements.Label.CutOnError;
            PositionX = ZPLForgeDefaults.Elements.Label.PositionX;
            PositionY = ZPLForgeDefaults.Elements.Label.PositionY;

            Content = new List<ILabelContent>();
        }

        bool IDefaultSerializable.SerializeDefaults { get; set; }
        protected bool SerializeDefaults => (this as IDefaultSerializable).SerializeDefaults;


        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement]
        public int PositionX { get; set; }

        [XmlElement]
        public int PositionY { get; set; }

        [XmlElement]
        public int Quantity { get; set; }

        [XmlElement]
        public int? PrintWidth { get; set; }

        [XmlElement]
        public int? MediaLength { get; set; }

        [XmlElement]
        public int BlackMarkOffset { get; set; }

        [XmlElement]
        public bool ReversePrintingColors { get; set; }

        [XmlElement]
        public bool OverridePauseCount { get; set; }

        [XmlElement]
        public MediaTracking? MediaTracking { get; set; }

        [XmlElement]
        public PrintMode? PrintMode { get; set; }

        [XmlElement]
        public ZebraEncoding Encoding { get; set; }

        [XmlIgnore]
        public PrintSpeed PrintSpeed { get; set; }

        [XmlElement("PrintSpeed")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PrintSpeedString
        {
            get => ((int)PrintSpeed).ToString();
            set => PrintSpeed = (PrintSpeed)int.Parse(value);
        }

        [XmlIgnore]
        public SlewSpeed SlewSpeed { get; set; }

        [XmlElement("SlewSpeed")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SlewSpeedString
        {
            get => ((int)SlewSpeed).ToString();
            set => SlewSpeed = (SlewSpeed)int.Parse(value);
        }

        [XmlIgnore]
        public BackfeedSpeed BackfeedSpeed { get; set; }

        [XmlElement("BackfeedSpeed")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackfeedSpeedString
        {
            get => ((int)BackfeedSpeed).ToString();
            set => BackfeedSpeed = (BackfeedSpeed)int.Parse(value);
        }

        [XmlElement]
        public MediaType? MediaType { get; set; }

        [XmlElement]
        public int PauseAndCutValue { get; set; }

        [XmlElement]
        public int ReplicatesOfEachSerialNumber { get; set; }

        [XmlElement]
        public bool CutOnError { get; set; }

        [XmlElement]
        public int? MediaDarknessLevel { get; set; }

        [XmlIgnore]
        public List<ILabelContent> Content { get; set; }
        
        [XmlIgnore]
        private ElementNodeList elementNodes;

        [XmlElement("Content")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ElementNodeList ElementNodes
        {
            get => elementNodes ?? (elementNodes = new ElementNodeList(Content));
            set => Content = value.Cast<ILabelContent>().ToList();
        }




        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePauseAndCutValue() =>
            SerializeDefaults
            || !PauseAndCutValue.Equals(ZPLForgeDefaults.Elements.Label.PauseAndCutValue);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeMediaLength() =>
            SerializeDefaults
            || MediaLength.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeMediaTracking() =>
            SerializeDefaults
            || MediaTracking.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePrintWidth() =>
            SerializeDefaults
            || PrintWidth.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePrintMode() =>
            SerializeDefaults
            || PrintMode.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeMediaDarknessLevel() =>
            SerializeDefaults
            || MediaDarknessLevel.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBackfeedSpeedString() =>
            SerializeDefaults
            || !BackfeedSpeed.Equals(ZPLForgeDefaults.Elements.Label.BackfeedSpeed);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeSlewSpeedString() =>
            SerializeDefaults
            || !SlewSpeed.Equals(ZPLForgeDefaults.Elements.Label.SlewSpeed);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePrintSpeedString() =>
            SerializeDefaults
            || !PrintSpeed.Equals(ZPLForgeDefaults.Elements.Label.PrintSpeed);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeReversePrintingColors() =>
            SerializeDefaults
            || !ReversePrintingColors.Equals(ZPLForgeDefaults.Elements.Label.ReversePrintingColors);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeEncoding() =>
            SerializeDefaults
            || !Encoding.Equals(ZPLForgeDefaults.Elements.Label.Encoding);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeQuantity() =>
            SerializeDefaults
            || !Quantity.Equals(ZPLForgeDefaults.Elements.Label.Quantity);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBlackMarkOffset() =>
            SerializeDefaults
            || !BlackMarkOffset.Equals(ZPLForgeDefaults.Elements.Label.BlackMarkOffset);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeMediaType() =>
            SerializeDefaults
            || MediaType.HasValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeOverridePauseCount() =>
            SerializeDefaults
            || !OverridePauseCount.Equals(ZPLForgeDefaults.Elements.Label.OverridePauseCount);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeReplicatesOfEachSerialNumber() =>
            SerializeDefaults
            || !ReplicatesOfEachSerialNumber.Equals(ZPLForgeDefaults.Elements.Label.ReplicatesOfEachSerialNumber);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeCutOnError() =>
            SerializeDefaults
            || !CutOnError.Equals(ZPLForgeDefaults.Elements.Label.CutOnError);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePositionX() =>
            SerializeDefaults
            || !PositionX.Equals(ZPLForgeDefaults.Elements.Label.PositionX);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePositionY() =>
            SerializeDefaults
            || !PositionY.Equals(ZPLForgeDefaults.Elements.Label.PositionY);
    }
}
