using Xunit;
using PseudoRandomPrimeGeneratorNet8;

namespace PseudoRandomPrimeGeneratorNet8.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(17, true)]
    [InlineData(1, false)]
    [InlineData(0, false)]
    public void IsPrime_KnownValues_ReturnsExpected(int value, bool expected)
    {
        bool actual = Program.IsPrime(value);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GenerateRndNumberUsingCrypto_MinEqualsMax_ReturnsMin()
    {
        int min = 42;
        int max = 42;
        int result = Program.GenerateRndNumberUsingCrypto(min, max);
        Assert.Equal(min, result);
    }
}
