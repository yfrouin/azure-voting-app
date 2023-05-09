using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace CloudWest.Functions
{
    public static class GetVotes
    {
        [Function("GetVotes")]
        public static IEnumerable<Vote> GetVotesFunction(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "vote/{eventName}")] HttpRequestData req,
            [CosmosDBInput(
                databaseName: "Votes",
                containerName: "Votes",
                Connection = "CosmosDBConnection",
                SqlQuery = "SELECT * FROM Votes where Votes.eventName = {eventName} order by Votes.id desc")]
                IEnumerable<Vote> votes)
        {
            return votes;
        }
    }
}
