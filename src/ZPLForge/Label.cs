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

            Content = new List<ILabelContent>();
        }

        public int? MediaLength { get; set; }
        public MediaTracking? MediaTracking { get; set; }
        public int? PrintWidth { get; set; }
        public PrintMode? PrintMode { get; set; }
        public int BlackMarkOffset { get; set; }

        public MediaType? MediaType { get; set; }
        public bool ReversePrintingColors { get; set; }
        public ZebraEncoding Encoding { get; set; }
        public List<ILabelContent> Content { get; set; }

        public PrintSpeed PrintSpeed { get; set; }
        public SlewSpeed SlewSpeed { get; set; }
        public BackfeedSpeed BackfeedSpeed { get; set; }

        public int Quantity { get; set; }
        public int PauseAndCutValue { get; set; }
        public bool OverridePauseCount { get; set; }
        public int ReplicatesOfEachSerialNumber { get; set; }
        public bool CutOnError { get; set; }

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

        StringBuilder IZplGenerator.GenerateZpl(StringBuilder builder)
        {
            builder.Append(ZPLCommand.XA());

            if (MediaLength.HasValue)
                builder.Append(ZPLCommand.LL(MediaLength.Value));

            if (MediaTracking.HasValue)
                builder.Append(ZPLCommand.MN(MediaTracking.Value, BlackMarkOffset));

            if (PrintWidth.HasValue)
                builder.Append(ZPLCommand.PW(PrintWidth.Value));

            if (PrintMode.HasValue)
                builder.Append(ZPLCommand.MM(PrintMode.Value));

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
