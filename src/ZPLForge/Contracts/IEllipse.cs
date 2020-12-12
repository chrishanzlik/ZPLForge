using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Ellipse contract
    /// </summary>
    public interface IEllipse : ILabelContent
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
        /// Gets or sets the borders thickness in dots.
        /// </summary>
        int BorderThickness { get; set; }

        /// <summary>
        /// Gets or sets the borders color.
        /// </summary>
        LabelColor BorderColor { get; set; }
    }
}
