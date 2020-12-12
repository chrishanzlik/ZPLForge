using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Diagonal line contract
    /// </summary>
    public interface IDiagonalLine : ILabelContent
    {
        /// <summary>
        /// Gets or sets the width in dots.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Gets or sets the height in dots.
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Gets or sets the border thickness in dots.
        /// </summary>
        int BorderThickness { get; set; }

        /// <summary>
        /// Gets or sets the border-color.
        /// </summary>
        LabelColor BorderColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the line should be printed from bottom
        /// left to top right (default) or from top right to bottom left (inversed)
        /// </summary>
        bool InverseLeaningDirection { get; set; }
    }
}
