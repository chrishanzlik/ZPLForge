using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ZPLForge.XmlSerialization.Tests
{
    public class RectangleXmlNodeTests : IClassFixture<PropertyNameFixture<RectangleXmlNode>>
    {
        private readonly IReadOnlyCollection<string> propertyNames;

        public RectangleXmlNodeTests(PropertyNameFixture<RectangleXmlNode> fixture)
        {
            this.propertyNames = fixture.PropertyNames;
        }

        [Fact]
        public async Task RectangleXmlNodeSerializeAllPropsWhenForcedTo()
        {
            var sut = new RectangleXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, true);
            foreach (var prop in propertyNames)
            {
                Assert.Contains($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task RectangleXmlNodeSkipSerializingPropsWhenNotNeeded()
        {
            var sut = new RectangleXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            foreach (var prop in propertyNames)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task RectangleXmlNodeSerializeChangedPropWhichHasDefaults()
        {
            var sut = new RectangleXmlNode() { BorderThickness = 666 };
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            List<string> props = propertyNames
                .Except(new[] { nameof(RectangleXmlNode.BorderThickness) })
                .ToList();
            foreach (var prop in props)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }

            Assert.Contains($"<{nameof(RectangleXmlNode.BorderThickness)}", xml);
        }
    }
}
