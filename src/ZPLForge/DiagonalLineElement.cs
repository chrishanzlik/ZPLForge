using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// To be added.
    /// </summary>
    public class DiagonalLineElement : LabelContent, IDiagonalLine
    {
        public DiagonalLineElement()
        {
            Width = ZPLForgeDefaults.Elements.DiagonalLine.Width;
            Height = ZPLForgeDefaults.Elements.DiagonalLine.Height;
            BorderThickness = ZPLForgeDefaults.Elements.DiagonalLine.BorderThickness;
            BorderColor = ZPLForgeDefaults.Elements.DiagonalLine.BorderColor;
            InverseLeaningDirection = ZPLForgeDefaults.Elements.DiagonalLine.InverseLeaningDirection;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public int BorderThickness { get; set; }
        public LabelColor BorderColor { get; set; }
        public bool InverseLeaningDirection { get; set; }

        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.GD(Width, Height, BorderThickness, BorderColor, InverseLeaningDirection));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
