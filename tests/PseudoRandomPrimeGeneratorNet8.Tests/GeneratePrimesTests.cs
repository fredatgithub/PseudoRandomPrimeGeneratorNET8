using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using PseudoRandomPrimeGeneratorNet8;

namespace PseudoRandomPrimeGeneratorNet8.Tests;

public class GeneratePrimesTests
{
    [Fact]
    public void GeneratePrimes_WithDeterministicProvider_ReturnsExpectedPrimes()
    {
        // provider will yield a sequence of numbers where some are primes
        var seq = new Queue<int>(new[] {4,5,6,7,8,9,11,12,13,14});
        Func<int> provider = () => seq.Count > 0 ? seq.Dequeue() : 17;

        var primes = Program.GeneratePrimes(provider, 4).ToList();

        Assert.Equal(new[] {5,7,11,13}, primes);
    }

    [Fact]
    public void GeneratePrimes_CountZero_ReturnsEmpty()
    {
        Func<int> provider = () => 2;
        var primes = Program.GeneratePrimes(provider, 0).ToList();
        Assert.Empty(primes);
    }
}
