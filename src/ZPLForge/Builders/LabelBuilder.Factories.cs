using ZPLForge.Common;

namespace ZPLForge.Builders
{
    public partial class LabelBuilder
    {
        public static LabelBuilder FromContinuousMedia(int printWidth, int labelLength, PrintMode? printMode = null, MediaType? mediaType = null)
        {
            var builder = new LabelBuilder();
            builder.Context.MediaTracking = MediaTracking.ContinuousVariableLength;
            builder.Context.PrintWidth = printWidth;
            builder.Context.MediaLength = labelLength;
            builder.Context.MediaType = mediaType;
            builder.Context.PrintMode = printMode;
            return builder;
        }

        public static LabelBuilder FromCuttedContinuousMedia(int printWidth, int labelLength, MediaType? mediaType = null)
        {
            var builder = new LabelBuilder();
            builder.Context.MediaTracking = MediaTracking.ContinuousVariableLength;
            builder.Context.PrintWidth = printWidth;
            builder.Context.MediaLength = labelLength;
            builder.Context.MediaType = mediaType;
            builder.Context.PrintMode = PrintMode.Cutter;
            return builder;
        }

        public static LabelBuilder FromBlackMarkSensingMedia(int printWidth, int blackMarkOffset, PrintMode? printMode = null, MediaType? mediaType = null)
        {
            var builder = new LabelBuilder();
            builder.Context.MediaTracking = MediaTracking.MarkSensing;
            builder.Context.PrintWidth = printWidth;
            builder.Context.BlackMarkOffset = blackMarkOffset;
            builder.Context.MediaType = mediaType;
            builder.Context.PrintMode = printMode;
            return builder;
        }

        /// <summary>
        /// Used with labels that contains gaps or holes as separators.
        /// </summary>
        /// <param name="printWidth"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static LabelBuilder FromWebSensingMedia(int printWidth, PrintMode? printMode = null, MediaType? mediaType = null)
        {
            var builder = new LabelBuilder();
            builder.Context.MediaTracking = MediaTracking.WebSensing;
            builder.Context.PrintWidth = printWidth;
            builder.Context.MediaType = mediaType;
            builder.Context.PrintMode = printMode;
            return builder;
        }
    }
}
