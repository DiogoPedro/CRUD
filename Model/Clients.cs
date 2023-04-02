using Newtonsoft.Json;
namespace MyApplication.Model
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DatumClients
    {
        public Id _id { get; set; }
        public DateCreated DateCreated { get; set; }
        public DateModified DateModified { get; set; }
        public bool Active { get; set; }
        public string CreatedByUser { get; set; }
        public string ModifiedByUser { get; set; }
        public string Nome { get; set; }
        public string Site { get; set; }
        public SegmentClients Segmento { get; set; }
        public string NameSegment { get; set; }

        [JsonProperty("Datum")]
        public List<Datum> Datum { get; set; }
    }

    public class Clients
    {
        public List<DatumClients> data { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }

    public class SegmentClients
    {
        [JsonProperty("$oid")]
        public string oid { get; set; }
    }
}