using ZPLForge.Common;

namespace ZPLForge.Builders
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
        /// <summary>
        /// Handled element.
        /// </summary>
        protected TElement Context;

        /// <inheritdoc />
        TElement IContextAccessor<TElement>.Context => Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementBuilderBase" /> class.
        /// </summary>
        protected ElementBuilderBase()
        {
            Context = new TElement();
        }

        /// <summary>
        /// Set the position where the element should be drawed.
        /// </summary>
        /// <param name="positionX">Horizontal position beginning from left in dots.</param>
        /// <param name="positionY">Vertical position beginning from top in dots.</param>
        /// <param name="origin">Field origin of the lement.</param>
        /// <returns>The builder instance.</returns>
        public TBuilder At(int positionX, int positionY, FieldOrigin origin)
        {
            Context.PositionX = positionX;
            Context.PositionY = positionY;
            Context.FieldOrigin = origin;

            return (TBuilder)this;
        }

        /// <summary>
        /// Set the position where the element should be drawed.
        /// </summary>
        /// <param name="positionX">Horizontal position beginning from left in dots.</param>
        /// <param name="positionY">Vertical position beginning from top in dots.</param>
        /// <returns>The builder instance.</returns>
        public TBuilder At(int positionX, int positionY)
            => At(positionX, positionY, FieldOrigin.Left);

        /// <summary>
        /// Inverts the drawing colors of the element. (Swaps black and white)
        /// </summary>
        /// <returns>The builder instance.</returns>
        public TBuilder InvertColors()
        {
            Context.FieldReversePrint = true;

            return (TBuilder)this;
        }

        /// <inheritdoc />
        public void Reset()
        {
            Context = new TElement();
        }

        /// <inheritdoc />
        public TElement Build()
        {
            TElement temp = Context;

            Reset();

            return temp;
        }
    }
}
