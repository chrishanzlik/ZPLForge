using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    public class SymbolElement : LabelContent, ISymbol
    {
        public SymbolElement()
        {
            FieldOrientation = ZPLForgeDefaults.Elements.Symbol.FieldOrientation;
        }

        public Orientation FieldOrientation { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public SymbolKind? Content { get; set; }

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
