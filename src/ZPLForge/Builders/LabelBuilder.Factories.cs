using ZPLForge.Builders.Presets;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    public partial class LabelBuilder
    {
        public static LabelBuilder FromContinuousMedia(int printWidth, int labelLength, PrintMode? printMode = null, MediaType? mediaType = null)
        {
            var preset = new ContinuousPreset(printWidth, labelLength, printMode, mediaType);
            return new LabelBuilder(preset);
        }

        public static LabelBuilder FromCuttedContinuousMedia(int printWidth, int labelLength, MediaType? mediaType = null)
        {
            var preset = new ContinuousPreset(printWidth, labelLength, PrintMode.Cutter, mediaType);
            return new LabelBuilder(preset);
        }

        public static LabelBuilder FromBlackMarkSensingMedia(int printWidth, int blackMarkOffset, PrintMode? printMode = null, MediaType? mediaType = null)
        {
            var preset = new BlackMarkSensingPreset(printWidth, blackMarkOffset, printMode, mediaType);
            return new LabelBuilder(preset);
        }

        /// <summary>
        /// Used with labels that contains gaps or holes as separators.
        /// </summary>
        /// <param name="printWidth"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static LabelBuilder FromWebSensingMedia(int printWidth, PrintMode? printMode = null, MediaType? mediaType = null)
        {
            var preset = new WebSensingPreset(printWidth, printMode, mediaType);
            return new LabelBuilder(preset);
        }
    }
}
