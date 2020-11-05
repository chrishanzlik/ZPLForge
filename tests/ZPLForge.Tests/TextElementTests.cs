using System.Reflection;
using Xunit;
using ZPLForge.Configuration;
using ZPLForge.Contracts;

namespace ZPLForge.Tests
{
    public class TextElementTests
    {
        [Fact]
        public void TextContainsCorrectElementCommand()
        {
            var sut = new TextElement();
            Assert.Contains("^A", sut.ToString());
        }

        [Fact]
        public void TextIsLabelContentElement()
        {
            var sut = new TextElement();
            Assert.IsAssignableFrom<LabelContent>(sut);
        }

        [Fact]
        public void TextContainsFBCommandInBlockMode()
        {
            var sut = new TextElement() { BlockMode = true };
            Assert.Contains("^FB", sut.ToString());
        }

        [Fact]
        public void TextDoesNotContainsFBCommandWithoutBlockMode()
        {
            var sut = new TextElement() { BlockMode = false };
            Assert.DoesNotContain("^FB", sut.ToString());
        }

        [Fact]
        public void TextHasFieldSeperator()
        {
            var sut = new TextElement();
            Assert.Contains("^FS", sut.ToString());
        }

        [Fact]
        public void TextHasFieldOrigin()
        {
            var sut = new TextElement();
            Assert.Contains("^FO", sut.ToString());
        }

        [Fact]
        public void TextIsCreatedWithDefaults()
        {
            var sut = new TextElement();
            Assert.Equal(ZPLForgeDefaults.Elements.Text.BlockAlignment, sut.BlockAlignment);
            Assert.Equal(ZPLForgeDefaults.Elements.Text.BlockLines, sut.BlockLines);
            Assert.Equal(ZPLForgeDefaults.Elements.Text.BlockLineSpace, sut.BlockLineSpace);
            Assert.Equal(ZPLForgeDefaults.Elements.Text.BlockMode, sut.BlockMode);
            Assert.Equal(ZPLForgeDefaults.Elements.Text.BlockWidth, sut.BlockWidth);
            Assert.Equal(ZPLForgeDefaults.Elements.Text.FontOrientation, sut.FontOrientation);
            Assert.Equal(ZPLForgeDefaults.Elements.Text.FontStyle, sut.FontStyle);
        }

        /// <summary>
        /// Remove this test as soon the element contains properties that are not (and should not) part of the contract.
        /// </summary>
        [Fact]
        public void TextPropertiesAreCoveredByContractInterface()
        {
            var contractProperties = typeof(IText).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var concreteProperties = typeof(TextElement).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var concrete in concreteProperties)
            {
                Assert.Contains(contractProperties, x => x.Name == concrete.Name && x.PropertyType == concrete.PropertyType);
            }
        }
    }
}
