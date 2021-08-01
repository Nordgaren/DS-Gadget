``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1110 (2004/May2020Update/20H1)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4390.0), X86 LegacyJIT  [AttachedDebugger]
  DefaultJob : .NET Framework 4.8 (4.8.4390.0), X86 LegacyJIT


```
|                   Method |           Mean |         Error |        StdDev |         Median | Ratio | Rank |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |---------------:|--------------:|--------------:|---------------:|------:|-----:|-------:|-------:|------:|----------:|
|   SaveStatsDictBenchmark |      0.0028 ns |     0.0022 ns |     0.0020 ns |      0.0028 ns | 0.000 |    1 |      - |      - |     - |         - |
| SaveStatsSwitchBenchmark | 81,330.6030 ns | 1,595.8761 ns | 2,437.0713 ns | 79,855.1147 ns | 1.000 |    2 | 1.4648 | 0.7324 |     - |   2,479 B |
