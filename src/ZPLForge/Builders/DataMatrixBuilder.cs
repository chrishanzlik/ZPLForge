using ZPLForge.Common;

namespace ZPLForge.Builders
{
    public sealed class DataMatrixBuilder : ElementBuilderBase<DataMatrixElement, DataMatrixBuilder>
    {
        internal DataMatrixBuilder()
        {

        }

        public DataMatrixBuilder SetContent(string content)
        {
            Context.Content = content;

            return this;
        }

        public DataMatrixBuilder SetSize(int dimensionalHeight)
        {
            Context.DimensionalHeight = dimensionalHeight;

            return this;
        }

        public DataMatrixBuilder SetReliabilityMode(DataMatrixErrorCorrection errorCorrection)
        {
            Context.ErrorCorrection = errorCorrection;

            return this;
        }

        public DataMatrixBuilder SetColumnsToEncode(int ColumnsToEncode)
        {
            Context.ColumnsToEncode = ColumnsToEncode;

            return this;
        }
        public DataMatrixBuilder SetRowsToEndode(int RowsToEndode)
        {
            Context.RowsToEndode = RowsToEndode;

            return this;
        }

        public DataMatrixBuilder SetAspectRatio(DataMatrixAspectRatio aspectRatio)
        {
            Context.AspectRatio = aspectRatio;

            return this;
        }

        public DataMatrixBuilder SetFormat(DataMatrixFormat format)
        {
            Context.Format = format;

            return this;
        }

        public DataMatrixBuilder SetEscapeCharacter(char escapeCharacter)
        {
            Context.EscapeCharacter = escapeCharacter;

            return this;
        }
        
    }
}
