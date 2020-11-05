using System.Linq;
using System.Reflection;
using Xunit;
using ZPLForge.Configuration;
using ZPLForge.Contracts;

namespace ZPLForge.Tests
{
    public class LabelTests
    {
        [Fact]
        public void LabelZplStartsWithXA()
        {
            Assert.StartsWith("^XA", new Label());
        }

        [Fact]
        public void LabelZplEndsWithXZ()
        {
            Assert.EndsWith("^XZ", new Label());
        }

        [Fact]
        public void LabelIsCreatedWithDefaults()
        {
            var sut = new Label();
            
            Assert.Equal(ZPLForgeDefaults.Elements.Label.Encoding, sut.Encoding);
            Assert.Equal(ZPLForgeDefaults.Elements.Label.BackfeedSpeed, sut.BackfeedSpeed);
            Assert.Equal(ZPLForgeDefaults.Elements.Label.BlackMarkOffset, sut.BlackMarkOffset);
            Assert.Equal(ZPLForgeDefaults.Elements.Label.PrintSpeed, sut.PrintSpeed);
            Assert.Equal(ZPLForgeDefaults.Elements.Label.Quantity, sut.Quantity);
            Assert.Equal(ZPLForgeDefaults.Elements.Label.ReversePrintingColors, sut.ReversePrintingColors);
            Assert.Equal(ZPLForgeDefaults.Elements.Label.SlewSpeed, sut.SlewSpeed);
            Assert.Equal(ZPLForgeDefaults.Elements.Label.PauseAndCutValue, sut.PauseAndCutValue);
            Assert.Equal(ZPLForgeDefaults.Elements.Label.OverridePauseCount, sut.OverridePauseCount);
            Assert.Equal(ZPLForgeDefaults.Elements.Label.ReplicatesOfEachSerialNumber, sut.ReplicatesOfEachSerialNumber);
            Assert.Equal(ZPLForgeDefaults.Elements.Label.CutOnError, sut.CutOnError);
        }

        [Fact]
        public void LabelContentIsEmptyOnCreation()
        {
            Assert.Empty(new Label().Content);
        }

        /// <summary>
        /// Remove this test as soon the element contains properties that are not (and should not) part of the contract.
        /// </summary>
        [Fact]
        public void LabelPropertiesAreCoveredByContractInterface()
        {
            var contractProperties = typeof(ILabel).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var concreteProperties = typeof(Label).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach(var concrete in concreteProperties)
            {
                Assert.Contains(contractProperties, x => x.Name == concrete.Name && x.PropertyType == concrete.PropertyType);
            }
        }
    }
}
