namespace ZPLForge.Builders.Abstractions
{
    /// <summary>
    /// Label builder contract
    /// </summary>
    public interface ILabelBuilder
    {
        Label Build();

        void Reset();
    }
}
