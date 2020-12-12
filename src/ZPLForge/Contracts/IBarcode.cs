using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Generic barcode contract
    /// </summary>
    public interface IBarcode : ILabelContent
    {
        /// <summary>
        /// Gets or sets the barcodes content.
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// Gets or sets the type of the barcode. E.g. Code128
        /// </summary>

        BarcodeType BarcodeType { get; set; }

        /// <summary>
        /// Gets or sets the barcode orientation.
        /// </summary>

        Orientation BarcodeOrientation { get; set; }

        /// <summary>
        /// Gets or sets the barcode height in dots.
        /// </summary>

        int? Height { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the barcode content should be added as text. By default below the barcode.
        /// </summary>
        bool PrintInterpretationLine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the interpretation line should be printent above the barcode instead of below.
        /// </summary>
        bool PrintInterpretationLineAboveCode { get; set; }

        /// <summary>
        /// Gets or sets the module with of the barce. (Related to the ^BY command)
        /// </summary>
        ModuleWidth ModuleWidth { get; set; }

        /// <summary>
        /// Gets or sets the wide bar to narrow bar. (Related to the ^BY command)
        /// Has no effect on fixed ratio barcodes.
        /// </summary>
        BarDistance WideBarToNarrowBar { get; set; }

        /// <summary>
        /// Gets or sets the field height of the barcode module. (Related to the ^BY command)
        /// </summary>
        int FieldHeight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wheter the UCC check digit should be used. (Related to the ^BY command)
        /// </summary>
        bool UCCCheckDigit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wheter to print the check digit or not. Only applicable on UPC-A
        /// </summary>
        bool PrintCheckDigit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wheter to use modulo 43 check digit. Only applicable on Code39
        /// </summary>
        bool Mod43CheckDigit { get; set; }
    }
}
