using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// QR Code contract
    /// </summary>
    public interface IQrCode : ILabelContent
    {
        /// <summary>
        /// Gets or sets the qr code content.
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// QR Code Model 1 is the original specification, while QR Code Model 2 is an
        /// enhanced form of the symbology. Model 2 provides additional features and can
        /// be automatically differentiated from Model 1.
        /// </summary>
        QrModel QrModel { get; set; }

        /// <summary>
        /// Gets or sets the magnification factor which determines how big the QR Code
        /// is printed on your label.
        /// </summary>
        Magnification MagnificationFactor { get; set; }

        /// <summary>
        /// Gets or sets the reliability level of the QR Code
        /// </summary>
        ErrorCorrection ErrorCorrection { get; set; }

        /// <summary>
        /// Gets or sets the mask value. Allowed values are from 0 to 7.
        /// </summary>
        int MaskValue { get; set; }
    }
}
