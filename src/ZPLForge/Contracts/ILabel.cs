using System.Collections.Generic;
using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Label contract
    /// </summary>
    public interface ILabel
    {
        int? MediaLength { get; set; }
        MediaTracking? MediaTracking { get; set; }
        int? PrintWidth { get; set; }
        PrintMode? PrintMode { get; set; }

        /// <summary>
        /// Gets or sets the offset of the black mark on the backside of your label (if
        /// present and selected by <see cref="MediaTracking"/>)
        /// </summary>
        int BlackMarkOffset { get; set; }

        bool ReversePrintingColors { get; set; }
        int Quantity { get; set; }
        ZebraEncoding Encoding { get; set; }
        List<ILabelContent> Content { get; set; }
        PrintSpeed PrintSpeed { get; set; }
        SlewSpeed SlewSpeed { get; set; }
        BackfeedSpeed BackfeedSpeed { get; set; }
        MediaType? MediaType { get; set; }

        int PauseAndCutValue { get; set; }
        bool OverridePauseCount { get; set; }
        int ReplicatesOfEachSerialNumber { get; set; }
        bool CutOnError { get; set; }
        int? MediaDarknessLevel { get; set; }
    }
}
