using Microsoft.Azure.Functions.Worker;

namespace CloudWest.Functions
{
    public static class CosmosDBTrigger
    {
        [Function("CosmosDBTrigger")]
        [SignalROutput(HubName = "votes")]
        public static SignalRMessageAction Run([CosmosDBTrigger(
            databaseName: "Votes",
            containerName: "Votes",
            Connection = "CosmosDBConnection",
            LeaseContainerName = "VotesLeases",
            CreateLeaseContainerIfNotExists = true)] IReadOnlyList<Vote> votes)
        {
            return new SignalRMessageAction("votesUpdated", new[] { votes });
        }
    }
}