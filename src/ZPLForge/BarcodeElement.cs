using System;
using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// To be added.
    /// </summary>
    public class BarcodeElement : LabelContent, IBarcode
    {
        public BarcodeElement()
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

        public string Content { get; set; }
        public BarcodeType BarcodeType { get; set; }
        public Orientation BarcodeOrientation { get; set; }
        public int? Height { get; set; }
        public bool PrintInterpretationLine { get; set; }
        public bool PrintInterpretationLineAboveCode { get; set; }

        public ModuleWidth ModuleWidth { get; set; }
        public BarDistance WideBarToNarrowBar { get; set; }
        public int FieldHeight { get; set; }

        /// <summary>
        /// Only applicable on Code128
        /// </summary>
        public bool UCCCheckDigit { get; set; }

        /// <summary>
        /// Only applicable on UPC-A
        /// </summary>
        public bool PrintCheckDigit { get; set; }

        /// <summary>
        /// Only applicable on Code39
        /// </summary>
        public bool Mod43CheckDigit { get; set; }

        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.BY((int)ModuleWidth, (double)WideBarToNarrowBar, FieldHeight));

            switch (BarcodeType)
            {
                case BarcodeType.Code128:
                    builder.Append(ZPLCommand.BC(BarcodeOrientation, Height, PrintInterpretationLine, PrintInterpretationLineAboveCode, UCCCheckDigit));
                    break;
                case BarcodeType.EAN8:
                    builder.Append(ZPLCommand.B8(BarcodeOrientation, Height, PrintInterpretationLine, PrintInterpretationLineAboveCode));
                    break;
                case BarcodeType.EAN13:
                    builder.Append(ZPLCommand.BE(BarcodeOrientation, Height, PrintInterpretationLine, PrintInterpretationLineAboveCode));
                    break;
                case BarcodeType.UPCA:
                    builder.Append(ZPLCommand.BU(BarcodeOrientation, Height, PrintInterpretationLine, PrintInterpretationLineAboveCode, PrintCheckDigit));
                    break;
                case BarcodeType.UPCE:
                    builder.Append(ZPLCommand.B9(BarcodeOrientation, Height, PrintInterpretationLine, PrintInterpretationLineAboveCode));
                    break;
                case BarcodeType.Code39:
                    builder.Append(ZPLCommand.B3(BarcodeOrientation, Mod43CheckDigit, Height, PrintInterpretationLine, PrintInterpretationLineAboveCode));
                    break;
                default:
                    throw new InvalidOperationException("This barcode type is not supported.");
            }

            builder.Append(ZPLCommand.FD(Content));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
