using Newtonsoft.Json;
namespace MyApplication.Model
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ItemSegment
    {
        public Id _id { get; set; }
        public DateCreated DateCreated { get; set; }
        public DateModified DateModified { get; set; }
        public bool Active { get; set; }
        public string CreatedByUser { get; set; }
        public object ModifiedByUser { get; set; }
        public string Nome { get; set; }
        public object Descrio { get; set; }
    }

}