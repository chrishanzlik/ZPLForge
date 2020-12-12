using System;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for Code39 (Three Of Nine) barcodes.
    /// </summary>
    public sealed class Code39BarcodeBuilder : BarcodeBuilderBase<Code39BarcodeBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Code39BarcodeBuilder" /> class.
        /// </summary>
        internal Code39BarcodeBuilder()
        {

        }

        /// <inheritdoc />
        protected override BarcodeType Type => BarcodeType.Code39;

        /// <inheritdoc />
        protected override bool ValidateContent(string content, out Exception error)
        {
            error = null;
            return true;
        }

        /// <summary>
        /// Calling this method causes enabling the Mod43 check digit. This is Code39 specific.
        /// </summary>
        /// <returns>The builder instance.</returns>
        public Code39BarcodeBuilder EnalbeMod43CheckDigit()
        {
            Context.Mod43CheckDigit = true;

            return this;
        }
    }
}
