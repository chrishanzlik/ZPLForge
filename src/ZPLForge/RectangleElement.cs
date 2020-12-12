using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// Represents a rectangle on the <see cref="Label"/>.
    /// </summary>
    public class RectangleElement : LabelContent, IRectangle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleElement" /> class with default values from <see cref="ZPLForgeDefaults.Elements.Rectangle"/>.
        /// </summary>
        public RectangleElement()
        {
            Width = ZPLForgeDefaults.Elements.Rectangle.Width;
            Height = ZPLForgeDefaults.Elements.Rectangle.Height;
            BorderThickness = ZPLForgeDefaults.Elements.Rectangle.BorderThickness;
            BorderColor = ZPLForgeDefaults.Elements.Rectangle.BorderColor;
            CornerRounding = ZPLForgeDefaults.Elements.Rectangle.CornerRounding;
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
        public int CornerRounding { get; set; }


        /// <inheritdoc />
        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.GB(Width, Height, BorderThickness, BorderColor, CornerRounding));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
