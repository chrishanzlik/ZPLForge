using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Image contract
    /// </summary>
    public interface IImage : ILabelContent
    {
        /// <summary>
        /// Gets or sets images compression type.
        /// </summary>
        CompressionType Compression { get; set; }

        /// <summary>
        /// Gets or sets the amount of bytes.
        /// </summary>
        int? BinaryByteCount { get; set; }

        /// <summary>
        /// Gets or sets the amount of graphical fields.
        /// </summary>
        int? GraphicFieldCount { get; set; }

        /// <summary>
        /// Gets or sets the byte count per row.
        /// </summary>
        int? BytesPerRow { get; set; }

        /// <summary>
        /// Gets or sets the raw image content.
        /// </summary>
        string Content { get; set; }
    }
}
