using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization.Tests
{
    public class DataMatrixXmlNodeTests : IClassFixture<PropertyNameFixture<DataMatrixXmlNode>>
    {
        private readonly IReadOnlyCollection<string> propertyNames;

        public DataMatrixXmlNodeTests(PropertyNameFixture<DataMatrixXmlNode> fixture)
        {
            this.propertyNames = fixture.PropertyNames;
        }

        [Fact]
        public async Task DataMatrixXmlNodeSerializeAllPropsWhenForcedTo()
        {
            var sut = new DataMatrixXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, true);
            foreach (var prop in propertyNames)
            {
                Assert.Contains($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task DataMatrixXmlNodeSkipSerializingPropsWhenNotNeeded()
        {
            var sut = new DataMatrixXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            foreach (var prop in propertyNames)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task DataMatrixXmlNodeSerializeChangedPropWhichHasDefaults()
        {
            var sut = new DataMatrixXmlNode() { ErrorCorrection = Common.DataMatrixErrorCorrection.ECC_0 };
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            List<string> props = propertyNames
                .Except(new[] { nameof(DataMatrixXmlNode.ErrorCorrection) })
                .ToList();
            foreach (var prop in props)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }

            Assert.Contains($"<{nameof(DataMatrixXmlNode.ErrorCorrection)}", xml);
        }
    }
}
