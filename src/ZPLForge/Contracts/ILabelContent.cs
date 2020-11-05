using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// General element contract
    /// </summary>
    public interface ILabelContent
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        FieldOrigin FieldOrigin { get; set; }
        bool FieldReversePrint { get; set; }
    }
}
