using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;

namespace My.Namespace.models
{
    public class VoteResponse
    {
        [CosmosDBOutput(databaseName: "Votes", containerName: "Votes", Connection = "CosmosDBConnection")]
        public Vote Vote { get; set; }
        public HttpResponseData HttpResponse { get; set; }
    }
}
