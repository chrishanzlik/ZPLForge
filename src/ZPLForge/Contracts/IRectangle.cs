using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Rectangle contract
    /// </summary>
    public interface IRectangle : ILabelContent
    {
        int Width { get; set; }
        int Height { get; set; }
        int BorderThickness { get; set; }
        LabelColor BorderColor { get; set; }
        int CornerRounding { get; set; }
    }
}
