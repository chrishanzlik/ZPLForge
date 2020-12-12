using ZPLForge.Presets;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="Label"/> objects.
    /// </summary>
    public partial class LabelBuilder
    {
        /// <summary>
        /// Builds a <see cref="Label" /> from a continous media source. 
        /// If the <see cref="PrintMode"/> or <see cref="MediaType"/> parameter remains null, the related ZPL commands will be omitted.
        /// </summary>
        /// <param name="printWidth">Print width of the label</param>
        /// <param name="labelLength">Total length of a single label</param>
        /// <param name="printMode">How the printer behaves after a label or labelgroup was printed</param>
        /// <param name="mediaType">Type of the printed medium</param>
        /// <returns>Returns a new <see cref="LabelBuilder" /> instance.</returns>
        public static LabelBuilder FromContinuousMedia(int printWidth, int labelLength, PrintMode? printMode = null, MediaType? mediaType = null)
        {
            var preset = new ContinuousPreset(printWidth, labelLength, printMode, 0, mediaType);
            return new LabelBuilder(preset);
        }

        /// <summary>
        /// Builds a <see cref="Label" /> from a continous media source with cutter enabled. 
        /// If the <see cref="MediaType"/> parameter remains null, the related ZPL command will be omitted.
        /// </summary>
        /// <param name="printWidth">Print width of the label</param>
        /// <param name="labelLength">Total length of a single label</param>
        /// <param name="groupCutCount">Print n labels and then enable the cutter.</param>
        /// <param name="mediaType">Type of the printed medium</param>
        /// <returns>Returns a new <see cref="LabelBuilder" /> instance.</returns>
        public static LabelBuilder FromCuttedContinuousMedia(int printWidth, int labelLength, int groupCutCount = 0, MediaType? mediaType = null)
        {
            var preset = new ContinuousPreset(printWidth, labelLength, PrintMode.Cutter, groupCutCount, mediaType);
            return new LabelBuilder(preset);
        }

        /// <summary>
        /// Builds a <see cref="Label" /> from a media which has a black mark on his backside.
        /// If the <see cref="PrintMode"/> or <see cref="MediaType"/> parameter remains null, the related ZPL commands will be omitted.
        /// </summary>
        /// <param name="printWidth">Print width of the label</param>
        /// <param name="blackMarkOffset"></param>
        /// <param name="printMode">How the printer behaves after a label or labelgroup was printed</param>
        /// <param name="mediaType">Type of the printed medium</param>
        /// <returns>Returns a new <see cref="LabelBuilder" /> instance.</returns>
        public static LabelBuilder FromBlackMarkSensingMedia(int printWidth, int blackMarkOffset, PrintMode? printMode = null, MediaType? mediaType = null)
        {
            var preset = new BlackMarkSensingPreset(printWidth, blackMarkOffset, printMode, mediaType);
            return new LabelBuilder(preset);
        }

        /// <summary>
        /// Builds a <see cref="Label" /> from a web sensing media. This means labels with gaps, notches, holes, etc.
        /// If the <see cref="PrintMode"/> or <see cref="MediaType"/> parameter remains null, the related ZPL commands will be omitted.
        /// </summary>
        /// <param name="printWidth">Print width of the label</param>
        /// <param name="printMode">How the printer behaves after a label or labelgroup was printed</param>
        /// <param name="mediaType">Type of the printed medium</param>
        /// <returns>Returns a new <see cref="LabelBuilder" /> instance.</returns>
        public static LabelBuilder FromWebSensingMedia(int printWidth, PrintMode? printMode = null, MediaType? mediaType = null)
        {
            var preset = new WebSensingPreset(printWidth, printMode, mediaType);
            return new LabelBuilder(preset);
        }
    }
}
