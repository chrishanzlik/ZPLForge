using System;
using System.Collections.Generic;
using System.Text;
using ZPLForge.Common;
using ZPLForge.Contracts;

namespace ZPLForge.Builders.Presets
{
    public class BlackMarkSensingPreset : ILabelPreset
    {
        public BlackMarkSensingPreset(int printWidth, int blackMarkOffset, PrintMode? printMode, MediaType? mediaType)
        {
            PrintWidth = printWidth;
            BlackMarkOffset = blackMarkOffset;
            PrintMode = printMode;
            MediaType = mediaType;
        }

        public int PrintWidth { get; }
        public int BlackMarkOffset { get; set; }
        public PrintMode? PrintMode { get; }
        public MediaType? MediaType { get; }

        public virtual void Apply(ILabel label)
        {
            if (label == null)
                throw new ArgumentNullException(nameof(label));

            label.PrintWidth = PrintWidth;
            label.PrintMode = PrintMode;
            label.MediaType = MediaType;
            label.BlackMarkOffset = BlackMarkOffset;
            label.MediaTracking = MediaTracking.MarkSensing;
        }
    }
}
