using System.Reflection;
using Xunit;
using ZPLForge.Configuration;
using ZPLForge.Contracts;

namespace ZPLForge.Tests
{
    public class DataMatrixTests
    {
        [Fact]
        public void DataMatrixContainsCorrectElementCommand()
        {
            var sut = new DataMatrixElement();
            Assert.Contains("^BX", sut.ToString());
        }

        [Fact]
        public void DataMatrixIsLabelContentElement()
        {
            var sut = new DataMatrixElement();
            Assert.IsAssignableFrom<LabelContent>(sut);
        }

        [Fact]
        public void DataMatrixHasFieldSeperator()
        {
            var sut = new DataMatrixElement();
            Assert.Contains("^FS", sut.ToString());
        }

        [Fact]
        public void DataMatrixHasFieldOrigin()
        {
            var sut = new DataMatrixElement();
            Assert.Contains("^FO", sut.ToString());
        }

        [Fact]
        public void DataMatrixIsCreatedWithDefaults()
        {
            var sut = new DataMatrixElement();
            Assert.Equal(ZPLForgeDefaults.Elements.DataMatrix.AspectRatio, sut.AspectRatio);
            Assert.Equal(ZPLForgeDefaults.Elements.DataMatrix.Format, sut.Format);
            Assert.Equal(ZPLForgeDefaults.Elements.DataMatrix.ErrorCorrection, sut.ErrorCorrection);
            Assert.Equal(ZPLForgeDefaults.Elements.DataMatrix.EscapeCharacter, sut.EscapeCharacter);
        }

        /// <summary>
        /// Remove this test as soon the element contains properties that are not (and should not) part of the contract.
        /// </summary>
        [Fact]
        public void DataMatrixPropertiesAreCoveredByContractInterface()
        {
            var contractProperties = typeof(IDataMatrix).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var concreteProperties = typeof(DataMatrixElement).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var concrete in concreteProperties)
            {
                Assert.Contains(contractProperties, x => x.Name == concrete.Name && x.PropertyType == concrete.PropertyType);
            }
        }
    }
}
