using ZPLForge.Common;

namespace ZPLForge.Commands
{
    public sealed partial class ZPLCommand
    {
        public static ZPLCommand A(Font font, Orientation orientation, int? charHeight, int? charWidth)
            => new ZPLCommand("^A" + (char)font, (char)orientation, charHeight, charWidth);

        public static ZPLCommand B3(Orientation orientation, bool mod43checkDigit, int? height, bool printInterpretationLine, bool printInterpretationLineAbove)
            => new ZPLCommand("^B3", (char)orientation, mod43checkDigit ? 'Y' : 'N', height, printInterpretationLine ? 'Y' : 'N', printInterpretationLineAbove ? 'Y' : 'N');

        public static ZPLCommand B8(Orientation orientation, int? height, bool printInterpretationLine, bool printInterpretationLineAbove)
            => new ZPLCommand("^B8", (char)orientation, height, printInterpretationLine ? 'Y' : 'N', printInterpretationLineAbove ? 'Y' : 'N');

        public static ZPLCommand B9(Orientation orientation, int? height, bool printInterpretationLine, bool printInterpretationLineAbove)
            => new ZPLCommand("^B9", (char)orientation, height, printInterpretationLine ? 'Y' : 'N', printInterpretationLineAbove ? 'Y' : 'N');

        public static ZPLCommand BC(Orientation orientation, int? height, bool printInterpretationLine, bool printInterpretationLineAbove, bool UCCCheckDigit)
            => new ZPLCommand("^BC", (char)orientation, height, printInterpretationLine ? 'Y' : 'N', printInterpretationLineAbove ? 'Y' : 'N', UCCCheckDigit ? 'Y' : 'N');

        public static ZPLCommand BE(Orientation orientation, int? height, bool printInterpretationLine, bool printInterpretationLineAbove)
            => new ZPLCommand("^BE", (char)orientation, height, printInterpretationLine ? 'Y' : 'N', printInterpretationLineAbove ? 'Y' : 'N');

        public static ZPLCommand BU(Orientation orientation, int? height, bool printInterpretationLine, bool printInterpretationLineAbove, bool printCheckDigit)
            => new ZPLCommand("^BU", (char)orientation, height, printInterpretationLine ? 'Y' : 'N', printInterpretationLineAbove ? 'Y' : 'N', printCheckDigit ? 'Y' : 'N');

        public static ZPLCommand BQ(int qrVersion, int magnificationFactor, ErrorCorrection errorCorrection, int maskValue)
            => new ZPLCommand("^BQ", 'N', qrVersion, magnificationFactor, (char)errorCorrection, maskValue);

        public static ZPLCommand BY(int width, double wideToNarrow, int height)
            => new ZPLCommand("^BY", width, wideToNarrow.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture), height);

        public static ZPLCommand CI(ZebraEncoding encoding)
            => new ZPLCommand("^CI", (int)encoding);

        public static ZPLCommand FB(int width, int lines, int spaceBetweenLines, BlockAlignment align)
            => new ZPLCommand("^FB", width, lines, spaceBetweenLines, (char)align);

        public static ZPLCommand FD(string data)
            => new ZPLCommand("^FD", data);

        public static ZPLCommand FDQA(string data)
            => new ZPLCommand("^FDQA,", data);

        public static ZPLCommand FO(int x, int y, FieldOrigin align)
            => new ZPLCommand("^FO", x, y, (int)align);

        public static ZPLCommand FR()
            => new ZPLCommand("^FR");

        public static ZPLCommand FS()
            => new ZPLCommand("^FS");

        public static ZPLCommand GB(int width, int height, int borderThickness, LabelColor lineColor, int cornerRounding)
            => new ZPLCommand("^GB", width, height, borderThickness, (char)lineColor, cornerRounding);

        public static ZPLCommand GD(int width, int height, int borderThickness, LabelColor lineColor, bool inverseDirection = false)
            => new ZPLCommand("^GD", width, height, borderThickness, (char)lineColor, inverseDirection ? 'L' : 'R');

        public static ZPLCommand GE(int width, int height, int borderThickness, LabelColor lineColor)
            => new ZPLCommand("^GE", width, height, borderThickness, (char)lineColor);

        public static ZPLCommand GF(CompressionType type, int? binaryByteCount, int? graphicFieldCount, int? bytesPerRow, string data)
            => new ZPLCommand("^GF", (char)type, binaryByteCount, graphicFieldCount, bytesPerRow, data);

        public static ZPLCommand GS(Orientation fieldOrientation, int? height, int? width)
            => new ZPLCommand("^GS", (char)fieldOrientation, height, width);

        public static ZPLCommand LH(int positionX, int positionY)
            => new ZPLCommand("^LH", positionX, positionY);

        public static ZPLCommand LL(int length)
            => new ZPLCommand("^LL", length);

        public static ZPLCommand LR(bool reversePrint)
            => new ZPLCommand("^LR", reversePrint ? 'Y' : 'N');

        public static ZPLCommand MD(int darknessLevel)
            => new ZPLCommand("^MD", darknessLevel);

        public static ZPLCommand MM(PrintMode printMode)
            => new ZPLCommand("^MM", (char)printMode);

        public static ZPLCommand MMT()
            => new ZPLCommand("^MMT");

        public static ZPLCommand MN(MediaTracking mediaTracking, int blackMarkOffset)
            => new ZPLCommand("^MN", (char)mediaTracking, blackMarkOffset);

        public static ZPLCommand MT(MediaType type)
            => new ZPLCommand("^MT", (char)type);

        public static ZPLCommand PQ(int quantity, int pauseAndCutTime, int replicatesOfEachSerialNumber, bool overridePauseCount, bool cutOnError)
            => new ZPLCommand("^PQ", quantity, pauseAndCutTime, replicatesOfEachSerialNumber, overridePauseCount ? 'Y' : 'N', cutOnError ? 'Y' : 'N');

        public static ZPLCommand PR(PrintSpeed speed, SlewSpeed slew, BackfeedSpeed backfeed)
            => new ZPLCommand("^PR", (int)speed, (int)slew, (int)backfeed);

        public static ZPLCommand PW(int width)
            => new ZPLCommand("^PW", width);

        public static ZPLCommand XA()
            => new ZPLCommand("^XA");

        public static ZPLCommand XZ()
            => new ZPLCommand("^XZ");
    }
}
