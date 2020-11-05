using Xunit;
using ZPLForge.Configuration;

namespace ZPLForge.Tests
{
    public class LabelContentTests
    {
        internal class CustomElement : LabelContent { }

        [Fact]
        public void LabelContentIsCreatedWithDefaults()
        {
            var sut = new CustomElement();
            Assert.Equal(ZPLForgeDefaults.Elements.FieldOrigin, sut.FieldOrigin);
            Assert.Equal(ZPLForgeDefaults.Elements.FieldReversePrint, sut.FieldReversePrint);
            Assert.Equal(ZPLForgeDefaults.Elements.PositionX, sut.PositionX);
            Assert.Equal(ZPLForgeDefaults.Elements.PositionY, sut.PositionY);
        }
    }
}
