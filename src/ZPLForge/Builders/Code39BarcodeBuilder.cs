using System;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    public sealed class Code39BarcodeBuilder : BarcodeBuilderBase<Code39BarcodeBuilder>
    {
        internal Code39BarcodeBuilder()
        {

        }

        protected override BarcodeType Type => BarcodeType.Code39;

        protected override bool ValidateContent(string content, out Exception error)
        {
            error = null;
            return true;
        }

        public Code39BarcodeBuilder EnalbeMod43CheckDigit()
        {
            Context.Mod43CheckDigit = true;

            return this;
        }
    }
}
