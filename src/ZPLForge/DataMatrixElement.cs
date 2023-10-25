using System.Text;
using ZPLForge.Contracts;
using ZPLForge.Commands;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge
{
    /// <summary>
    /// To be added.
    /// </summary>
    public class DataMatrixElement : LabelContent, IDataMatrix
    {
        public DataMatrixElement()
        {
            ErrorCorrection = ZPLForgeDefaults.Elements.DataMatrix.ErrorCorrection;
            DimensionalHeight = 1;
            Format = ZPLForgeDefaults.Elements.DataMatrix.Format;
            AspectRatio = ZPLForgeDefaults.Elements.DataMatrix.AspectRatio;
            EscapeCharacter = ZPLForgeDefaults.Elements.DataMatrix.EscapeCharacter;
        }

        public string Content { get; set; }
        public int DimensionalHeight { get; set; }
        public DataMatrixErrorCorrection ErrorCorrection { get; set; }
        public int ColumnsToEncode { get; set; }
        public int RowsToEndode { get; set; }
        public DataMatrixFormat Format { get; set; }
        public char EscapeCharacter { get; set; }
        public DataMatrixAspectRatio AspectRatio { get; set; }

        protected override StringBuilder GenerateZpl(StringBuilder builder)
        {
            base.GenerateZpl(builder);

            builder.Append(ZPLCommand.BX(DimensionalHeight, ErrorCorrection, ColumnsToEncode, RowsToEndode, Format, EscapeCharacter, AspectRatio));
            builder.Append(ZPLCommand.FD(Content));
            builder.Append(ZPLCommand.FS());

            return builder;
        }
    }
}
