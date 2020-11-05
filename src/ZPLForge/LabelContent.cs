using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// Base class for label contet, defined as elements.
    /// </summary>
    public abstract class LabelContent : ILabelContent, IZplGenerator
    {
        protected LabelContent()
        {
            PositionX = ZPLForgeDefaults.Elements.PositionX;
            PositionY = ZPLForgeDefaults.Elements.PositionY;
            FieldOrigin = ZPLForgeDefaults.Elements.FieldOrigin;
            FieldReversePrint = ZPLForgeDefaults.Elements.FieldReversePrint;
        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public FieldOrigin FieldOrigin { get; set; }
        public bool FieldReversePrint { get; set; }

        protected virtual StringBuilder GenerateZpl(StringBuilder builder)
        {
            builder.Append(ZPLCommand.FO(PositionX, PositionY, FieldOrigin));

            if (FieldReversePrint)
                builder.Append(ZPLCommand.FR());

            return builder;
        }

        StringBuilder IZplGenerator.GenerateZpl(StringBuilder builder)
        {
            return GenerateZpl(builder);
        }

        public override string ToString()
        {
            return GenerateZpl(new StringBuilder()).ToString();
        }
    }
}
