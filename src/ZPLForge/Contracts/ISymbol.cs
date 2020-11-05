using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    public interface ISymbol : ILabelContent
    {
        Orientation FieldOrientation { get; set; }

        int? Height { get; set; }

        int? Width { get; set; }

        SymbolKind? Content { get; set; }
    }
}
