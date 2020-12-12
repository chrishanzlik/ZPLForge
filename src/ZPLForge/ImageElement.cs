using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// Represents an image on the <see cref="Label"/>.
    /// </summary>
    public class ImageElement : LabelContent, IImage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageElement" /> class with default values from <see cref="ZPLForgeDefaults.Elements.Image"/>.
        /// </summary>
        public ImageElement()
        {
            Compression = ZPLForgeDefaults.Elements.Image.Compression;
        }

        /// <inheritdoc />
        public CompressionType Compression { get; set; }

        /// <inheritdoc />
        public int? BinaryByteCount { get; set; }

        /// <inheritdoc />
        public int? GraphicFieldCount { get; set; }

        /// <inheritdoc />
        public int? BytesPerRow { get; set; }

        /// <inheritdoc />
        public string Content { get; set; }

        /// <inheritdoc />
        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.GF(Compression, BinaryByteCount, GraphicFieldCount, BytesPerRow, Content));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
