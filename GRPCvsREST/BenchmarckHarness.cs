using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;
using System.Threading.Tasks;
namespace RESTvsGRPC
{
    [HtmlExporter]
    public class BenchmarkHarness
    {
        [Params(100, 200)]
        public int IterationCount;

        readonly RestClient restClient = new RestClient();
        readonly GRPCClient grpcClient = new GRPCClient();

        [Benchmark]
        public async Task RestGetSmallPayloadAsync()
        {
            for(int i = 0; i < IterationCount; i++)
            {
                await restClient.GetSmallPayloadAsync();
            }
        }
        [Benchmark]
        public async Task GrpcGetSmallPayloadAsync()
        {
            for(int i = 0; i < IterationCount; i++)
            {
                await grpcClient.GetSmallPayloadAsync();
            }
        }
    }
}