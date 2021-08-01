``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1110 (2004/May2020Update/20H1)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4390.0), X86 LegacyJIT
  DefaultJob : .NET Framework 4.8 (4.8.4390.0), X86 LegacyJIT


```
|                        Method |     Mean |    Error |   StdDev | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------ |---------:|---------:|---------:|-----:|-------:|------:|------:|----------:|
| LoadSavedStatsIfStatementsAll | 46.85 μs | 0.716 μs | 0.635 μs |    1 | 2.3193 |     - |     - |      4 KB |
