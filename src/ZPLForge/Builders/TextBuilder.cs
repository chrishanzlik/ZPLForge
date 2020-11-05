using ZPLForge.Builders.Abstractions;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    public sealed class TextBuilder : ElementBuilderBase<TextElement, TextBuilder>
    {
        internal TextBuilder()
        {

        }

        public TextBuilder SetContent(string content)
        {
            Context.Content = content;

            return this;
        }

        public TextBuilder ApplyBlockMode(int width, int lines, int lineSpace, BlockAlignment alignment)
        {
            Context.BlockMode = true;
            Context.BlockWidth = width;
            Context.BlockLines = lines;
            Context.BlockLineSpace = lineSpace;
            Context.BlockAlignment = alignment;

            return this;
        }

        public TextBuilder ApplyBlockMode(int width, int lines, BlockAlignment alignment)
            => ApplyBlockMode(width, lines, ZPLForgeDefaults.Elements.Text.BlockLineSpace, alignment);

        public TextBuilder ApplyBlockMode(int width, BlockAlignment alignment)
            => ApplyBlockMode(width, ZPLForgeDefaults.Elements.Text.BlockLines, alignment);

        public TextBuilder SetFont(Font fontFamily, int charHeight, int? charWidth = null, Orientation orientation = Orientation.Normal)
        {
            Context.FontStyle = fontFamily;
            Context.FontOrientation = orientation;
            Context.CharHeight = charHeight;
            Context.CharWidth = charWidth;

            return this;
        }

        public TextBuilder SetFont(int charHeight, int? charWidth = null, Orientation orientation = Orientation.Normal)
            => SetFont(Font.Default, charHeight, charWidth, orientation);
    }
}
