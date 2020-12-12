using System;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for UPC-A barcodes.
    /// </summary>
    public class UPCABarcodeBuilder : BarcodeBuilderBase<UPCABarcodeBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UPCABarcodeBuilder" /> class.
        /// </summary>
        internal UPCABarcodeBuilder()
        {

        }

        /// <inheritdoc />
        protected override BarcodeType Type => BarcodeType.UPCA;

        /// <inheritdoc />
        protected override bool ValidateContent(string content, out Exception error)
        {
            error = null;

            if (content.Length > 11)
            {
                error = new ArgumentOutOfRangeException("Only 11 digits expected. Don't include the check digit.");
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

        /// <summary>
        /// After this method was called, the check digit is not printed anymore.
        /// </summary>
        /// <returns>The builder instance.</returns>
        public UPCABarcodeBuilder DisableCheckDigit()
        {

            Context.PrintCheckDigit = false;

            return this;
        }
    }
}
