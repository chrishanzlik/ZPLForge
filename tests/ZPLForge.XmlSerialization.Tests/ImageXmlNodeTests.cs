using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ZPLForge.Common;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization.Tests
{
    public class ImageXmlNodeTests : IClassFixture<PropertyNameFixture<ImageXmlNode>>
    {
        private readonly IReadOnlyCollection<string> propertyNames;

        public ImageXmlNodeTests(PropertyNameFixture<ImageXmlNode> fixture)
        {
            this.propertyNames = fixture.PropertyNames;
        }

        [Fact]
        public async Task EllipseXmlNodeSerializeAllPropsWhenForcedTo()
        {
            var sut = new ImageXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, true);
            foreach (var prop in propertyNames)
            {
                Assert.Contains($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task ImageXmlNodeSkipSerializingPropsWhenNotNeeded()
        {
            var sut = new ImageXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            foreach (var prop in propertyNames)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task ImageXmlNodeSerializeChangedPropWhichHasDefaults()
        {
            var sut = new ImageXmlNode() {  Compression =  CompressionType.CompressedBinary };
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            List<string> props = propertyNames.Except(new[] { nameof(ImageXmlNode.Compression) })
                .ToList();
            foreach (var prop in props)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }

            Assert.Contains($"<{nameof(ImageXmlNode.Compression)}", xml);
        }
    }
}
