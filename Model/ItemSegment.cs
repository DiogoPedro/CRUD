using Newtonsoft.Json;
namespace MyApplication.Model
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ItemSegment
    {
        public Id _id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public string CreatedByUser { get; set; }
        public string ModifiedByUser { get; set; }
        public DateCreated DateCreated { get; set; }
        public DateModified DateModified { get; set; }
        public bool Active { get; set; }
    }

}