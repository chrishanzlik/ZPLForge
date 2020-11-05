using System;
using ZPLForge.Builders.Abstractions;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    public sealed class UPCEBarcodeBuilder : BarcodeBuilderBase<UPCEBarcodeBuilder>
    {
        internal UPCEBarcodeBuilder()
        {

        }

        protected override BarcodeType Type => BarcodeType.UPCE;

        protected override bool ValidateContent(string content, out Exception error)
        {
            error = null;

            if (content.Length > 10)
            {
                error = new ArgumentOutOfRangeException("Only 10 digits expected. Don't include the check digit.");
                return false;
            }

            for (int i = 0; i < content.Length; i++)
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
