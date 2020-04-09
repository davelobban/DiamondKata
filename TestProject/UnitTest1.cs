using System;
using Xunit;
using Xunit.Abstractions;

namespace TestProject
{
    public class UnitTest1
    {
        DiamondBuilder _diamondBuilder;

        public UnitTest1(ITestOutputHelper outputHelper)
        {
            _diamondBuilder = new DiamondBuilder(outputHelper);
        }

        [Fact]
        public void Build_A_ReturnsExpected()
        {
            var result = _diamondBuilder.Build('A');
            Assert.Equal("A", result[0]);
        }

        [Fact]
        public void Build_B_ReturnsExpected()
        {
            var result = _diamondBuilder.Build('B');
            Assert.Equal(3, result.Length);
            Assert.Equal(" A ", result[0]);
            Assert.Equal("B B", result[1]);
            Assert.Equal(" A ", result[2]);
        }

        [Fact]
        public void Build_C_ReturnsExpected()
        {
            var result = _diamondBuilder.Build('C');
            Assert.Equal(5, result.Length);
            Assert.Equal("  A  ", result[0]);
            Assert.Equal(" B B ", result[1]);
            Assert.Equal("C   C", result[2]);
            Assert.Equal(" B B ", result[3]);
            Assert.Equal("  A  ", result[4]);
        }

        [Fact]
        public void Build_D_ReturnsExpected()
        {
            var result = _diamondBuilder.Build('D');
            Assert.Equal(7, result.Length);

            Assert.Equal("   A   ", result[0]);
            Assert.Equal("  B B  ", result[1]);
            Assert.Equal(" C   C ", result[2]);
            Assert.Equal("D     D", result[3]);
            Assert.Equal(" C   C ", result[4]);
            Assert.Equal("  B B  ", result[5]);
            Assert.Equal("   A   ", result[6]);
        }
    }

}
