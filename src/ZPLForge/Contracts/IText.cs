using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    public interface IText : ILabelContent
    {
        string Content { get; set; }
        int? CharHeight { get; set; }
        int? CharWidth { get; set; }
        Orientation FontOrientation { get; set; }
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

        BlockAlignment BlockAlignment { get; set; }
    }
}
