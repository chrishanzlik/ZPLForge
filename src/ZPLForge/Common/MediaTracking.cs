namespace ZPLForge.Common
{
    public enum MediaTracking
    {
        /// <summary>
        /// Used in combination with label length
        /// </summary>
        Continuous = 'N',

        WebSensing = 'Y',

        MarkSensing = 'M',

        /// <summary>
        /// Auto detect mediatype during calibration
        /// </summary>
        AutoDetectAtCalibration = 'A',

        /// <summary>
        /// Same as Continuous media but with variable length.
        /// Prints media outside of label length.
        /// Set the label length is also required.
        /// </summary>
        ContinuousVariableLength = 'V'
    }
}
