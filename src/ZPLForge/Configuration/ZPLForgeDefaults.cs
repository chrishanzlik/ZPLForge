using ZPLForge.Common;

namespace ZPLForge.Configuration
{
    /// <summary>
    /// Contains all default values consumed by labels and elements.
    /// </summary>
    public static class ZPLForgeDefaults
    {
        public static class Elements
        {
            public static int PositionX = 0;
            public static int PositionY = 0;
            public static FieldOrigin FieldOrigin = FieldOrigin.Left;
            public static bool FieldReversePrint = false;

            public static class Label
            {
                public static int BlackMarkOffset = 0;
                public static bool ReversePrintingColors = false;
                public static int Quantity = 1;
                public static ZebraEncoding Encoding = ZebraEncoding.UTF8;
                public static PrintSpeed PrintSpeed = PrintSpeed.TwoInchesPerSecond;
                public static SlewSpeed SlewSpeed = SlewSpeed.SixInchesPerSecond;
                public static BackfeedSpeed BackfeedSpeed = BackfeedSpeed.TwoInchesPerSecond;
                public static int PauseAndCutValue = 0;
                public static bool OverridePauseCount = false;
                public static int ReplicatesOfEachSerialNumber = 0;
                public static bool CutOnError = true;
            }

            public static class Text
            {
                public static Orientation FontOrientation = Orientation.Normal;
                public static Font FontStyle = Font.Default;
                public static bool BlockMode = false;
                public static int BlockWidth = 0;
                public static int BlockLines = 1;
                public static int BlockLineSpace = 0;
                public static BlockAlignment BlockAlignment = BlockAlignment.Left;
            }

            public static class Barcode
            {
                public static BarcodeType BarcodeType = BarcodeType.Code128;
                public static Orientation BarcodeOrientation = Orientation.Normal;
                public static bool PrintInterpretationLine = true;
                public static bool PrintInterpretationLineAboveCode = false;
                public static ModuleWidth ModuleWidth = ModuleWidth.Size2;
                public static BarDistance WideBarToNarrowBar = BarDistance.Ratio30;
                public static int FieldHeight = 10;
                public static bool UCCCheckDigit = false;
                public static bool PrintCheckDigit = true;
                public static bool Mod43CheckDigit = false;
            }

            public static class DiagonalLine
            {
                public static int Width = 3;
                public static int Height = 3;
                public static int BorderThickness = 1;
                public static LabelColor BorderColor = LabelColor.Black;
                public static bool InverseLeaningDirection = false;
            }

            public static class Ellipse
            {
                public static int Width = 1;
                public static int Height = 1;
                public static int BorderThickness = 1;
                public static LabelColor BorderColor = LabelColor.Black;
            }

            public static class Rectangle
            {
                public static int Width = 1;
                public static int Height = 1;
                public static int BorderThickness = 1;
                public static LabelColor BorderColor = LabelColor.Black;
                public static int CornerRounding = 0;
            }

            public static class QrCode
            {
                public static QrModel QrModel = QrModel.Version2;
                public static Magnification MagnificationFactor = Magnification.Factor2;
                public static ErrorCorrection ErrorCorrection = ErrorCorrection.HighReliability;
                public static int MaskValue = 7;
            }

            public static class Image
            {
                public static CompressionType Compression = CompressionType.HexASCII;
            }

            public static class Symbol
            {
                public static Orientation FieldOrientation = Orientation.Normal;
            }
        }
    }
}
