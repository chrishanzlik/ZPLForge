using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Diagonal line contract
    /// </summary>
    public interface IDiagonalLine : ILabelContent
    {
        int Width { get; set; }
        int Height { get; set; }
        int BorderThickness { get; set; }
        LabelColor BorderColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the line should be printed from bottom
        /// left to top right (default) or from top right to bottom left (inversed)
        /// </summary>
        bool InverseLeaningDirection { get; set; }
    }
}
