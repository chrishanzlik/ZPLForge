using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="DiagonalLineElement"/> objects.
    /// </summary>
    public sealed class DiagonalLineBuilder : ElementBuilderBase<DiagonalLineElement, DiagonalLineBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalLineBuilder" /> class.
        /// </summary>
        internal DiagonalLineBuilder()
        {

        }

        /// <summary>
        /// Set the total dimensions of the <see cref="DiagonalLineElement"/>.
        /// </summary>
        /// <param name="width">Width in dots.</param>
        /// <param name="height">Height in dots.</param>
        /// <returns>The builder instance.</returns>
        public DiagonalLineBuilder SetDimensions(int width, int height)
        {
            Context.Width = width;
            Context.Height = height;

            return this;
        }

        /// <summary>
        /// Sets the border / line of the <see cref="DiagonalLineElement"/>.
        /// </summary>
        /// <param name="color">Border color.</param>
        /// <param name="thickness">Thickness of the line.</param>
        /// <returns>The builder instance.</returns>
        public DiagonalLineBuilder SetBorder(LabelColor color, int thickness)
        {
            Context.BorderColor = color;
            Context.BorderThickness = thickness;

            return this;
        }

        /// <summary>
        /// Sets the border / line of the <see cref="DiagonalLineElement"/>.
        /// </summary>
        /// <param name="thickness">Thickness of the line.</param>
        /// <returns>The builder instance.</returns>
        public DiagonalLineBuilder SetBorder(int thickness)
            => SetBorder(ZPLForgeDefaults.Elements.DiagonalLine.BorderColor, thickness);

        /// <summary>
        /// Swaps the direction of the line.
        /// </summary>
        /// <returns>The builder instance.</returns>
        public DiagonalLineBuilder InverseLeaningDirection()
        {
            Context.InverseLeaningDirection = true;

            return this;
        }
    }
}
