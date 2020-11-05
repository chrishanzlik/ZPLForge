using ZPLForge.Builders.Abstractions;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    public sealed class DiagonalLineBuilder : ElementBuilderBase<DiagonalLineElement, DiagonalLineBuilder>
    {
        internal DiagonalLineBuilder()
        {

        }

        public DiagonalLineBuilder SetDimensions(int width, int height)
        {
            Context.Width = width;
            Context.Height = height;

            return this;
        }

        public DiagonalLineBuilder SetBorder(LabelColor color, int thickness)
        {
            Context.BorderColor = color;
            Context.BorderThickness = thickness;

            return this;
        }

        public DiagonalLineBuilder SetBorder(int thickness)
            => SetBorder(ZPLForgeDefaults.Elements.DiagonalLine.BorderColor, thickness);

        public DiagonalLineBuilder InverseLeaningDirection()
        {
            Context.InverseLeaningDirection = true;

            return this;
        }
    }
}
