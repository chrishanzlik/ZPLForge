using System.Reflection;
using Xunit;
using ZPLForge.Common;
using ZPLForge.Configuration;
using ZPLForge.Contracts;

namespace ZPLForge.Tests
{
    public class SymbolElementTests
    {
        [Theory]
        [InlineData(SymbolKind.CanadianStandardsAssociationApproval, 'E')]
        [InlineData(SymbolKind.Copyright, 'B')]
        [InlineData(SymbolKind.RegisteredTradeMark, 'A')]
        [InlineData(SymbolKind.TradeMark, 'C')]
        [InlineData(SymbolKind.UnderwritersLabsApproval, 'D')]
        public void SymbolHasAppropiateFieldDataForSymbol(SymbolKind symbol, char symChar)
        {
            var sut = new SymbolElement() { Content = symbol };
            Assert.Contains($"^FD{symChar}", sut.ToString());
        }

        [Fact]
        public void SymbolIsLabelContentElement()
        {
            var sut = new SymbolElement();
            Assert.IsAssignableFrom<LabelContent>(sut);
        }

        [Fact]
        public void SymbolContainsCorrectElementCommand()
        {
            var sut = new SymbolElement();
            Assert.Contains("^GS", sut.ToString());
        }

        [Fact]
        public void SymbolHasFieldSeperator()
        {
            var sut = new SymbolElement();
            Assert.Contains("^FS", sut.ToString());
        }

        [Fact]
        public void SymbolHasFieldOrigin()
        {
            var sut = new SymbolElement();
            Assert.Contains("^FO", sut.ToString());
        }

        [Fact]
        public void SymbolIsCreatedWithDefaults()
        {
            var sut = new SymbolElement();
            Assert.Equal(ZPLForgeDefaults.Elements.Symbol.FieldOrientation, sut.FieldOrientation);
        }

        /// <summary>
        /// Remove this test as soon the element contains properties that are not (and should not) part of the contract.
        /// </summary>
        [Fact]
        public void SymbolPropertiesAreCoveredByContractInterface()
        {
            var contractProperties = typeof(ISymbol).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var concreteProperties = typeof(SymbolElement).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var concrete in concreteProperties)
            {
                Assert.Contains(contractProperties, x => x.Name == concrete.Name && x.PropertyType == concrete.PropertyType);
            }
        }
    }
}
