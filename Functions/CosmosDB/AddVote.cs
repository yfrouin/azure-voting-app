using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using My.Namespace.models;
using System.Net;

namespace CloudWest.Functions
{
    public static class AddVote
    {
        [Function("AddVote")]
        public static VoteResponse AddVoteFunction(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "vote/{eventName}/{voteId}/{side}")] HttpRequestData req,
            [CosmosDBInput(databaseName: "Votes", containerName: "Votes", Id = "{voteId}", PartitionKey = "{eventName}", Connection = "CosmosDBConnection")] Vote voteIn,
            string side)
        {
            if (side == "left")
            {
                voteIn.leftVotes++;
            }
            else
            {
                voteIn.rightVotes++;
            }
            return new VoteResponse()
            {
                Vote = voteIn,
                HttpResponse = req.CreateResponse(HttpStatusCode.OK)
            };
        }
    }
}