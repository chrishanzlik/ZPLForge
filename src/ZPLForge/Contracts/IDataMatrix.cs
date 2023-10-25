using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// QR Code contract
    /// </summary>
    public interface IDataMatrix : ILabelContent
    {
        string Content { get; set; }

        /// <summary>
        /// Accepted Values: 1 to the width of the label
        /// The individual elements are square — this parameter specifies both
        /// module and row height.If this parameter is zero (or not given), the h
        /// parameter (bar height) in ^BY is used as the approximate symbol height
        /// </summary>
        int DimensionalHeight { get; set; }

        /// <summary>
        /// Gets or sets the reliability level of the DataMatrix Code
        /// </summary>
        DataMatrixErrorCorrection ErrorCorrection { get; set; }

        /// <summary>
        /// format ID (0 to 6) — not used with quality set at 200
        /// </summary>
        DataMatrixFormat Format { get; set; }

        char EscapeCharacter { get; set; }
        DataMatrixAspectRatio AspectRatio { get; set; }

        int ColumnsToEncode { get; set; }
        int RowsToEndode { get; set; }
    }
}
