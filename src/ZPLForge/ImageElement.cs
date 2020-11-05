using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    public class ImageElement : LabelContent, IImage
    {
        public ImageElement()
        {
            Compression = ZPLForgeDefaults.Elements.Image.Compression;
        }

        public CompressionType Compression { get; set; }
        public int? BinaryByteCount { get; set; }
        public int? GraphicFieldCount { get; set; }
        public int? BytesPerRow { get; set; }
        public string Content { get; set; }

        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.GF(Compression, BinaryByteCount, GraphicFieldCount, BytesPerRow, Content));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
