using System;

namespace ZPLForge.Builders
{
    /// <summary>
    /// Builder class for <see cref="Label"/> objects.
    /// </summary>
    public partial class LabelBuilder
    {
        /// <summary>
        /// Adds a <see cref="TextElement"/> to this label.
        /// </summary>
        /// <param name="text"><see cref="TextElement"/> to be added.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddText(TextElement text)
        {
            Context.Content.Add(text ?? throw new ArgumentNullException(nameof(text)));
            return this;
        }

        /// <summary>
        /// Adds a <see cref="TextElement"/> to this label.
        /// </summary>
        /// <param name="text">Builder action to create the <see cref="TextElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddText(Action<TextBuilder> text)
        {
            var builder = new TextBuilder();
            text(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a <see cref="RectangleElement"/> to this label.
        /// </summary>
        /// <param name="rect"><see cref="RectangleElement"/> to be added.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddRectangle(RectangleElement rect)
        {
            Context.Content.Add(rect ?? throw new ArgumentNullException(nameof(rect)));
            return this;
        }

        /// <summary>
        /// Adds a <see cref="RectangleElement"/> to this label.
        /// </summary>
        /// <param name="rect">Builder action to create the <see cref="RectangleElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddRectangle(Action<RectangleBuilder> rect)
        {
            var builder = new RectangleBuilder();
            rect(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a <see cref="EllipseElement"/> to this label.
        /// </summary>
        /// <param name="ellipse"><see cref="EllipseElement"/> to be added.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddEllipse(EllipseElement ellipse)
        {
            Context.Content.Add(ellipse ?? throw new ArgumentNullException(nameof(ellipse)));
            return this;
        }

        /// <summary>
        /// Adds a <see cref="EllipseElement"/> to this label.
        /// </summary>
        /// <param name="ellipse">Builder action to create the <see cref="EllipseElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddEllipse(Action<EllipseBuilder> ellipse)
        {
            var builder = new EllipseBuilder();
            ellipse(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a <see cref="DiagonalLineElement"/> to this label.
        /// </summary>
        /// <param name="dline"><see cref="DiagonalLineElement"/> to be added.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddDiagonalLine(DiagonalLineElement dline)
        {
            Context.Content.Add(dline ?? throw new ArgumentNullException(nameof(dline)));
            return this;
        }

        /// <summary>
        /// Adds a <see cref="DiagonalLineElement"/> to this label.
        /// </summary>
        /// <param name="dline">Builder action to create the <see cref="DiagonalLineElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddDiagonalLine(Action<DiagonalLineBuilder> dline)
        {
            var builder = new DiagonalLineBuilder();
            dline(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a <see cref="BarcodeElement"/> to this label.
        /// </summary>
        /// <param name="barcode"><see cref="BarcodeElement"/> to be added.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddBarcode(BarcodeElement barcode)
        {
            Context.Content.Add(barcode ?? throw new ArgumentNullException(nameof(barcode)));
            return this;
        }

        /// <summary>
        /// Adds a <see cref="SymbolElement"/> to this label.
        /// </summary>
        /// <param name="symbol"><see cref="SymbolElement"/> to be added.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddSymbol(SymbolElement symbol)
        {
            Context.Content.Add(symbol ?? throw new ArgumentNullException(nameof(symbol)));
            return this;
        }

        /// <summary>
        /// Adds a <see cref="SymbolElement"/> to this label.
        /// </summary>
        /// <param name="symbol">Builder action to create the <see cref="SymbolElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddSymbol(Action<SymbolBuilder> symbol)
        {
            var builder = new SymbolBuilder();
            symbol(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a <see cref="ImageElement"/> to this label.
        /// </summary>
        /// <param name="image"><see cref="ImageElement"/> to be added.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddImage(ImageElement image)
        {
            Context.Content.Add(image ?? throw new ArgumentNullException(nameof(image)));
            return this;
        }

        /// <summary>
        /// Adds a <see cref="ImageElement"/> to this label.
        /// </summary>
        /// <param name="image">Builder action to create the <see cref="ImageElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddImage(Action<ImageBuilder> image)
        {
            var builder = new ImageBuilder();
            image(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a <see cref="QrCodeElement"/> to this label.
        /// </summary>
        /// <param name="qrCode"><see cref="QrCodeElement"/> to be added.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddQrCode(QrCodeElement qrCode)
        {
            Context.Content.Add(qrCode ?? throw new ArgumentNullException(nameof(qrCode)));
            return this;
        }

        /// <summary>
        /// Adds a <see cref="QrCodeElement"/> to this label.
        /// </summary>
        /// <param name="qrCode">Builder action to create the <see cref="QrCodeElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddQrCode(Action<QrCodeBuilder> qrCode)
        {
            var builder = new QrCodeBuilder();
            qrCode(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a Code128 <see cref="BarcodeElement"/> to this label.
        /// </summary>
        /// <param name="code128">Builder action to create the <see cref="BarcodeElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddCode128Barcode(Action<Code128BarcodeBuilder> code128)
        {
            var builder = new Code128BarcodeBuilder();
            code128(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a EAN8 <see cref="BarcodeElement"/> to this label.
        /// </summary>
        /// <param name="ean8">Builder action to create the <see cref="BarcodeElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddEAN8Barcode(Action<EAN8BarcodeBuilder> ean8)
        {
            var builder = new EAN8BarcodeBuilder();
            ean8(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a EAN13 <see cref="BarcodeElement"/> to this label.
        /// </summary>
        /// <param name="ean13">Builder action to create the <see cref="BarcodeElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddEAN13Barcode(Action<EAN13BarcodeBuilder> ean13)
        {
            var builder = new EAN13BarcodeBuilder();
            ean13(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a UPC-A <see cref="BarcodeElement"/> to this label.
        /// </summary>
        /// <param name="upc">Builder action to create the <see cref="BarcodeElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddUPCABarcode(Action<UPCABarcodeBuilder> upc)
        {
            var builder = new UPCABarcodeBuilder();
            upc(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a UPC-E <see cref="BarcodeElement"/> to this label.
        /// </summary>
        /// <param name="upc">Builder action to create the <see cref="BarcodeElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddUPCEBarcode(Action<UPCEBarcodeBuilder> upc)
        {
            var builder = new UPCEBarcodeBuilder();
            upc(builder);
            return BuildToContentAndReturn(builder);
        }

        /// <summary>
        /// Adds a Code39 <see cref="BarcodeElement"/> to this label.
        /// </summary>
        /// <param name="code39">Builder action to create the <see cref="BarcodeElement"/>.</param>
        /// <returns>The builder instance.</returns>
        public LabelBuilder AddCode39Barcode(Action<Code39BarcodeBuilder> code39)
        {
            var builder = new Code39BarcodeBuilder();
            code39(builder);
            return BuildToContentAndReturn(builder);
        }

        private LabelBuilder BuildToContentAndReturn<TElem>(IElementBuilder<TElem> builder)
            where TElem : LabelContent, new()
        {
            var element = builder.Build();

            Context.Content.Add(element);

            return this;
        }
    }
}
