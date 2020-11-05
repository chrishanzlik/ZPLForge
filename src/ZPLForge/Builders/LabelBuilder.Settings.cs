using ZPLForge.Common;

namespace ZPLForge.Builders
{
    public partial class LabelBuilder
    {
        public LabelBuilder SetQuantity(int count)
        {
            Context.Quantity = count;

            return this;
        }

        public LabelBuilder SetEncoding(ZebraEncoding encoding)
        {
            Context.Encoding = encoding;

            return this;
        }

        public LabelBuilder ModifyPrintSpeed(PrintSpeed printSpeed, SlewSpeed slewSpeed, BackfeedSpeed backfeedSpeed)
        {
            Context.PrintSpeed = printSpeed;
            Context.SlewSpeed = slewSpeed;
            Context.BackfeedSpeed = backfeedSpeed;

            return this;
        }

        public LabelBuilder InvertColors()
        {
            Context.ReversePrintingColors = true;

            return this;
        }
    }
}
