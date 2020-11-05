using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ZPLForge.XmlSerialization.Tests
{
    public class TextXmlNodeTests : IClassFixture<PropertyNameFixture<TextXmlNode>>
    {
        private readonly IReadOnlyCollection<string> propertyNames;

        public TextXmlNodeTests(PropertyNameFixture<TextXmlNode> fixture)
        {
            this.propertyNames = fixture.PropertyNames;
        }

        [Fact]
        public async Task TextXmlNodeSerializeAllPropsWhenForcedTo()
        {
            var sut = new TextXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, true);
            foreach (var prop in propertyNames)
            {
                Assert.Contains($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task TextXmlNodeSkipSerializingPropsWhenNotNeeded()
        {
            var sut = new TextXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            foreach (var prop in propertyNames)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task TextXmlNodeSerializeChangedPropWhichHasDefaults()
        {
            var sut = new TextXmlNode() { FontStyle = Common.Font.B };
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            List<string> props = propertyNames
                .Except(new[] { nameof(TextXmlNode.FontStyle) })
                .ToList();
            foreach (var prop in props)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }

            Assert.Contains($"<{nameof(TextXmlNode.FontStyle)}", xml);
        }
    }
}
