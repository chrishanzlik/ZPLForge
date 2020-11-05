using System.Reflection;
using Xunit;
using ZPLForge.Configuration;
using ZPLForge.Contracts;

namespace ZPLForge.Tests
{
    public class EllipseElementTests
    {
        [Fact]
        public void EllipseContainsCorrectElementCommand()
        {
            var sut = new EllipseElement();
            Assert.Contains("^GE", sut.ToString());
        }

        [Fact]
        public void EllipseIsLabelContentElement()
        {
            var sut = new EllipseElement();
            Assert.IsAssignableFrom<LabelContent>(sut);
        }

        [Fact]
        public void EllipseHasFieldSeperator()
        {
            var sut = new EllipseElement();
            Assert.Contains("^FS", sut.ToString());
        }

        [Fact]
        public void EllipseHasFieldOrigin()
        {
            var sut = new EllipseElement();
            Assert.Contains("^FO", sut.ToString());
        }

        [Fact]
        public void EllipseIsCreatedWithDefaults()
        {
            var sut = new EllipseElement();
            Assert.Equal(ZPLForgeDefaults.Elements.Ellipse.BorderColor, sut.BorderColor);
            Assert.Equal(ZPLForgeDefaults.Elements.Ellipse.BorderThickness, sut.BorderThickness);
            Assert.Equal(ZPLForgeDefaults.Elements.Ellipse.Height, sut.Height);
            Assert.Equal(ZPLForgeDefaults.Elements.Ellipse.Width, sut.Width);
        }

        /// <summary>
        /// Remove this test as soon the element contains properties that are not (and should not) part of the contract.
        /// </summary>
        [Fact]
        public void EllipsePropertiesAreCoveredByContractInterface()
        {
            var contractProperties = typeof(IEllipse).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var concreteProperties = typeof(EllipseElement).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var concrete in concreteProperties)
            {
                Assert.Contains(contractProperties, x => x.Name == concrete.Name && x.PropertyType == concrete.PropertyType);
            }
        }
    }
}
