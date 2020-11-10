using ZPLForge.Common;

namespace ZPLForge.Builders
{
    public sealed class QrCodeBuilder : ElementBuilderBase<QrCodeElement, QrCodeBuilder>
    {
        internal QrCodeBuilder()
        {

        }

        public QrCodeBuilder SetContent(string content)
        {
            Context.Content = content;

            return this;
        }

        public QrCodeBuilder UseModel(QrModel model)
        {
            Context.QrModel = model;

            return this;
        }

        public QrCodeBuilder SetSize(Magnification magnification)
        {
            Context.MagnificationFactor = magnification;

            return this;
        }

        public QrCodeBuilder SetReliabilityMode(ErrorCorrection errorCorrection)
        {
            Context.ErrorCorrection = errorCorrection;

            return this;
        }

        public QrCodeBuilder SetMaskValue(int maskValue)
        {
            Context.MaskValue = maskValue;

            return this;
        }
    }
}
