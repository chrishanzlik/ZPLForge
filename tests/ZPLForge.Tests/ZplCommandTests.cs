using Xunit;
using ZPLForge.Commands;
using ZPLForge.Common;

namespace ZPLForge.Tests
{
    public class ZplCommandTests
    {
        [Fact]
        public void ZplCommandAndParametersAreChainedTogether()
        {
            Assert.Equal("^FO500,100,0", ZPLCommand.FO(500, 100, FieldOrigin.Left));
        }

    }
}
