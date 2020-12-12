using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// Represents a ellipse on the <see cref="Label"/>.
    /// </summary>
    public class EllipseElement : LabelContent, IEllipse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseElement" /> class with default values from <see cref="ZPLForgeDefaults.Elements.Ellipse"/>.
        /// </summary>
        public EllipseElement()
        {
            Width = ZPLForgeDefaults.Elements.Ellipse.Width;
            Height = ZPLForgeDefaults.Elements.Ellipse.Height;
            BorderThickness = ZPLForgeDefaults.Elements.Ellipse.BorderThickness;
            BorderColor = ZPLForgeDefaults.Elements.Ellipse.BorderColor;
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
        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.GE(Width, Height, BorderThickness, BorderColor));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
