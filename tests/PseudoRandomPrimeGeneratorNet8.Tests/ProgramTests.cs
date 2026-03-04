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
    const int min = 42;
    const int max = 42;
    int result = Program.GenerateRndNumberUsingCrypto(min, max);
    Assert.Equal(min, result);
  }

  [Fact]
  public void GenerateRndNumberUsingCrypto_NegativeMin_ReturnsZero()
  {
    int result = Program.GenerateRndNumberUsingCrypto(-1, 50);
    Assert.Equal(0, result);
  }

  [Fact]
  public void GenerateRndNumberUsingCrypto_MaxAbove255_ReturnsZero()
  {
    int result = Program.GenerateRndNumberUsingCrypto(1, 300);
    Assert.Equal(0, result);
  }

  [Fact]
  public void GenerateRndNumberUsingCrypto_MultipleSamples_AllWithinRange()
  {
    const int min = 10;
    const int max = 20;
    for (int i = 0; i < 200; i++)
    {
      int result = Program.GenerateRndNumberUsingCrypto(min, max);
      Assert.InRange(result, min, max);
    }
  }
}
