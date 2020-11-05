using System;
using ZPLForge.Builders.Abstractions;

namespace ZPLForge.Builders
{
    public partial class LabelBuilder
    {
        public LabelBuilder AddText(TextElement text)
        {
            Context.Content.Add(text ?? throw new ArgumentNullException(nameof(text)));
            return this;
        }

        public LabelBuilder AddText(Action<TextBuilder> text)
        {
            var builder = new TextBuilder();
            text(builder);
            return BuildToContentAndReturn(builder);
        }

        public LabelBuilder AddRectangle(RectangleElement rect)
        {
            Context.Content.Add(rect ?? throw new ArgumentNullException(nameof(rect)));
            return this;
        }

        public LabelBuilder AddRectangle(Action<RectangleBuilder> rect)
        {
            var builder = new RectangleBuilder();
            rect(builder);
            return BuildToContentAndReturn(builder);
        }

        public LabelBuilder AddEllipse(EllipseElement ellipse)
        {
            Context.Content.Add(ellipse ?? throw new ArgumentNullException(nameof(ellipse)));
            return this;
        }

        public LabelBuilder AddEllipse(Action<EllipseBuilder> ellipse)
        {
            var builder = new EllipseBuilder();
            ellipse(builder);
            return BuildToContentAndReturn(builder);
        }

        public LabelBuilder AddDiagonalLine(DiagonalLineElement dline)
        {
            Context.Content.Add(dline ?? throw new ArgumentNullException(nameof(dline)));
            return this;
        }

        public LabelBuilder AddDiagonalLine(Action<DiagonalLineBuilder> dline)
        {
            var builder = new DiagonalLineBuilder();
            dline(builder);
            return BuildToContentAndReturn(builder);
        }

        public LabelBuilder AddBarcode(BarcodeElement barcode)
        {
            Context.Content.Add(barcode ?? throw new ArgumentNullException(nameof(barcode)));
            return this;
        }

        public LabelBuilder AddSymbol(SymbolElement symbol)
        {
            Context.Content.Add(symbol ?? throw new ArgumentNullException(nameof(symbol)));
            return this;
        }

        public LabelBuilder AddSymbol(Action<SymbolBuilder> symbol)
        {
            var builder = new SymbolBuilder();
            symbol(builder);
            return BuildToContentAndReturn(builder);
        }

        public LabelBuilder AddImage(ImageElement image)
        {
            Context.Content.Add(image ?? throw new ArgumentNullException(nameof(image)));
            return this;
        }

        public LabelBuilder AddImage(Action<ImageBuilder> image)
        {
            var builder = new ImageBuilder();
            image(builder);
            return BuildToContentAndReturn(builder);
        }

        public LabelBuilder AddQrCode(QrCodeElement qrCode)
        {
            Context.Content.Add(qrCode ?? throw new ArgumentNullException(nameof(qrCode)));
            return this;
        }

        public LabelBuilder AddQrCode(Action<QrCodeBuilder> qrCode)
        {
            var builder = new QrCodeBuilder();
            qrCode(builder);
            return BuildToContentAndReturn(builder);
        }

        public LabelBuilder AddCode128Barcode(Action<Code128BarcodeBuilder> code128)
        {
            var builder = new Code128BarcodeBuilder();
            code128(builder);
            return BuildToContentAndReturn(builder);
        }

        public LabelBuilder AddEAN8Barcode(Action<EAN8BarcodeBuilder> ean8)
        {
            var builder = new EAN8BarcodeBuilder();
            ean8(builder);
            return BuildToContentAndReturn(builder);
        }

        public LabelBuilder AddEAN13Barcode(Action<EAN13BarcodeBuilder> ean13)
        {
            var builder = new EAN13BarcodeBuilder();
            ean13(builder);
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
