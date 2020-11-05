using System;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Base class for all 2D barcode elements
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    public abstract class BarcodeBuilderBase<TBuilder> : ElementBuilderBase<BarcodeElement, TBuilder>
        where TBuilder : BarcodeBuilderBase<TBuilder>
    {
        protected abstract BarcodeType Type { get; }

        internal BarcodeBuilderBase()
        {
            Context.BarcodeType = Type;
        }

        public TBuilder SetContent(string content)
        {
            if (!ValidateContent(content, out Exception error))
            {
                throw new ArgumentException(
                    "Error while setting the barcodes content. " +
                    "Please see inner exception for details.",
                    error
                );
            }

            Context.Content = content;

            return (TBuilder)this;
        }

        public TBuilder RemoveInterpretationLine()
        {
            Context.PrintInterpretationLine = false;

            return (TBuilder)this;
        }

        public TBuilder MoveInterpretationLineAboveBarcode()
        {
            Context.PrintInterpretationLineAboveCode = true;

            return (TBuilder)this;
        }

        public TBuilder SetHeight(int height)
        {
            Context.Height = height;

            return (TBuilder)this;
        }

        public TBuilder SetOrientation(Orientation orientation)
        {
            Context.BarcodeOrientation = orientation;

            return (TBuilder)this;
        }

        public TBuilder WrapInModule(ModuleWidth moduleWidth, int fieldHeight, BarDistance wideBarToNarrowBar)
        {
            Context.ModuleWidth = moduleWidth;
            Context.FieldHeight = fieldHeight;
            Context.WideBarToNarrowBar = wideBarToNarrowBar;

            return (TBuilder)this;
        }

        protected abstract bool ValidateContent(string content, out Exception error);
    }
}