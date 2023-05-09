using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using My.Namespace.models;
using System.Net;

namespace CloudWest.Functions
{
    public static class CreateVote
    {
        [Function("CreateVote")]
        public static async Task<VoteResponse> CreateVoteFunction(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "vote")] HttpRequestData req)
        {
            var vote = await req.ReadFromJsonAsync<Vote>();
            vote!.id = Guid.NewGuid().ToString();
            var response = req.CreateResponse(HttpStatusCode.OK);

            return new VoteResponse()
            {
                Vote = vote!,
                HttpResponse = response
            };
        }
    }
}