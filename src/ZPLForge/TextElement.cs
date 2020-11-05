using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// To be addeded.
    /// </summary>
    public class TextElement : LabelContent, IText
    {
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

        public string Content { get; set; }
        public int? CharHeight { get; set; }
        public int? CharWidth { get; set; }
        public Orientation FontOrientation { get; set; }
        public Font FontStyle { get; set; }
        public bool BlockMode { get; set; }
        public int BlockWidth { get; set; }
        public int BlockLines { get; set; }
        public int BlockLineSpace { get; set; }
        public BlockAlignment BlockAlignment { get; set; }

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
