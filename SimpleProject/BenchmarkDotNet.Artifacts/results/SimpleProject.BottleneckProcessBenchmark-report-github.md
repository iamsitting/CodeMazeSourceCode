``` ini

BenchmarkDotNet=v0.12.1, OS=ubuntu 20.04
AMD FX(tm)-8350, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  DefaultJob : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT


```
|      Method |     Mean |   Error |  StdDev |
|------------ |---------:|--------:|--------:|
| GetLastItem | 202.8 ns | 0.70 ns | 0.65 ns |
