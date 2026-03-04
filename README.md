
# [![.NET Build](https://github.com/fredatgithub/PseudoRandomPrimeGeneratorNET8/actions/workflows/dotnet.yml/badge.svg)](https://github.com/fredatgithub/PseudoRandomPrimeGeneratorNET8/actions) [![Codecov](https://img.shields.io/codecov/c/gh/fredatgithub/PseudoRandomPrimeGeneratorNET8?branch=main)](https://codecov.io/gh/fredatgithub/PseudoRandomPrimeGeneratorNET8)

# PseudoRandomPrimeGeneratorNET8

Petit utilitaire en .NET 8 qui génère des nombres pseudo-aléatoires via `RandomNumberGenerator` et affiche les nombres premiers trouvés dans une plage donnée.

## **Coverage Summary (latest CI run)**

- **Line coverage:** **35.2%** (12 / 34 coverable lines)
- **Branch coverage:** **56.2%** (18 / 32)
- **Method coverage:** **66.6%** (2 / 3)
- **Files analysed:** 1 — `PseudoRandomPrimeGeneratorNet8/Program.cs`

- **Main weaknesses:**
	- `Main` (entry point) is not covered by tests (0%);
	- `GenerateRndNumberUsingCrypto` has low coverage (27.27%) — the RNG loop and boundary cases are not exercised;
	- Add tests for invalid inputs (min < 0, max > 255) and for the RNG loop behavior.

- **Useful links (local artifact):**
	- Summary XML: [coverage-report-5766319688/coverage-report/Summary.xml](coverage-report-5766319688/coverage-report/Summary.xml#L1-L20)
	- Detailed report: [coverage-report-5766319688/coverage-report/PseudoRandomPrimeGeneratorNet8_Program.xml](coverage-report-5766319688/coverage-report/PseudoRandomPrimeGeneratorNet8_Program.xml#L1-L120)

- **Next steps to improve coverage:**
	1. Extract logic from `Main` into a testable method (already added `GeneratePrimes(Func<int>, int)`).
	2. Add deterministic tests for `GenerateRndNumberUsingCrypto` (edge cases + property tests asserting values are in range).
	3. Add tests for the new `GeneratePrimes` method covering candidate filtering and count.
	4. Re-run CI and aim for >=80% line coverage on core logic.

## Exécution

Pour compiler et exécuter :

```powershell
dotnet run --project PseudoRandomPrimeGeneratorNet8
```

Le programme cherche 20 nombres premiers dans la plage 1–255 et les affiche.

## Licence

MIT — voir `LICENSE`.
