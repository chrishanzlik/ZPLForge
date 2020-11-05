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
    public class RectangleElement : LabelContent, IRectangle
    {
        public RectangleElement()
        {
            Width = ZPLForgeDefaults.Elements.Rectangle.Width;
            Height = ZPLForgeDefaults.Elements.Rectangle.Height;
            BorderThickness = ZPLForgeDefaults.Elements.Rectangle.BorderThickness;
            BorderColor = ZPLForgeDefaults.Elements.Rectangle.BorderColor;
            CornerRounding = ZPLForgeDefaults.Elements.Rectangle.CornerRounding;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public int BorderThickness { get; set; }
        public LabelColor BorderColor { get; set; }
        public int CornerRounding { get; set; }

        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.GB(Width, Height, BorderThickness, BorderColor, CornerRounding));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
