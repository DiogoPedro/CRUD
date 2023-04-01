using Newtonsoft.Json;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DateCreatedItemSegment
    {
        [JsonProperty("$date")]
        public DateTime date { get; set; }
    }

    public class DateModifiedItemSegment
    {
        [JsonProperty("$date")]
        public DateTime date { get; set; }
    }

    public class IdItemSegment
    {
        [JsonProperty("$oid")]
        public string oid { get; set; }
    }

    public class ItemSegment
    {
        public Id _id { get; set; }
        public string Nome { get; set; }
        public object Descrio { get; set; }
        public string CreatedByUser { get; set; }
        public object ModifiedByUser { get; set; }
        public DateCreated DateCreated { get; set; }
        public DateModified DateModified { get; set; }
        public bool Active { get; set; }
    }
