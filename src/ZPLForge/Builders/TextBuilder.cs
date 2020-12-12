using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="TextElement"/> objects.
    /// </summary>
    public sealed class TextBuilder : ElementBuilderBase<TextElement, TextBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBuilder" /> class.
        /// </summary>
        internal TextBuilder()
        {

        }

        /// <summary>
        /// Sets the text content.
        /// </summary>
        /// <param name="content">String content to be set.</param>
        /// <returns>The builder instance.</returns>
        public TextBuilder SetContent(string content)
        {
            Context.Content = content;

            return this;
        }

        /// <summary>
        /// Use the <see cref="TextElement"/> with block-mode enabled.
        /// </summary>
        /// <param name="width">Max. width in dots.</param>
        /// <param name="lines">Max. lines to be printed.</param>
        /// <param name="lineSpace">Space between the lines in dots. Negative values allowed.</param>
        /// <param name="alignment">Text alignment.</param>
        /// <returns>The builder instance.</returns>
        public TextBuilder ApplyBlockMode(int width, int lines, int lineSpace, BlockAlignment alignment)
        {
            Context.BlockMode = true;
            Context.BlockWidth = width;
            Context.BlockLines = lines;
            Context.BlockLineSpace = lineSpace;
            Context.BlockAlignment = alignment;

            return this;
        }

        /// <summary>
        /// Use the <see cref="TextElement"/> with block-mode enabled.
        /// </summary>
        /// <param name="width">Max. width in dots.</param>
        /// <param name="lines">Max. lines to be printed.</param>
        /// <param name="alignment">Text alignment.</param>
        /// <returns>The builder instance.</returns>
        public TextBuilder ApplyBlockMode(int width, int lines, BlockAlignment alignment)
            => ApplyBlockMode(width, lines, ZPLForgeDefaults.Elements.Text.BlockLineSpace, alignment);

        /// <summary>
        /// Use the <see cref="TextElement"/> with block-mode enabled.
        /// </summary>
        /// <param name="width">Max. width in dots.</param>
        /// <param name="alignment">Text alignment.</param>
        /// <returns>The builder instance.</returns>
        public TextBuilder ApplyBlockMode(int width, BlockAlignment alignment)
            => ApplyBlockMode(width, ZPLForgeDefaults.Elements.Text.BlockLines, alignment);

        /// <summary>
        /// Sets the font style of the <see cref="TextElement"/>.
        /// </summary>
        /// <param name="fontFamily">Font family/kind.</param>
        /// <param name="charHeight">Height of a single character in dots.</param>
        /// <param name="charWidth">Width of a single character in dots.</param>
        /// <param name="orientation">Font orientation.</param>
        /// <returns>The builder instance.</returns>
        public TextBuilder SetFont(Font fontFamily, int charHeight, int? charWidth = null, Orientation orientation = Orientation.Normal)
        {
            Context.FontStyle = fontFamily;
            Context.FontOrientation = orientation;
            Context.CharHeight = charHeight;
            Context.CharWidth = charWidth;

            return this;
        }

        /// <summary>
        /// Sets the font style of the <see cref="TextElement"/>.
        /// </summary>
        /// <param name="charHeight">Height of a single character in dots.</param>
        /// <param name="charWidth">Width of a single character in dots.</param>
        /// <param name="orientation">Font orientation.</param>
        /// <returns>The builder instance.</returns>
        public TextBuilder SetFont(int charHeight, int? charWidth = null, Orientation orientation = Orientation.Normal)
            => SetFont(Font.Default, charHeight, charWidth, orientation);
    }
}
