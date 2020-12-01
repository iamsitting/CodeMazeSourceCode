``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.7 (19H2) [Darwin 19.6.0]
Intel Core i5-4260U CPU 1.40GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  DefaultJob : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT


```
|                   Method | IterationCount |     Mean |    Error |   StdDev |   Median |
|------------------------- |--------------- |---------:|---------:|---------:|---------:|
| **RestGetSmallPayloadAsync** |            **100** | **381.1 ms** |  **6.62 ms** |  **6.80 ms** | **378.2 ms** |
| GrpcGetSmallPayloadAsync |            100 | 244.6 ms |  4.88 ms | 13.20 ms | 237.9 ms |
| **RestGetSmallPayloadAsync** |            **200** | **819.0 ms** | **22.27 ms** | **64.98 ms** | **813.9 ms** |
| GrpcGetSmallPayloadAsync |            200 | 509.7 ms | 10.04 ms | 26.44 ms | 501.5 ms |
