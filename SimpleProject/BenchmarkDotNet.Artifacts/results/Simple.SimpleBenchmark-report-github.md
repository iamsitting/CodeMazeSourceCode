``` ini

BenchmarkDotNet=v0.12.1, OS=ubuntu 20.04
AMD FX(tm)-8350, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  DefaultJob : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT


```
|      Method |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
| GetLastName | 202.2 ns | 0.91 ns | 0.85 ns |  1.00 | 0.0248 |     - |     - |     104 B |
