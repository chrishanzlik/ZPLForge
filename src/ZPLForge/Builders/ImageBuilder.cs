using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="ImageElement"/> objects.
    /// </summary>
    public sealed class ImageBuilder : ElementBuilderBase<ImageElement, ImageBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBuilder" /> class.
        /// </summary>
        internal ImageBuilder()
        {

        }

        /// <summary>
        /// Creates an image from raw bitmap data.
        /// </summary>
        /// <param name="compressionType">Images compression type.</param>
        /// <param name="binaryByteCount">Total binary byte count.</param>
        /// <param name="graphicFieldCount">Total graphic field count.</param>
        /// <param name="bytesPerRow">Bytes per row.</param>
        /// <param name="data">Raw data string.</param>
        /// <returns>The builder instance.</returns>
        public ImageBuilder FromRawDataString(CompressionType compressionType, int? binaryByteCount, int? graphicFieldCount, int? bytesPerRow, string data)
        {
            Context.Compression = compressionType;
            Context.BinaryByteCount = binaryByteCount;
            Context.GraphicFieldCount = graphicFieldCount;
            Context.BytesPerRow = bytesPerRow;
            Context.Content = data;

            return this;
        }

        /// <summary>
        /// Creates an image from raw bitmap data.
        /// </summary>
        /// <param name="binaryByteCount">Total binary byte count.</param>
        /// <param name="graphicFieldCount">Total graphic field count.</param>
        /// <param name="bytesPerRow">Bytes per row.</param>
        /// <param name="data">Raw data string.</param>
        /// <returns>The builder instance.</returns>
        public ImageBuilder FromRawDataString(int? binaryByteCount, int? graphicFieldCount, int? bytesPerRow, string data)
            => FromRawDataString(ZPLForgeDefaults.Elements.Image.Compression, binaryByteCount, graphicFieldCount, bytesPerRow, data);
    }
}
