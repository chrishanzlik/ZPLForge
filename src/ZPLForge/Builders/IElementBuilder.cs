namespace ZPLForge.Builders
{
    /// <summary>
    /// Element builder contract
    /// </summary>
    /// <typeparam name="T">Type of the element to build</typeparam>
    public interface IElementBuilder<T> where T : LabelContent, new()
    {
        /// <summary>
        /// Applies all builder settings to the handled element.
        /// </summary>
        /// <returns>The element handled by the builder.</returns>
        T Build();

        /// <summary>
        /// Resets the handled element.
        /// </summary>
        void Reset();
    }
}
