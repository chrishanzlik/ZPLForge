using System;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for Code128 barcodes.
    /// </summary>
    public sealed class Code128BarcodeBuilder : BarcodeBuilderBase<Code128BarcodeBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Code128BarcodeBuilder" /> class.
        /// </summary>
        internal Code128BarcodeBuilder()
        {

        }

        /// <inheritdoc />
        protected override BarcodeType Type => BarcodeType.Code128;

        /// <inheritdoc />
        protected override bool ValidateContent(string content, out Exception error)
        {
            error = null;

            return true;
        }

        /// <summary>
        /// Calling this method causes enabling the UCC check digit. This is Code128 specific.
        /// </summary>
        /// <returns>The builder instance.</returns>
        public Code128BarcodeBuilder EnableUCCCheckDigit()
        {
            Context.UCCCheckDigit = true;

            return this;
        }
    }
}
