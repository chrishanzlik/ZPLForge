using System.Text;

namespace ZPLForge
{
    /// <summary>
    /// Classes implementing the <see cref="IZplGenerator"/> interface provide ZPL
    /// generation
    /// </summary>
    public interface IZplGenerator
    {
        /// <summary>
        /// That's the place where the ZPL language is actually assembled
        /// </summary>
        /// <param name="builder">The generated is append to the builder</param>
        /// <returns>The builder passed by argument with the attached ZPL commands</returns>
        StringBuilder GenerateZpl(StringBuilder builder);
    }
}
