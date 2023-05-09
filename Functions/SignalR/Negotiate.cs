using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace CloudWest.Functions
{
    public static class SignalRNegotiate
    {
        [Function("negotiate")]
        public static string Negotiate(
        [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequestData req,
        [SignalRConnectionInfoInput(HubName = "votes")] string connectionInfo)
        {
            return connectionInfo;
        }
    }
}