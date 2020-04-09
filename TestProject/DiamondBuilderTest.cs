using System;
using Xunit;
using Xunit.Abstractions;

namespace TestProject
{
    public class DiamondBuilderTest
    {
        DiamondBuilder _diamondBuilder;

        public DiamondBuilderTest(ITestOutputHelper outputHelper)
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

        [Fact]
        public void Build_F_ReturnsExpected()
        {
            var result = _diamondBuilder.Build('F');
            var expectedCount = 11;
            Assert.Equal(expectedCount, result.Length);

            Assert.Equal("     A     ", result[0]);
            Assert.Equal("    B B    ", result[1]);
            Assert.Equal("   C   C   ", result[2]);
            Assert.Equal("  D     D  ", result[3]);
            Assert.Equal(" E       E ", result[4]);
            Assert.Equal("F         F", result[5]);
            Assert.Equal("     A     ", result[expectedCount - 1]);
            Assert.Equal("    B B    ", result[expectedCount - 2]);
            Assert.Equal("   C   C   ", result[expectedCount - 3]);
            Assert.Equal("  D     D  ", result[expectedCount - 4]);
            Assert.Equal(" E       E ", result[expectedCount - 5]);

        }


        [Fact]
        public void Build_N_ReturnsExpected()
        {
            var result = _diamondBuilder.Build('N');
            var expectedCount = 27;
            Assert.Equal(expectedCount, result.Length);

            Assert.Equal("             A             ", result[0]);
            Assert.Equal("            B B            ", result[1]);
            Assert.Equal("           C   C           ", result[2]);
            Assert.Equal("          D     D          ", result[3]);
            Assert.Equal("         E       E         ", result[4]);
            Assert.Equal("        F         F        ", result[5]);
            Assert.Equal("       G           G       ", result[6]);
            Assert.Equal("      H             H      ", result[7]);
            Assert.Equal("     I               I     ", result[8]);
            Assert.Equal("    J                 J    ", result[9]);
            Assert.Equal("   K                   K   ", result[10]);
            Assert.Equal("  L                     L  ", result[11]);
            Assert.Equal(" M                       M ", result[12]);
            Assert.Equal("N                         N", result[13]);
            Assert.Equal("             A             ", result[expectedCount - 1]);
            Assert.Equal("            B B            ", result[expectedCount - 2]);
            Assert.Equal("           C   C           ", result[expectedCount - 3]);
            Assert.Equal("          D     D          ", result[expectedCount - 4]);
            Assert.Equal("         E       E         ", result[expectedCount - 5]);
            Assert.Equal("        F         F        ", result[expectedCount - 6]);
            Assert.Equal("       G           G       ", result[expectedCount - 7]);
            Assert.Equal("      H             H      ", result[expectedCount - 8]);
            Assert.Equal("     I               I     ", result[expectedCount - 9]);
            Assert.Equal("    J                 J    ", result[expectedCount - 10]);
            Assert.Equal("   K                   K   ", result[expectedCount - 11]);
            Assert.Equal("  L                     L  ", result[expectedCount - 12]);
            Assert.Equal(" M                       M ", result[expectedCount - 13]);

        }
    }

}
