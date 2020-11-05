using System;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    public sealed class Code128BarcodeBuilder : BarcodeBuilderBase<Code128BarcodeBuilder>
    {
        internal Code128BarcodeBuilder()
        {

        }

        protected override BarcodeType Type => BarcodeType.Code128;

        protected override bool ValidateContent(string content, out Exception error)
        {
            error = null;

            return true;
        }

        public Code128BarcodeBuilder EnableUCCCheckDigit()
        {
            Context.UCCCheckDigit = true;

            return this;
        }
    }
}
