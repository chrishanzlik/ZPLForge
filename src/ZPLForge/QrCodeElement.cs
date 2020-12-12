using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// Represents a QR code on the <see cref="Label"/>.
    /// </summary>
    public class QrCodeElement : LabelContent, IQrCode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QrCodeElement" /> class with default values from <see cref="ZPLForgeDefaults.Elements.QrCode"/>.
        /// </summary>
        public QrCodeElement()
        {
            QrModel = ZPLForgeDefaults.Elements.QrCode.QrModel;
            MagnificationFactor = ZPLForgeDefaults.Elements.QrCode.MagnificationFactor;
            ErrorCorrection = ZPLForgeDefaults.Elements.QrCode.ErrorCorrection;
            MaskValue = ZPLForgeDefaults.Elements.QrCode.MaskValue;
        }

        /// <inheritdoc />
        public string Content { get; set; }

        /// <inheritdoc />
        public QrModel QrModel { get; set; }

        /// <inheritdoc />
        public Magnification MagnificationFactor { get; set; }

        /// <inheritdoc />
        public ErrorCorrection ErrorCorrection { get; set; }

        /// <inheritdoc />
        public int MaskValue { get; set; }


        /// <inheritdoc />
        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            string fieldDataSwitches = (char)ErrorCorrection + "A,";

            builder.Append(ZPLCommand.BQ((int)QrModel, (int)MagnificationFactor, ErrorCorrection, MaskValue));
            builder.Append(ZPLCommand.FD(fieldDataSwitches + Content));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
