``` ini

BenchmarkDotNet=v0.12.1, OS=ubuntu 20.04
AMD FX(tm)-8350, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  DefaultJob : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT


```
|                   Method | IterationCount |     Mean |    Error |   StdDev |
|------------------------- |--------------- |---------:|---------:|---------:|
| **RestGetSmallPayloadAsync** |            **100** | **340.9 ms** |  **6.72 ms** | **11.95 ms** |
| GrpcGetSmallPayloadAsync |            100 | 182.0 ms |  3.59 ms |  6.29 ms |
| **RestGetSmallPayloadAsync** |            **200** | **686.1 ms** | **13.62 ms** | **18.18 ms** |
| GrpcGetSmallPayloadAsync |            200 | 364.8 ms |  6.40 ms |  5.99 ms |
