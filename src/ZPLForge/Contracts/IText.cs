using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Text contract.
    /// </summary>
    public interface IText : ILabelContent
    {
        /// <summary>
        /// Gets or sets the text content.
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// Gets or sets the character height in dots.
        /// </summary>
        int? CharHeight { get; set; }

        /// <summary>
        /// Gets or sets the character width in dots.
        /// </summary>
        int? CharWidth { get; set; }

        /// <summary>
        /// Gets or sets the font orientation.
        /// </summary>
        Orientation FontOrientation { get; set; }

        /// <summary>
        /// Gets or sets the font style.
        /// </summary>
        Font FontStyle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the text should be wrapped inside
        /// a block module
        /// </summary>
        bool BlockMode { get; set; }

        /// <summary>
        /// Gets or sets the block module width. Only recognized when
        /// <see cref="BlockMode"/> is set to true
        /// </summary>
        int BlockWidth { get; set; }

        /// <summary>
        /// Gets or sets the block module lines. Only recognized when
        /// <see cref="BlockMode"/> is set to true
        /// </summary>
        int BlockLines { get; set; }

        /// <summary>
        /// Gets or sets the block module line space. Only recognized when
        /// <see cref="BlockMode"/> is set to true
        /// </summary>
        int BlockLineSpace { get; set; }

        /// <summary>
        /// Gets or sets the block align.
        /// </summary>
        BlockAlignment BlockAlignment { get; set; }
    }
}
