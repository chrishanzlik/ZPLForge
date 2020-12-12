using System;
using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// Represents a barcode on the <see cref="Label"/>.
    /// </summary>
    public class BarcodeElement : LabelContent, IBarcode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeElement" /> class with default values from <see cref="ZPLForgeDefaults.Elements.Barcode"/>.
        /// </summary>
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

        /// <inheritdoc />
        public string Content { get; set; }

        /// <inheritdoc />
        public BarcodeType BarcodeType { get; set; }

        /// <inheritdoc />
        public Orientation BarcodeOrientation { get; set; }

        /// <inheritdoc />
        public int? Height { get; set; }

        /// <inheritdoc />
        public bool PrintInterpretationLine { get; set; }

        /// <inheritdoc />
        public bool PrintInterpretationLineAboveCode { get; set; }

        /// <inheritdoc />
        public ModuleWidth ModuleWidth { get; set; }

        /// <inheritdoc />
        public BarDistance WideBarToNarrowBar { get; set; }

        /// <inheritdoc />
        public int FieldHeight { get; set; }

        /// <inheritdoc />
        public bool UCCCheckDigit { get; set; }

        /// <inheritdoc />
        public bool PrintCheckDigit { get; set; }

        /// <inheritdoc />
        public bool Mod43CheckDigit { get; set; }

        /// <inheritdoc />
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
