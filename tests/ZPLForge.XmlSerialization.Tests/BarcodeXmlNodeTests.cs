using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization.Tests
{
    public class BarcodeXmlNodeTests : IClassFixture<PropertyNameFixture<BarcodeXmlNode>>
    {
        private readonly IReadOnlyCollection<string> propertyNames;

        public BarcodeXmlNodeTests(PropertyNameFixture<BarcodeXmlNode> fixture)
        {
            this.propertyNames = fixture.PropertyNames;
        }

        [Fact]
        public async Task BarcodeXmlNodeSerializeAllPropsWhenForcedTo()
        {

            var sut = new BarcodeXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, true);
            foreach (var prop in propertyNames)
            {
                Assert.Contains($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task BarcodeXmlNodeSkipSerializingPropsWhenNotNeeded()
        {
            var sut = new BarcodeXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            foreach (var prop in propertyNames)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task BarcodeXmlNodeSerializeChangedPropWhichHasDefaults()
        {
            var sut = new BarcodeXmlNode() { Height = 666 };
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            var props = propertyNames.Except(new[] { nameof(BarcodeXmlNode.Height) });
            foreach (var prop in props)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }

            Assert.Contains($"<{nameof(BarcodeXmlNode.Height)}", xml);
        }
    }
}
