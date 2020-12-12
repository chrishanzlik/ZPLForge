using System;
using ZPLForge.Common;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Base class for all one dimensional barcode elements
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    public abstract class BarcodeBuilderBase<TBuilder> : ElementBuilderBase<BarcodeElement, TBuilder>
        where TBuilder : BarcodeBuilderBase<TBuilder>
    {
        /// <summary>
        /// Gets the <see cref="BarcodeType"/> of the builder.
        /// </summary>
        protected abstract BarcodeType Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeBuilderBase{TBuilder}" /> class.
        /// </summary>
        internal BarcodeBuilderBase()
        {
            Context.BarcodeType = Type;
        }

        /// <summary>
        /// Set the barcode content, which should be decoded.
        /// </summary>
        /// <param name="content">Barcode content</param>
        /// <returns>The builder instance.</returns>
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

        /// <summary>
        /// Removes the human readable text translation above or below the barcode.
        /// </summary>
        /// <returns>The builder instance.</returns>
        public TBuilder RemoveInterpretationLine()
        {
            Context.PrintInterpretationLine = false;

            return (TBuilder)this;
        }

        /// <summary>
        /// Moves the human readable text above the barcode.
        /// </summary>
        /// <returns>The builder instance.</returns>
        public TBuilder MoveInterpretationLineAboveBarcode()
        {
            Context.PrintInterpretationLineAboveCode = true;

            return (TBuilder)this;
        }

        /// <summary>
        /// Set the height of the barcode element.
        /// </summary>
        /// <param name="height">Height in dots.</param>
        /// <returns>The builder instance.</returns>
        public TBuilder SetHeight(int height)
        {
            Context.Height = height;

            return (TBuilder)this;
        }

        /// <summary>
        /// Set the barcode orientation.
        /// </summary>
        /// <param name="orientation">Orientation to apply.</param>
        /// <returns>The builder instance.</returns>
        public TBuilder SetOrientation(Orientation orientation)
        {
            Context.BarcodeOrientation = orientation;

            return (TBuilder)this;
        }

        /// <summary>
        /// Wraps the barcode into a module (BY).
        /// </summary>
        /// <param name="moduleWidth">Module width as scale factor.</param>
        /// <param name="fieldHeight">Height of the module field in dots.</param>
        /// <param name="wideBarToNarrowBar">Wide bar to narrow bar distance factor.</param>
        /// <returns>The builder instance.</returns>
        public TBuilder WrapInModule(ModuleWidth moduleWidth, int fieldHeight, BarDistance wideBarToNarrowBar)
        {
            Context.ModuleWidth = moduleWidth;
            Context.FieldHeight = fieldHeight;
            Context.WideBarToNarrowBar = wideBarToNarrowBar;

            return (TBuilder)this;
        }

        /// <summary>
        /// Validates the barcode content. E.g. if all characters are allowed inside a limited barcode type.
        /// </summary>
        /// <param name="content">Content of the barcode.</param>
        /// <param name="error">Error which occurs while validation. This variable is null when the validation is passed successful.</param>
        /// <returns>A boolean value indicating the validation was successful or not.</returns>
        protected abstract bool ValidateContent(string content, out Exception error);
    }
}