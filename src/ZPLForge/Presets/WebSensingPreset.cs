using System;
using ZPLForge.Common;
using ZPLForge.Contracts;

namespace ZPLForge.Presets
{
    public class WebSensingPreset : ILabelPreset
    {
        public WebSensingPreset(int printWidth, PrintMode? printMode, MediaType? mediaType)
        {
            PrintWidth = printWidth;
            PrintMode = printMode;
            MediaType = mediaType;
        }

        public int PrintWidth { get; }
        public PrintMode? PrintMode { get; }
        public MediaType? MediaType { get; }

        public virtual void Apply(ILabel label)
        {
            if (label == null)
                throw new ArgumentNullException(nameof(label));

            label.PrintWidth = PrintWidth;
            label.PrintMode = PrintMode;
            label.MediaType = MediaType;
            label.MediaTracking = MediaTracking.WebSensing;
        }
    }
}
