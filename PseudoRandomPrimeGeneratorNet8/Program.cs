using System;
using System.Security.Cryptography;

namespace PseudoRandomPrimeGeneratorNet8
{
  public class Program
  {
    static void Main()
    {
      static void Display(string s) => Console.WriteLine(s);
      Display("Pseudo random prime generator in .NET 8.0");
      Display("Searching for pseudo random prime numbers ...");
      const int numberOfPrime = 20;
      int counter = 0;
      do
      {
        int pseudoNumber = GenerateRndNumberUsingCrypto(1, 255);
        if (IsPrime(pseudoNumber))
        {
          Display($"Pseudo number is prime : {pseudoNumber}");
          counter++;
        }
      } while (counter < numberOfPrime);


      Display("Press any key to exit:");
      Console.ReadKey();
    }

    /// <summary>Calculate if an Integer number is prime.</summary>
    /// <param name="number">The number to calculate its primality.</param>
    /// <returns>Returns True if the number is a prime, False otherwise.</returns>
    public static bool IsPrime(int number)
    {
      if (number <= 1)
      {
        return false;
      }

      if (number == 2 || number == 3 || number == 5)
      {
        return true;
      }

      if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0)
      {
        return false;
      }

      int sqrt = (int)Math.Sqrt(number);
      for (int divisor = 7; divisor <= sqrt; divisor += 2)
      {
        if (number % divisor == 0)
        {
          return false;
        }
      }

      return true;
    }

    public static int GenerateRndNumberUsingCrypto(int min, int max)
    {
      if (max > 255 || min < 0)
      {
        return 0;
      }

      if (max == min)
      {
        return min;
      }

      int result;
      using var crypto = RandomNumberGenerator.Create();
      byte[] randomNumber = new byte[1];
      do
      {
        crypto.GetBytes(randomNumber);
        result = randomNumber[0];
      } while (result < min || result > max);

      return result;
    }

    /// <summary>
    /// Generate a sequence of prime numbers using a supplied random provider.
    /// The provider must return values already constrained to the desired range.
    /// </summary>
    public static IEnumerable<int> GeneratePrimes(Func<int> randomProvider, int count)
    {
      if (randomProvider == null) throw new ArgumentNullException(nameof(randomProvider));
      if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));

      int found = 0;
      while (found < count)
      {
        int candidate = randomProvider();
        if (IsPrime(candidate))
        {
          yield return candidate;
          found++;
        }
      }
    }
  }
}
