using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// To be added.
    /// </summary>
    public class QrCodeElement : LabelContent, IQrCode
    {
        public QrCodeElement()
        {
            QrModel = ZPLForgeDefaults.Elements.QrCode.QrModel;
            MagnificationFactor = ZPLForgeDefaults.Elements.QrCode.MagnificationFactor;
            ErrorCorrection = ZPLForgeDefaults.Elements.QrCode.ErrorCorrection;
            MaskValue = ZPLForgeDefaults.Elements.QrCode.MaskValue;
        }

        public string Content { get; set; }
        public QrModel QrModel { get; set; }
        public Magnification MagnificationFactor { get; set; }
        public ErrorCorrection ErrorCorrection { get; set; }
        public int MaskValue { get; set; }

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
