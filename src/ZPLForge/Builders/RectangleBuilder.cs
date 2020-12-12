using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="RectangleElement"/> objects.
    /// </summary>
    public sealed class RectangleBuilder : ElementBuilderBase<RectangleElement, RectangleBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleBuilder" /> class.
        /// </summary>
        internal RectangleBuilder()
        {

        }

        /// <summary>
        /// Sets the dimensions of the rectangle element.
        /// </summary>
        /// <param name="width">Width in dots.</param>
        /// <param name="height">Height in dots.</param>
        /// <returns>The builder instance.</returns>
        public RectangleBuilder SetDimensions(int width, int height)
        {
            Context.Width = width;
            Context.Height = height;

            return this;
        }

        /// <summary>
        /// Sets the border properties of the rectangle element.
        /// </summary>
        /// <param name="color">Color of the drawing line.</param>
        /// <param name="thickness">Thickness of the drawing line.</param>
        /// <param name="cornerRounding">Degree of corner rounding.</param>
        /// <returns>The builder instance.</returns>
        public RectangleBuilder SetBorder(LabelColor color, int thickness, int cornerRounding)
        {
            Context.BorderColor = color;
            Context.BorderThickness = thickness;
            Context.CornerRounding = cornerRounding;

            return this;
        }

        /// <summary>
        /// Sets the border properties of the rectangle element.
        /// </summary>
        /// <param name="color">Color of the drawing line.</param>
        /// <param name="thickness">Thickness of the drawing line.</param>
        /// <returns>The builder instance.</returns>
        public RectangleBuilder SetBorder(LabelColor color, int thickness)
            => SetBorder(color, thickness, ZPLForgeDefaults.Elements.Rectangle.CornerRounding);

        /// <summary>
        /// Sets the border properties of the rectangle element.
        /// </summary>
        /// <param name="thickness">Thickness of the drawing line.</param>
        /// <returns>The builder instance.</returns>
        public RectangleBuilder SetBorder(int thickness)
            => SetBorder(ZPLForgeDefaults.Elements.Rectangle.BorderColor, thickness);
    }
}
