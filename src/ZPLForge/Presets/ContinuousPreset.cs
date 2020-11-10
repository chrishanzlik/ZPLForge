using System;
using ZPLForge.Common;
using ZPLForge.Contracts;

namespace ZPLForge.Presets
{
    public class ContinuousPreset : ILabelPreset
    {
        public ContinuousPreset(int printWidth, int labelLength, PrintMode? printMode = null, int pauseAndCutValue = 0, MediaType? mediaType = null)
        {
            PrintWidth = printWidth;
            LabelLength = labelLength;
            PrintMode = printMode;
            MediaType = mediaType;
            PauseAndCutValue = pauseAndCutValue;

            if (pauseAndCutValue > 0)
                OverridePauseCount = true;
        }

        public int PrintWidth { get; }
        public int LabelLength { get; }
        public MediaType? MediaType { get; }
        public PrintMode? PrintMode { get; }
        public int PauseAndCutValue { get; }
        public bool OverridePauseCount { get; }

        public virtual void Apply(ILabel label)
        {
            if (label == null)
                throw new ArgumentNullException(nameof(label));

            label.PrintWidth = PrintWidth;
            label.MediaType = MediaType;
            label.MediaLength = LabelLength;
            label.PrintMode = PrintMode;
            label.PauseAndCutValue = PauseAndCutValue;
            label.MediaTracking = MediaTracking.Continuous;
            label.OverridePauseCount = OverridePauseCount;
        }
    }
}
