using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using StudentGrpcService;

namespace RESTvsGRPC
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
                    new GetStudentRequest (){Id = "5eeffdd1a28671a6e62dbda2"}
                )).Student;
        }

    }
}