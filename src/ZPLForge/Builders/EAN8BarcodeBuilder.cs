using System;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    public sealed class EAN8BarcodeBuilder : BarcodeBuilderBase<EAN8BarcodeBuilder>
    {
        internal EAN8BarcodeBuilder()
        {

        }

        protected override BarcodeType Type => BarcodeType.EAN8;

        protected override bool ValidateContent(string content, out Exception error)
        {
            error = null;

            if (content.Length > 7)
            {
                error = new ArgumentOutOfRangeException("Only 7 digits expected. Don't include the check digit.");
                return false;
            }

            for(int i = 0; i < content.Length; i ++)
            {
                if (content[i] < '0' || content[i] > '9')
                {
                    error = new InvalidOperationException($"EAN8 only supports numbers. Found an '{content[i]}' character at position {i + 1}.");
                    return false;
                }
            }

            return true;
        }
    }
}
