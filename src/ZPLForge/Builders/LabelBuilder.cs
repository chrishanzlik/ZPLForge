using ZPLForge.Builders.Abstractions;

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
