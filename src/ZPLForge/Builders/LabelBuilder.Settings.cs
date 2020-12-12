using ZPLForge.Common;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="Label"/> objects.
    /// </summary>
    public partial class LabelBuilder
    {
        /// <summary>
        /// Sets the quantity of labels to be printed.
        /// </summary>
        /// <param name="count">Amount of printed labels</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder SetQuantity(int count)
        {
            Context.Quantity = count;

            return this;
        }

        /// <summary>
        /// Sets the starting position (Padding) of the label.
        /// </summary>
        /// <param name="positionX">Starting position from the left edge in dots.</param>
        /// <param name="positionY">Starting position from the top edge in dots.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder StartAt(int positionX, int positionY)
        {
            Context.PositionX = positionX;
            Context.PositionY = positionY;

            return this;
        }

        /// <summary>
        /// Sets the encoding which is used by the printer to print the <see cref="Label"/>.
        /// </summary>
        /// <param name="encoding">Encoding</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder SetEncoding(ZebraEncoding encoding)
        {
            Context.Encoding = encoding;

            return this;
        }

        /// <summary>
        /// Adjust the print speed of the print job.
        /// </summary>
        /// <param name="printSpeed">Print speed.</param>
        /// <param name="slewSpeed">Slew speed.</param>
        /// <param name="backfeedSpeed">Backfeed speed.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder ModifyPrintSpeed(PrintSpeed printSpeed, SlewSpeed slewSpeed, BackfeedSpeed backfeedSpeed)
        {
            Context.PrintSpeed = printSpeed;
            Context.SlewSpeed = slewSpeed;
            Context.BackfeedSpeed = backfeedSpeed;

            return this;
        }

        /// <summary>
        /// Invert all element colors inside the generated label.
        /// </summary>
        /// <returns>The builder instance.</returns>
        public LabelBuilder InvertColors()
        {
            Context.ReversePrintingColors = true;

            return this;
        }

        /// <summary>
        /// Adjust the darkness level of the printer in a relative manner.
        /// </summary>
        /// <param name="relativeAdjustment">Adjusted darkness level. Accept values between -30 and 30.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AdjustDarknessLevel(int relativeAdjustment)
        {
            if (relativeAdjustment > 30) relativeAdjustment = 30;
            if (relativeAdjustment < -30) relativeAdjustment = -30;

            Context.MediaDarknessLevel = relativeAdjustment;

            return this;
        }
    }
}
