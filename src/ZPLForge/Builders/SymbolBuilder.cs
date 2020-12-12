using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="SymbolElement"/> objects.
    /// </summary>
    public sealed class SymbolBuilder : ElementBuilderBase<SymbolElement, SymbolBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolBuilder" /> class.
        /// </summary>
        internal SymbolBuilder()
        {

        }

        /// <summary>
        /// Sets the symbol for the associated <see cref="SymbolElement"/>.
        /// </summary>
        /// <param name="symbol">What kind of symbol it is.</param>
        /// <param name="height">Height of the symbol in dots.</param>
        /// <param name="width">Width of the symbol in dots.</param>
        /// <param name="fieldOrientation">Symbols field orientation.</param>
        /// <returns>The builder instance.</returns>
        public SymbolBuilder SetSymbol(SymbolKind symbol, int height, int width, Orientation fieldOrientation)
        {
            Context.Content = symbol;
            Context.Height = height;
            Context.Width = width;
            Context.FieldOrientation = fieldOrientation;

            return this;
        }

        /// <summary>
        /// Sets the symbol for the associated <see cref="SymbolElement"/>.
        /// </summary>
        /// <param name="symbol">What kind of symbol it is.</param>
        /// <param name="height">Height of the symbol in dots.</param>
        /// <param name="width">Width of the symbol in dots.</param>
        /// <returns>The builder instance.</returns>
        public SymbolBuilder SetSymbol(SymbolKind symbol, int height, int width)
            => SetSymbol(symbol, height, width, ZPLForgeDefaults.Elements.Symbol.FieldOrientation);
    }
}
