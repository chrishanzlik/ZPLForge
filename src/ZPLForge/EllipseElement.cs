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
    public class EllipseElement : LabelContent, IEllipse
    {
        public EllipseElement()
        {
            Width = ZPLForgeDefaults.Elements.Ellipse.Width;
            Height = ZPLForgeDefaults.Elements.Ellipse.Height;
            BorderThickness = ZPLForgeDefaults.Elements.Ellipse.BorderThickness;
            BorderColor = ZPLForgeDefaults.Elements.Ellipse.BorderColor;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public int BorderThickness { get; set; }
        public LabelColor BorderColor { get; set; }

        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.GE(Width, Height, BorderThickness, BorderColor));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
