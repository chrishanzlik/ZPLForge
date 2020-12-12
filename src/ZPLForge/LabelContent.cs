using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// Base class for <see cref="Label"/> contet, defined as label element.
    /// </summary>
    public abstract class LabelContent : ILabelContent, IZplGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelContent" /> class with default values from <see cref="ZPLForgeDefaults.Elements"/>.
        /// </summary>
        protected LabelContent()
        {
            PositionX = ZPLForgeDefaults.Elements.PositionX;
            PositionY = ZPLForgeDefaults.Elements.PositionY;
            FieldOrigin = ZPLForgeDefaults.Elements.FieldOrigin;
            FieldReversePrint = ZPLForgeDefaults.Elements.FieldReversePrint;
        }

        /// <inheritdoc />
        public int PositionX { get; set; }

        /// <inheritdoc />
        public int PositionY { get; set; }

        /// <inheritdoc />
        public FieldOrigin FieldOrigin { get; set; }

        /// <inheritdoc />
        public bool FieldReversePrint { get; set; }


        /// <inheritdoc />
        protected virtual StringBuilder GenerateZpl(StringBuilder builder)
        {
            builder.Append(ZPLCommand.FO(PositionX, PositionY, FieldOrigin));

            if (FieldReversePrint)
                builder.Append(ZPLCommand.FR());

            return builder;
        }

        /// <inheritdoc />
        StringBuilder IZplGenerator.GenerateZpl(StringBuilder builder)
        {
            return GenerateZpl(builder);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return GenerateZpl(new StringBuilder()).ToString();
        }
    }
}
