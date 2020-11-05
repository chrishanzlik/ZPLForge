using System;
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

        public LabelBuilder AdjustDarknessLevel(int relativeAdjustment)
        {
            if (relativeAdjustment > 30) relativeAdjustment = 30;
            if (relativeAdjustment < -30) relativeAdjustment = -30;

            Context.MediaDarknessLevel = relativeAdjustment;

            return this;
        }
    }
}
