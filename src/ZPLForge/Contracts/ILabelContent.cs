using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// General element contract
    /// </summary>
    public interface ILabelContent
    {
        /// <summary>
        /// Gets or sets the element-position from the left label edge in dots.
        /// </summary>
        int PositionX { get; set; }

        /// <summary>
        /// Gets or sets the element-position from the top label edge in dots.
        /// </summary>
        int PositionY { get; set; }

        /// <summary>
        /// Gets or sets the field origin.
        /// </summary>
        FieldOrigin FieldOrigin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field colors should be reversed.
        /// </summary>
        bool FieldReversePrint { get; set; }
    }
}
