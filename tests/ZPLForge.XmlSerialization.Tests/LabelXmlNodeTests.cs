using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ZPLForge.XmlSerialization.Tests
{
    public class LabelXmlNodeTests : IClassFixture<PropertyNameFixture<LabelXmlNode>>
    {
        private readonly IReadOnlyCollection<string> propertyNames;

        public LabelXmlNodeTests(PropertyNameFixture<LabelXmlNode> fixture)
        {
            this.propertyNames = fixture.PropertyNames;
        }

        [Fact]
        public async Task LabelXmlNodeSerializeAllPropsWhenForcedTo()
        {
            var sut = new LabelXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, true);
            foreach (var prop in propertyNames)
            {
                Assert.Contains($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task LabelXmlNodeSkipSerializingPropsWhenNotNeeded()
        {
            var sut = new LabelXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            foreach(var prop in propertyNames)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task LabelXmlNodeSerializeChangedPropWhichHasDefaults()
        {
            var label = new LabelXmlNode() { BlackMarkOffset = 666 };
            string xml = await SerializationHelper.SerializeToStringAsync(label, false);
            List<string> props = propertyNames
                .Except(new[] { nameof(LabelXmlNode.BlackMarkOffset) })
                .ToList();
            foreach (var prop in props)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }

            Assert.Contains($"<{nameof(LabelXmlNode.BlackMarkOffset)}", xml);
        }
    }
}
