using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ZPLForge.XmlSerialization.Tests
{
    public class SymbolXmlNodeTests : IClassFixture<PropertyNameFixture<SymbolXmlNode>>
    {
        private readonly IReadOnlyCollection<string> propertyNames;

        public SymbolXmlNodeTests(PropertyNameFixture<SymbolXmlNode> fixture)
        {
            this.propertyNames = fixture.PropertyNames;
        }

        [Fact]
        public async Task SymbolXmlNodeSerializeAllPropsWhenForcedTo()
        {
            var sut = new SymbolXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, true);
            foreach (var prop in propertyNames)
            {
                Assert.Contains($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task SymbolXmlNodeSkipSerializingPropsWhenNotNeeded()
        {
            var sut = new SymbolXmlNode();
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            foreach (var prop in propertyNames)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }
        }

        [Fact]
        public async Task SymbolXmlNodeSerializeChangedPropWhichHasDefaults()
        {
            var sut = new SymbolXmlNode() { Content = Common.SymbolKind.TradeMark };
            string xml = await SerializationHelper.SerializeToStringAsync(sut, false);
            List<string> props = propertyNames
                .Except(new[] { nameof(SymbolXmlNode.Content) })
                .ToList();
            foreach (var prop in props)
            {
                Assert.DoesNotContain($"<{prop}", xml);
            }

            Assert.Contains($"<{nameof(SymbolXmlNode.Content)}", xml);
        }
    }
}
