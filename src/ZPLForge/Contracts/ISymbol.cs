using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Symbol contract.
    /// </summary>
    public interface ISymbol : ILabelContent
    {
        /// <summary>
        /// Gets or sets the field orientation.
        /// </summary>
        Orientation FieldOrientation { get; set; }

        /// <summary>
        /// Gets or sets the symbol height in dots.
        /// </summary>
        int? Height { get; set; }

        /// <summary>
        /// Gets or sets the symbol width in dots.
        /// </summary>
        int? Width { get; set; }

        /// <summary>
        /// Gets or sets the kind of the symbol.
        /// </summary>
        SymbolKind? Content { get; set; }
    }
}
