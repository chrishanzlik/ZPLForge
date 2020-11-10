using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    public sealed class EllipseBuilder : ElementBuilderBase<EllipseElement, EllipseBuilder>
    {
        internal EllipseBuilder()
        {

        }

        public EllipseBuilder SetDimensions(int width, int height)
        {
            Context.Width = width;
            Context.Height = height;

            return this;
        }

        public EllipseBuilder SetBorder(LabelColor color, int thickness)
        {
            Context.BorderColor = color;
            Context.BorderThickness = thickness;

            return this;
        }

        public EllipseBuilder SetBorder(int thickness)
            => SetBorder(ZPLForgeDefaults.Elements.Ellipse.BorderColor, thickness);
    }
}
