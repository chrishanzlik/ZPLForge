using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZPLForge.Commands;
using ZPLForge.Contracts;
using ZPLForge.Configuration;
using ZPLForge.Common;

namespace ZPLForge
{
    /// <summary>
    /// The <see cref="Label"/> class represents a printable ZPL label. Calling
    /// <see cref="ToString"/> will provide the generated ZPL code
    /// </summary>
    public class Label : ILabel, IZplGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Label" /> class with default values from <see cref="ZPLForgeDefaults.Elements.Label"/>.
        /// </summary>
        public Label()
        {
            BlackMarkOffset = ZPLForgeDefaults.Elements.Label.BlackMarkOffset;
            ReversePrintingColors = ZPLForgeDefaults.Elements.Label.ReversePrintingColors;
            Quantity = ZPLForgeDefaults.Elements.Label.Quantity;
            Encoding = ZPLForgeDefaults.Elements.Label.Encoding;
            PrintSpeed = ZPLForgeDefaults.Elements.Label.PrintSpeed;
            SlewSpeed = ZPLForgeDefaults.Elements.Label.SlewSpeed;
            BackfeedSpeed = ZPLForgeDefaults.Elements.Label.BackfeedSpeed;
            PauseAndCutValue = ZPLForgeDefaults.Elements.Label.PauseAndCutValue;
            OverridePauseCount = ZPLForgeDefaults.Elements.Label.OverridePauseCount;
            ReplicatesOfEachSerialNumber = ZPLForgeDefaults.Elements.Label.ReplicatesOfEachSerialNumber;
            CutOnError = ZPLForgeDefaults.Elements.Label.CutOnError;
            PositionX = ZPLForgeDefaults.Elements.Label.PositionX;
            PositionY = ZPLForgeDefaults.Elements.Label.PositionY;

            Content = new List<ILabelContent>();
        }


        /// <inheritdoc />
        public int? MediaLength { get; set; }

        /// <inheritdoc />
        public MediaTracking? MediaTracking { get; set; }

        /// <inheritdoc />
        public int? PrintWidth { get; set; }

        /// <inheritdoc />
        public PrintMode? PrintMode { get; set; }

        /// <inheritdoc />
        public int BlackMarkOffset { get; set; }

        /// <inheritdoc />
        public MediaType? MediaType { get; set; }

        /// <inheritdoc />
        public bool ReversePrintingColors { get; set; }

        /// <inheritdoc />
        public ZebraEncoding Encoding { get; set; }

        /// <inheritdoc />
        public List<ILabelContent> Content { get; set; }

        /// <inheritdoc />
        public PrintSpeed PrintSpeed { get; set; }

        /// <inheritdoc />
        public SlewSpeed SlewSpeed { get; set; }

        /// <inheritdoc />
        public BackfeedSpeed BackfeedSpeed { get; set; }

        /// <inheritdoc />
        public int Quantity { get; set; }

        /// <inheritdoc />
        public int PauseAndCutValue { get; set; }

        /// <inheritdoc />
        public bool OverridePauseCount { get; set; }

        /// <inheritdoc />
        public int ReplicatesOfEachSerialNumber { get; set; }

        /// <inheritdoc />
        public bool CutOnError { get; set; }

        /// <inheritdoc />
        public int? MediaDarknessLevel { get; set; }

        /// <inheritdoc />
        public int PositionX { get; set; }

        /// <inheritdoc />
        public int PositionY { get; set; }

        /// <summary>
        /// Allows implicit string conversion for the <see cref="Label"/> class.
        /// This internally triggers ZPL generation.
        /// </summary>
        /// <param name="label"><see cref="Label"/> to convert.</param>
        public static implicit operator string(Label label) => label.ToString();

        /// <summary>
        /// This method will take all label informations and convert it into a ZPL string
        /// </summary>
        /// <returns>Generated ZPL string</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            (this as IZplGenerator).GenerateZpl(builder);
            return builder.ToString();
        }

        /// <inheritdoc />
        StringBuilder IZplGenerator.GenerateZpl(StringBuilder builder)
        {
            builder.Append(ZPLCommand.XA());
            builder.Append(ZPLCommand.LH(PositionX, PositionY));

            if (MediaLength.HasValue)
                builder.Append(ZPLCommand.LL(MediaLength.Value));

            if (MediaTracking.HasValue)
                builder.Append(ZPLCommand.MN(MediaTracking.Value, BlackMarkOffset));

            if (PrintWidth.HasValue)
                builder.Append(ZPLCommand.PW(PrintWidth.Value));

            if (PrintMode.HasValue)
                builder.Append(ZPLCommand.MM(PrintMode.Value));

            if (MediaDarknessLevel.HasValue)
                builder.Append(ZPLCommand.MD(MediaDarknessLevel.Value));

            if (ReversePrintingColors)
                builder.Append(ZPLCommand.LR(true));

            if (MediaType.HasValue)
                builder.Append(ZPLCommand.MT(MediaType.Value));

            builder.Append(ZPLCommand.PQ(Quantity, PauseAndCutValue, ReplicatesOfEachSerialNumber, OverridePauseCount, CutOnError));
            builder.Append(ZPLCommand.CI(Encoding));
            builder.Append(ZPLCommand.PR(PrintSpeed, SlewSpeed, BackfeedSpeed));

            Content
                .Cast<IZplGenerator>()
                .Aggregate(builder, (acc, curr) => curr.GenerateZpl(acc));

            builder.Append(ZPLCommand.XZ());

            return builder;
        }
    }
}
