using ZPLForge.Builders.Abstractions;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    public sealed class RectangleBuilder : ElementBuilderBase<RectangleElement, RectangleBuilder>
    {
        internal RectangleBuilder()
        {

        }

        public RectangleBuilder SetDimensions(int width, int height)
        {
            Context.Width = width;
            Context.Height = height;

            return this;
        }

        public RectangleBuilder SetBorder(LabelColor color, int thickness, int cornerRounding)
        {
            Context.BorderColor = color;
            Context.BorderThickness = thickness;
            Context.CornerRounding = cornerRounding;

            return this;
        }

        public RectangleBuilder SetBorder(LabelColor color, int thickness)
            => SetBorder(color, thickness, ZPLForgeDefaults.Elements.Rectangle.CornerRounding);

        public RectangleBuilder SetBorder(int thickness)
            => SetBorder(ZPLForgeDefaults.Elements.Rectangle.BorderColor, thickness);
    }
}
