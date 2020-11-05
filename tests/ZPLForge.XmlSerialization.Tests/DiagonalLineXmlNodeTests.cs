using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ZPLForge.XmlSerialization.Tests
{
    public class DiagonalLineXmlNodeTests : IClassFixture<PropertyNameFixture<DiagonalLineXmlNode>>
    {
        private readonly IReadOnlyCollection<string> propertyNames;

        public DiagonalLineXmlNodeTests(PropertyNameFixture<DiagonalLineXmlNode> fixture)
        {
            this.propertyNames = fixture.PropertyNames;
        }

        [Fact]
        public async Task DiagnoalLineXmlNodeSerializeAllPropsWhenForcedTo()
        {
            var sut = new DiagonalLineXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, true);
            foreach (var prop in propertyNames)
            {
                Assert.Contains($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task DiagonalLineXmlNodeSkipSerializingPropsWhenNotNeeded()
        {
            var sut = new DiagonalLineXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            foreach (var prop in propertyNames)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task DiagnoalLineXmlNodeSerializeChangedPropWhichHasDefaults()
        {
            var sut = new DiagonalLineXmlNode() { BorderThickness = 666 };
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            var props = propertyNames.Except(new[] { nameof(DiagonalLineXmlNode.BorderThickness) })
                .ToList();
            foreach (var prop in props)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }

            Assert.Contains($"<{nameof(DiagonalLineXmlNode.BorderThickness)}", xml);
        }
    }
}
