using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ZPLForge.Configuration;

namespace ZPLForge.XmlSerialization.Tests
{
    public class QrCodeXmlNodeTests : IClassFixture<PropertyNameFixture<QrCodeXmlNode>>
    {
        private readonly IReadOnlyCollection<string> propertyNames;

        public QrCodeXmlNodeTests(PropertyNameFixture<QrCodeXmlNode> fixture)
        {
            this.propertyNames = fixture.PropertyNames;
        }

        [Fact]
        public async Task QrCodeXmlNodeSerializeAllPropsWhenForcedTo()
        {
            var sut = new QrCodeXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, true);
            foreach (var prop in propertyNames)
            {
                Assert.Contains($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task QrCodeXmlNodeSkipSerializingPropsWhenNotNeeded()
        {
            var sut = new QrCodeXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            foreach (var prop in propertyNames)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task QrCodeXmlNodeSerializeChangedPropWhichHasDefaults()
        {
            var sut = new QrCodeXmlNode() { ErrorCorrection = Common.ErrorCorrection.UltraHighReliability };
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            List<string> props = propertyNames
                .Except(new[] { nameof(QrCodeXmlNode.ErrorCorrection) })
                .ToList();
            foreach (var prop in props)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }

            Assert.Contains($"<{nameof(QrCodeXmlNode.ErrorCorrection)}", xml);
        }
    }
}
