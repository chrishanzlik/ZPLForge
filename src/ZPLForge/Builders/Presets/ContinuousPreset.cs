using System;
using ZPLForge.Common;
using ZPLForge.Contracts;

namespace ZPLForge.Builders.Presets
{
    public class ContinuousPreset : ILabelPreset
    {
        public ContinuousPreset(int printWidth, int labelLength, PrintMode? printMode = null, MediaType? mediaType = null)
        {
            PrintWidth = printWidth;
            LabelLength = labelLength;
            PrintMode = printMode;
            MediaType = mediaType;
        }

        public int PrintWidth { get; }
        public int LabelLength { get; }
        public MediaType? MediaType { get; }
        public PrintMode? PrintMode { get; }

        public virtual void Apply(ILabel label)
        {
            if (label == null)
                throw new ArgumentNullException(nameof(label));

            label.PrintWidth = PrintWidth;
            label.MediaType = MediaType;
            label.MediaLength = LabelLength;
            label.PrintMode = PrintMode;
            label.MediaTracking = MediaTracking.Continuous;
        }
    }
}
