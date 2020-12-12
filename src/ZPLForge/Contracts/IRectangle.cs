using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Rectangle contract
    /// </summary>
    public interface IRectangle : ILabelContent
    {
        /// <summary>
        /// Gets or sets the rectangle width in dots.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Gets or sets the rectangle height in dots.
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Gets or sets the borders thickness in dots.
        /// </summary>
        int BorderThickness { get; set; }

        /// <summary>
        /// Gets or sets the borders color.
        /// </summary>
        LabelColor BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the corner rounding.
        /// </summary>
        int CornerRounding { get; set; }
    }
}
