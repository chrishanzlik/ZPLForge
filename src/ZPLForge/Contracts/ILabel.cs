using System.Collections.Generic;
using ZPLForge.Common;

namespace ZPLForge.Contracts
{
    /// <summary>
    /// Label contract
    /// </summary>
    public interface ILabel
    {
        /// <summary>
        /// Gets or sets the starting position for content from the left edge in dots.
        /// </summary>
        int PositionX { get; set; }

        /// <summary>
        /// Gets or sets the starting position for content from the top edge in dots.
        /// </summary>
        int PositionY { get; set; }

        /// <summary>
        /// Gets or sets the media length / label height.
        /// </summary>
        int? MediaLength { get; set; }

        /// <summary>
        /// Gets or sets the kind of media tracking.
        /// </summary>
        MediaTracking? MediaTracking { get; set; }

        /// <summary>
        /// Gets or sets the print width / label width.
        /// </summary>
        int? PrintWidth { get; set; }

        /// <summary>
        /// Gets or sets the print mode.
        /// </summary>
        PrintMode? PrintMode { get; set; }

        /// <summary>
        /// Gets or sets the offset of the black mark on the backside of your label (if
        /// present and selected by <see cref="MediaTracking"/>)
        /// </summary>
        int BlackMarkOffset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the label colors should be reversed.
        /// </summary>
        bool ReversePrintingColors { get; set; }

        /// <summary>
        /// Gets or sets the quantity of labels to print.
        /// </summary>
        int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the target encoding of the printer.
        /// </summary>
        ZebraEncoding Encoding { get; set; }

        /// <summary>
        /// Gets or sets the labels content.
        /// </summary>
        List<ILabelContent> Content { get; set; }

        /// <summary>
        /// Gets or sets the print speed.
        /// </summary>
        PrintSpeed PrintSpeed { get; set; }

        /// <summary>
        /// Gets or sets the slew speed.
        /// </summary>
        SlewSpeed SlewSpeed { get; set; }

        /// <summary>
        /// Gets or sets the backfeed speed.
        /// </summary>
        BackfeedSpeed BackfeedSpeed { get; set; }

        /// <summary>
        /// Gets or sets the media type.
        /// </summary>
        MediaType? MediaType { get; set; }

        /// <summary>
        /// Gets or sets the pause time between the label cutter is activated.
        /// </summary>
        int PauseAndCutValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pause count should be overriden.
        /// </summary>
        bool OverridePauseCount { get; set; }

        /// <summary>
        /// Gets or sets the amount of replicates of each serial number. Only applicable when a serial number is used.
        /// </summary>
        int ReplicatesOfEachSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the label should be cutted in an error state.
        /// </summary>
        bool CutOnError { get; set; }

        /// <summary>
        /// Gets or sets the print darkness level.
        /// </summary>
        int? MediaDarknessLevel { get; set; }
    }
}
