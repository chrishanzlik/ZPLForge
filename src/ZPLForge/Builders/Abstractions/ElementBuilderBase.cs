using ZPLForge.Common;

namespace ZPLForge.Builders.Abstractions
{
    /// <summary>
    /// Base class for all elements (label content)
    /// </summary>
    /// <typeparam name="TElement">Type of the element</typeparam>
    /// <typeparam name="TBuilder">Type of the element builder</typeparam>
    public abstract class ElementBuilderBase<TElement, TBuilder> : IElementBuilder<TElement>, IContextAccessor<TElement>
        where TElement : LabelContent, new()
        where TBuilder : ElementBuilderBase<TElement, TBuilder>
    {
        protected TElement Context;

        TElement IContextAccessor<TElement>.Context => Context;

        protected ElementBuilderBase()
        {
            Context = new TElement();
        }

        public TBuilder At(int positionX, int positionY, FieldOrigin origin)
        {
            Context.PositionX = positionX;
            Context.PositionY = positionY;
            Context.FieldOrigin = origin;

            return (TBuilder)this;
        }

        public TBuilder At(int positionX, int positionY)
            => At(positionX, positionY, FieldOrigin.Left);

        public TBuilder InvertColors()
        {
            Context.FieldReversePrint = true;

            return (TBuilder)this;
        }

        public void Reset()
        {
            Context = new TElement();
        }

        public TElement Build()
        {
            TElement temp = Context;

            Reset();

            return temp;
        }
    }
}
