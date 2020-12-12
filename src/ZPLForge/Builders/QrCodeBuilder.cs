using ZPLForge.Common;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="QrCodeElement"/> objects.
    /// </summary>
    public sealed class QrCodeBuilder : ElementBuilderBase<QrCodeElement, QrCodeBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QrCodeBuilder" /> class.
        /// </summary>
        internal QrCodeBuilder()
        {

        }

        /// <summary>
        /// Sets the QRCode content.
        /// </summary>
        /// <param name="content">Content as string</param>
        /// <returns>The builder instance.</returns>
        public QrCodeBuilder SetContent(string content)
        {
            Context.Content = content;

            return this;
        }

        /// <summary>
        /// Determines which kind of QR-Modeltype should be used for this object.
        /// Using Version2 is recommended.
        /// </summary>
        /// <param name="model">Modeltype</param>
        /// <returns>The builder instance.</returns>
        public QrCodeBuilder UseModel(QrModel model)
        {
            Context.QrModel = model;

            return this;
        }

        /// <summary>
        /// Sets the size factor of the <see cref="QrCodeElement"/>.
        /// </summary>
        /// <param name="magnification">Magnification factor</param>
        /// <returns>The builder instance.</returns>
        public QrCodeBuilder SetSize(Magnification magnification)
        {
            Context.MagnificationFactor = magnification;

            return this;
        }

        /// <summary>
        /// Sets the reliability mode of the handled <see cref="QrCodeElement"/>.
        /// </summary>
        /// <param name="errorCorrection">Error correction level.</param>
        /// <returns>The builder instance.</returns>
        public QrCodeBuilder SetReliabilityMode(ErrorCorrection errorCorrection)
        {
            Context.ErrorCorrection = errorCorrection;

            return this;
        }

        /// <summary>
        /// Sets the mask value of the handled <see cref="QrCodeElement"/>.
        /// </summary>
        /// <param name="maskValue">Mask value. Values from 0 to 7 are awaited.</param>
        /// <returns>The builder instance.</returns>
        public QrCodeBuilder SetMaskValue(int maskValue)
        {
            Context.MaskValue = maskValue;

            return this;
        }
    }
}
