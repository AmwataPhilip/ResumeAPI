using Amazon.DynamoDBv2.DataModel;

namespace ResumeAPI.Models
{
    [DynamoDBTable("VisitorCount")]
    public class VisitorCount
    {
        [DynamoDBProperty("Count")]
        public int? Count { get; set; }

        [DynamoDBHashKey("SiteUuid")]
        public string? SiteUuid { get; set; }
    }
}