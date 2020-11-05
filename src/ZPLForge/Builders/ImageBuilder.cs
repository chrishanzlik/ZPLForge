using ZPLForge.Builders.Abstractions;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    public sealed class ImageBuilder : ElementBuilderBase<ImageElement, ImageBuilder>
    {
        internal ImageBuilder()
        {

        }

        public ImageBuilder FromRawDataString(CompressionType compressionType, int? binaryByteCount, int? graphicFieldCount, int? bytesPerRow, string data)
        {
            Context.Compression = compressionType;
            Context.BinaryByteCount = binaryByteCount;
            Context.GraphicFieldCount = graphicFieldCount;
            Context.BytesPerRow = bytesPerRow;
            Context.Content = data;

            return this;
        }

        public ImageBuilder FromRawDataString(int? binaryByteCount, int? graphicFieldCount, int? bytesPerRow, string data)
            => FromRawDataString(ZPLForgeDefaults.Elements.Image.Compression, binaryByteCount, graphicFieldCount, bytesPerRow, data);
    }
}
