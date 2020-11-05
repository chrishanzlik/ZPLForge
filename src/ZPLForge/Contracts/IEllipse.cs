using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Ellipse contract
    /// </summary>
    public interface IEllipse : ILabelContent
    {
        int Width { get; set; }
        int Height { get; set; }
        int BorderThickness { get; set; }
        LabelColor BorderColor { get; set; }
    }
}
