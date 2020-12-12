namespace ZPLForge.Builders
{
    /// <summary>
    /// Label builder contract
    /// </summary>
    public interface ILabelBuilder
    {
        /// <summary>
        /// Applies all builder settings to the handled label.
        /// </summary>
        /// <returns>The element handled by the builder.</returns>
        Label Build();

        /// <summary>
        /// Resets the handled label to a blank one.
        /// </summary>
        void Reset();
    }
}
