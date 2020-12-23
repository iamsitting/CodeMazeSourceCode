using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using SharedLibrary.Grpc;

namespace GrpcVsRest
{
    public class GRPCClient
    {
        private readonly GrpcChannel channel;
        private readonly StudentService.StudentServiceClient client;

        public GRPCClient()
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            channel = GrpcChannel.ForAddress("http://localhost:5000");
            client = new StudentService.StudentServiceClient(channel);
        }

        public async Task<Student> GetSmallPayloadAsync()
        {
            // return (await client.GetVersionAsync(new EmptyRequest())).ApiVersion;
            return (await client.GetStudentAsync(
                    new GetStudentRequest (){Id = "5fe3a38292267c002b8a376c"}
                )).Student;
        }

    }
}