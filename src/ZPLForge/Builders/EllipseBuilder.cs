using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="EllipseElement"/> objects.
    /// </summary>
    public sealed class EllipseBuilder : ElementBuilderBase<EllipseElement, EllipseBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseBuilder" /> class.
        /// </summary>
        internal EllipseBuilder()
        {

        }

        /// <summary>
        /// Sets the dimensions of the ellipse element.
        /// </summary>
        /// <param name="width">Width in dots.</param>
        /// <param name="height">Height in dots.</param>
        /// <returns>The builder instance.</returns>
        public EllipseBuilder SetDimensions(int width, int height)
        {
            Context.Width = width;
            Context.Height = height;

            return this;
        }

        /// <summary>
        /// Sets the border properties of the ellipse element.
        /// </summary>
        /// <param name="color">Color of the drawing line</param>
        /// <param name="thickness">Thickness of the drawing line</param>
        /// <returns>The builder instance.</returns>
        public EllipseBuilder SetBorder(LabelColor color, int thickness)
        {
            Context.BorderColor = color;
            Context.BorderThickness = thickness;

            return this;
        }

        /// <summary>
        /// Sets the border properties of the ellipse element.
        /// </summary>
        /// <param name="thickness">Thickness of the drawing line</param>
        /// <returns>The builder instance.</returns>
        public EllipseBuilder SetBorder(int thickness)
            => SetBorder(ZPLForgeDefaults.Elements.Ellipse.BorderColor, thickness);
    }
}
