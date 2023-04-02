using Newtonsoft.Json;
namespace MyApplication.Model
{
    public class Id
    {
        [JsonProperty("$oid")]
        public string oid { get; set; }
    }

    public class DateModified
    {
        [JsonProperty("$date")]
        public DateTime date { get; set; }
    }

    public class DateCreated
    {
        [JsonProperty("$date")]
        public DateTime date { get; set; }
    }
}