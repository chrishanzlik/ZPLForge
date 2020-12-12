using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// Represents a diagonal line on the <see cref="Label"/>.
    /// </summary>
    public class DiagonalLineElement : LabelContent, IDiagonalLine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalLineElement" /> class with default values from <see cref="ZPLForgeDefaults.Elements.DiagonalLine"/>.
        /// </summary>
        public DiagonalLineElement()
        {
            Width = ZPLForgeDefaults.Elements.DiagonalLine.Width;
            Height = ZPLForgeDefaults.Elements.DiagonalLine.Height;
            BorderThickness = ZPLForgeDefaults.Elements.DiagonalLine.BorderThickness;
            BorderColor = ZPLForgeDefaults.Elements.DiagonalLine.BorderColor;
            InverseLeaningDirection = ZPLForgeDefaults.Elements.DiagonalLine.InverseLeaningDirection;
        }

        /// <inheritdoc />
        public int Width { get; set; }

        /// <inheritdoc />
        public int Height { get; set; }

        /// <inheritdoc />
        public int BorderThickness { get; set; }

        /// <inheritdoc />
        public LabelColor BorderColor { get; set; }

        /// <inheritdoc />
        public bool InverseLeaningDirection { get; set; }

        /// <inheritdoc />
        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.GD(Width, Height, BorderThickness, BorderColor, InverseLeaningDirection));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
