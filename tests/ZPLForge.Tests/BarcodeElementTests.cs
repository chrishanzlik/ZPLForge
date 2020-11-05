using System.Reflection;
using Xunit;
using ZPLForge.Common;
using ZPLForge.Configuration;
using ZPLForge.Contracts;

namespace ZPLForge.Tests
{
    public class BarcodeElementTests
    {
        [Theory]
        [InlineData(BarcodeType.Code128, "^BC")]
        [InlineData(BarcodeType.EAN8, "^B8")]
        [InlineData(BarcodeType.EAN13, "^BE")]
        [InlineData(BarcodeType.UPCA, "^BU")]
        [InlineData(BarcodeType.UPCE, "^B9")]
        [InlineData(BarcodeType.Code39, "^B3")]
        public void BarcodeContainsCorrectElementCommand(BarcodeType type, string cmd)
        {
            var sut = new BarcodeElement() { BarcodeType = type };
            Assert.Contains(cmd, sut.ToString());
        }

        [Fact]
        public void BarcodeIsLabelContentElement()
        {
            var sut = new BarcodeElement();
            Assert.IsAssignableFrom<LabelContent>(sut);
        }

        [Fact]
        public void BarcodeHasFieldSeperator()
        {
            var sut = new BarcodeElement();
            Assert.Contains("^FS", sut.ToString());
        }

        [Fact]
        public void BarcodeHasFieldOrigin()
        {
            var sut = new BarcodeElement();
            Assert.Contains("^FO", sut.ToString());
        }

        [Fact]
        public void BarcodeIsCreatedWithDefaults()
        {
            var sut = new BarcodeElement();
            Assert.Equal(ZPLForgeDefaults.Elements.Barcode.BarcodeOrientation, sut.BarcodeOrientation);
            Assert.Equal(ZPLForgeDefaults.Elements.Barcode.FieldHeight, sut.FieldHeight);
            Assert.Equal(ZPLForgeDefaults.Elements.Barcode.ModuleWidth, sut.ModuleWidth);
            Assert.Equal(ZPLForgeDefaults.Elements.Barcode.PrintInterpretationLine, sut.PrintInterpretationLine);
            Assert.Equal(ZPLForgeDefaults.Elements.Barcode.PrintInterpretationLineAboveCode, sut.PrintInterpretationLineAboveCode);
            Assert.Equal(ZPLForgeDefaults.Elements.Barcode.BarcodeType, sut.BarcodeType);
            Assert.Equal(ZPLForgeDefaults.Elements.Barcode.UCCCheckDigit, sut.UCCCheckDigit);
            Assert.Equal(ZPLForgeDefaults.Elements.Barcode.WideBarToNarrowBar, sut.WideBarToNarrowBar);
            Assert.Equal(ZPLForgeDefaults.Elements.Barcode.PrintCheckDigit, sut.PrintCheckDigit);
            Assert.Equal(ZPLForgeDefaults.Elements.Barcode.Mod43CheckDigit, sut.Mod43CheckDigit);
        }

        /// <summary>
        /// Remove this test as soon the element contains properties that are not (and should not) part of the contract.
        /// </summary>
        [Fact]
        public void BarcodePropertiesAreCoveredByContractInterface()
        {
            var contractProperties = typeof(IBarcode).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var concreteProperties = typeof(BarcodeElement).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var concrete in concreteProperties)
            {
                Assert.Contains(contractProperties, x => x.Name == concrete.Name && x.PropertyType == concrete.PropertyType);
            }
        }
    }
}
