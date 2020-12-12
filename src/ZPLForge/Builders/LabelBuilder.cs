using System;
using ZPLForge.Common;
using ZPLForge.Presets;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="Label"/> objects.
    /// </summary>
    public partial class LabelBuilder : ILabelBuilder, IContextAccessor<Label>
    {
        /// <summary>
        /// Handled label.
        /// </summary>
        protected Label Context;

        /// <inheritdoc />
        Label IContextAccessor<Label>.Context => Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelBuilder" /> class.
        /// </summary>
        internal LabelBuilder()
        {
            Context = new Label();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelBuilder" /> class with predefined settings.
        /// </summary>
        /// <param name="preset">Predefined settings.</param>
        public LabelBuilder(ILabelPreset preset)
        {
            if (preset == null)
                throw new ArgumentNullException(nameof(preset));

            Context = new Label();

            preset.Apply(Context);
        }

        /// <inheritdoc />
        public Label Build()
        {
            Label temp = Context;

            Reset();

            return temp;
        }

        /// <inheritdoc />
        public void Reset()
        {
            Context = new Label();
        }
    }
}
