using System.Reflection;
using Xunit;
using ZPLForge.Configuration;
using ZPLForge.Contracts;

namespace ZPLForge.Tests
{
    public class ImageElementTests
    {
        [Fact]
        public void ImageContainsCorrectElementCommand()
        {
            var sut = new ImageElement();
            Assert.Contains("^GF", sut.ToString());
        }

        [Fact]
        public void ImageIsLabelContentElement()
        {
            var sut = new ImageElement();
            Assert.IsAssignableFrom<LabelContent>(sut);
        }

        [Fact]
        public void ImageHasFieldSeperator()
        {
            var sut = new ImageElement();
            Assert.Contains("^FS", sut.ToString());
        }

        [Fact]
        public void ImageHasFieldOrigin()
        {
            var sut = new ImageElement();
            Assert.Contains("^FO", sut.ToString());
        }

        [Fact]
        public void ImageIsCreatedWithDefaults()
        {
            var sut = new ImageElement();
            Assert.Equal(ZPLForgeDefaults.Elements.Image.Compression, sut.Compression);
        }

        /// <summary>
        /// Remove this test as soon the element contains properties that are not (and should not) part of the contract.
        /// </summary>
        [Fact]
        public void ImagePropertiesAreCoveredByContractInterface()
        {
            var contractProperties = typeof(IImage).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var concreteProperties = typeof(ImageElement).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var concrete in concreteProperties)
            {
                Assert.Contains(contractProperties, x => x.Name == concrete.Name && x.PropertyType == concrete.PropertyType);
            }
        }
    }
}
