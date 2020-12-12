using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// Represents a text on the <see cref="Label"/>.
    /// </summary>
    public class TextElement : LabelContent, IText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextElement" /> class with default values from <see cref="ZPLForgeDefaults.Elements.Text"/>.
        /// </summary>
        public TextElement()
        {
            FontOrientation = ZPLForgeDefaults.Elements.Text.FontOrientation;
            FontStyle = ZPLForgeDefaults.Elements.Text.FontStyle;
            BlockMode = ZPLForgeDefaults.Elements.Text.BlockMode;
            BlockWidth = ZPLForgeDefaults.Elements.Text.BlockWidth;
            BlockLines = ZPLForgeDefaults.Elements.Text.BlockLines;
            BlockLineSpace = ZPLForgeDefaults.Elements.Text.BlockLineSpace;
            BlockAlignment = ZPLForgeDefaults.Elements.Text.BlockAlignment;
        }

        /// <inheritdoc />
        public string Content { get; set; }

        /// <inheritdoc />
        public int? CharHeight { get; set; }

        /// <inheritdoc />
        public int? CharWidth { get; set; }

        /// <inheritdoc />
        public Orientation FontOrientation { get; set; }

        /// <inheritdoc />
        public Font FontStyle { get; set; }

        /// <inheritdoc />
        public bool BlockMode { get; set; }

        /// <inheritdoc />
        public int BlockWidth { get; set; }

        /// <inheritdoc />
        public int BlockLines { get; set; }

        /// <inheritdoc />
        public int BlockLineSpace { get; set; }

        /// <inheritdoc />
        public BlockAlignment BlockAlignment { get; set; }


        /// <inheritdoc />
        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.FD(Content));
            builder.Append(ZPLCommand.A(FontStyle, FontOrientation, CharHeight, CharWidth));

            if (BlockMode)
                builder.Append(ZPLCommand.FB(BlockWidth, BlockLines, BlockLineSpace, BlockAlignment));

            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
