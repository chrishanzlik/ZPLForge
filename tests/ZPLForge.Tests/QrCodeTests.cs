using System.Reflection;
using Xunit;
using ZPLForge.Configuration;
using ZPLForge.Contracts;

namespace ZPLForge.Tests
{
    public class QrCodeTests
    {
        [Fact]
        public void QrCodeContainsCorrectElementCommand()
        {
            var sut = new QrCodeElement();
            Assert.Contains("^BQ", sut.ToString());
        }

        [Fact]
        public void QrCodeIsLabelContentElement()
        {
            var sut = new QrCodeElement();
            Assert.IsAssignableFrom<LabelContent>(sut);
        }

        [Fact]
        public void QrCodeHasFieldSeperator()
        {
            var sut = new QrCodeElement();
            Assert.Contains("^FS", sut.ToString());
        }

        [Fact]
        public void QrCodeHasFieldOrigin()
        {
            var sut = new QrCodeElement();
            Assert.Contains("^FO", sut.ToString());
        }

        [Fact]
        public void QrCodeIsCreatedWithDefaults()
        {
            var sut = new QrCodeElement();
            Assert.Equal(ZPLForgeDefaults.Elements.QrCode.ErrorCorrection, sut.ErrorCorrection);
            Assert.Equal(ZPLForgeDefaults.Elements.QrCode.MagnificationFactor, sut.MagnificationFactor);
            Assert.Equal(ZPLForgeDefaults.Elements.QrCode.MaskValue, sut.MaskValue);
            Assert.Equal(ZPLForgeDefaults.Elements.QrCode.QrModel, sut.QrModel);
        }

        /// <summary>
        /// Remove this test as soon the element contains properties that are not (and should not) part of the contract.
        /// </summary>
        [Fact]
        public void QrCodePropertiesAreCoveredByContractInterface()
        {
            var contractProperties = typeof(IQrCode).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var concreteProperties = typeof(QrCodeElement).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var concrete in concreteProperties)
            {
                Assert.Contains(contractProperties, x => x.Name == concrete.Name && x.PropertyType == concrete.PropertyType);
            }
        }
    }
}
