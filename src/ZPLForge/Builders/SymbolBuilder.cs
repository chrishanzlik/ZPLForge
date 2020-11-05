using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    public sealed class SymbolBuilder : ElementBuilderBase<SymbolElement, SymbolBuilder>
    {
        internal SymbolBuilder()
        {

        }

        public SymbolBuilder SetSymbol(SymbolKind symbol, int height, int width, Orientation fieldOrientation)
        {
            Context.Content = symbol;
            Context.Height = height;
            Context.Width = width;
            Context.FieldOrientation = fieldOrientation;

            return this;
        }

        public SymbolBuilder SetSymbol(SymbolKind symbol, int height, int width)
            => SetSymbol(symbol, height, width, ZPLForgeDefaults.Elements.Symbol.FieldOrientation);
    }
}
