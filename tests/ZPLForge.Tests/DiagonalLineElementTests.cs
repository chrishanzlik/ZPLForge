using System.Reflection;
using Xunit;
using ZPLForge.Configuration;
using ZPLForge.Contracts;

namespace ZPLForge.Tests
{
    public class DiagonalLineElementTests
    {
        [Fact]
        public void DiagonalLineContainsCorrectElementCommand()
        {
            var sut = new DiagonalLineElement();
            Assert.Contains("^GD", sut.ToString());
        }

        [Fact]
        public void DiagonalLineIsLabelContentElement()
        {
            var sut = new DiagonalLineElement();
            Assert.IsAssignableFrom<LabelContent>(sut);
        }

        [Fact]
        public void DiagonalLineHasFieldSeperator()
        {
            var sut = new DiagonalLineElement();
            Assert.Contains("^FS", sut.ToString());
        }

        [Fact]
        public void DiagonalLineHasFieldOrigin()
        {
            var sut = new DiagonalLineElement();
            Assert.Contains("^FO", sut.ToString());
        }

        [Fact]
        public void DiagonalLineIsCreatedWithDefaults()
        {
            var sut = new DiagonalLineElement();
            Assert.Equal(ZPLForgeDefaults.Elements.DiagonalLine.BorderColor, sut.BorderColor);
            Assert.Equal(ZPLForgeDefaults.Elements.DiagonalLine.BorderThickness, sut.BorderThickness);
            Assert.Equal(ZPLForgeDefaults.Elements.DiagonalLine.Height, sut.Height);
            Assert.Equal(ZPLForgeDefaults.Elements.DiagonalLine.InverseLeaningDirection, sut.InverseLeaningDirection);
            Assert.Equal(ZPLForgeDefaults.Elements.DiagonalLine.Width, sut.Width);
        }

        /// <summary>
        /// Remove this test as soon the element contains properties that are not (and should not) part of the contract.
        /// </summary>
        [Fact]
        public void DiagonalLinePropertiesAreCoveredByContractInterface()
        {
            var contractProperties = typeof(IDiagonalLine).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var concreteProperties = typeof(DiagonalLineElement).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var concrete in concreteProperties)
            {
                Assert.Contains(contractProperties, x => x.Name == concrete.Name && x.PropertyType == concrete.PropertyType);
            }
        }
    }
}
