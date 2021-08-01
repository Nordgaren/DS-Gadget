``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1110 (2004/May2020Update/20H1)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4390.0), X86 LegacyJIT  [AttachedDebugger]
  DefaultJob : .NET Framework 4.8 (4.8.4390.0), X86 LegacyJIT


```
|                   Method |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD | Rank |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |---------:|---------:|---------:|---------:|------:|--------:|-----:|-------:|-------:|------:|----------:|
| SaveStatsSwitchBenchmark | 81.08 μs | 1.587 μs | 2.607 μs | 79.69 μs |  1.00 |    0.00 |    1 | 1.4648 | 0.7324 |     - |      2 KB |
|   SaveStatsDictBenchmark | 82.74 μs | 1.638 μs | 1.950 μs | 82.28 μs |  1.02 |    0.04 |    2 | 1.4648 | 0.7324 |     - |      2 KB |
