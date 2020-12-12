using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// Represents a symbol on the <see cref="Label"/>.
    /// </summary>
    public class SymbolElement : LabelContent, ISymbol
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolElement" /> class with default values from <see cref="ZPLForgeDefaults.Elements.Symbol"/>.
        /// </summary>
        public SymbolElement()
        {
            FieldOrientation = ZPLForgeDefaults.Elements.Symbol.FieldOrientation;
        }

        /// <inheritdoc />
        public Orientation FieldOrientation { get; set; }

        /// <inheritdoc />
        public int? Height { get; set; }

        /// <inheritdoc />
        public int? Width { get; set; }

        /// <inheritdoc />
        public SymbolKind? Content { get; set; }


        /// <inheritdoc />
        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.GS(FieldOrientation, Height, Width));
            builder.Append(ZPLCommand.FD((Content.HasValue ? (char)Content : default).ToString()));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
