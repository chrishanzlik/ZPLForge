using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Image contract
    /// </summary>
    public interface IImage : ILabelContent
    {
        CompressionType Compression { get; set; }
        int? BinaryByteCount { get; set; }
        int? GraphicFieldCount { get; set; }
        int? BytesPerRow { get; set; }
        string Content { get; set; }
    }
}
