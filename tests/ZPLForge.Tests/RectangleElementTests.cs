using System.Reflection;
using Xunit;
using ZPLForge.Configuration;
using ZPLForge.Contracts;

namespace ZPLForge.Tests
{
    public class RectangleElementTests
    {
        [Fact]
        public void RectangleContainsCorrectElementCommand()
        {
            var sut = new RectangleElement();
            Assert.Contains("^GB", sut.ToString());
        }

        [Fact]
        public void RectanleIsLabelContentElement()
        {
            var sut = new RectangleElement();
            Assert.IsAssignableFrom<LabelContent>(sut);
        }

        [Fact]
        public void RectangleHasFieldSeperator()
        {
            var sut = new RectangleElement();
            Assert.Contains("^FS", sut.ToString());
        }

        [Fact]
        public void RectangleHasFieldOrigin()
        {
            var sut = new RectangleElement();
            Assert.Contains("^FO", sut.ToString());
        }

        [Fact]
        public void RectangleIsCreatedWithDefaults()
        {
            var sut = new RectangleElement();
            Assert.Equal(ZPLForgeDefaults.Elements.Rectangle.BorderColor, sut.BorderColor);
            Assert.Equal(ZPLForgeDefaults.Elements.Rectangle.BorderThickness, sut.BorderThickness);
            Assert.Equal(ZPLForgeDefaults.Elements.Rectangle.Height, sut.Height);
            Assert.Equal(ZPLForgeDefaults.Elements.Rectangle.Width, sut.Width);
            Assert.Equal(ZPLForgeDefaults.Elements.Rectangle.CornerRounding, sut.CornerRounding);
        }

        /// <summary>
        /// Remove this test as soon the element contains properties that are not (and should not) part of the contract.
        /// </summary>
        [Fact]
        public void RectanglePropertiesAreCoveredByContractInterface()
        {
            var contractProperties = typeof(IRectangle).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var concreteProperties = typeof(RectangleElement).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var concrete in concreteProperties)
            {
                Assert.Contains(contractProperties, x => x.Name == concrete.Name && x.PropertyType == concrete.PropertyType);
            }
        }
    }
}
