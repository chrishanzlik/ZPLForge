using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ZPLForge.XmlSerialization.Tests
{
    public class EllipseXmlNodeTests : IClassFixture<PropertyNameFixture<EllipseXmlNode>>
    {
        private readonly IReadOnlyCollection<string> propertyNames;

        public EllipseXmlNodeTests(PropertyNameFixture<EllipseXmlNode> fixture)
        {
            this.propertyNames = fixture.PropertyNames;
        }

        [Fact]
        public async Task EllipseXmlNodeSerializeAllPropsWhenForcedTo()
        {
            var sut = new EllipseXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, true);
            foreach (var prop in propertyNames)
            {
                Assert.Contains($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task EllipseXmlNodeSkipSerializingPropsWhenNotNeeded()
        {
            var sut = new EllipseXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            foreach (var prop in propertyNames)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task EllipseXmlNodeSerializeChangedPropWhichHasDefaults()
        {
            var sut = new EllipseXmlNode() { BorderThickness = 666 };
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            var props = propertyNames.Except(new[] { nameof(EllipseXmlNode.BorderThickness) })
                .ToList();
            foreach (var prop in props)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }

            Assert.Contains($"<{nameof(EllipseXmlNode.BorderThickness)}", xml);
        }
    }
}
