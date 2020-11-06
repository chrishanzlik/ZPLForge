using System;
using ZPLForge.Common;
using ZPLForge.Presets;

namespace ZPLForge.Builders
{
    public partial class LabelBuilder : ILabelBuilder, IContextAccessor<Label>
    {
        protected Label Context;
        Label IContextAccessor<Label>.Context => Context;

        internal LabelBuilder()
        {
            Context = new Label();
        }

        public LabelBuilder(ILabelPreset preset)
        {
            if (preset == null)
                throw new ArgumentNullException(nameof(preset));

            Context = new Label();

            preset.Apply(Context);
        }

        public Label Build()
        {
            Label temp = Context;

            Reset();

            return temp;
        }

        public void Reset()
        {
            Context = new Label();
        }
    }
}
