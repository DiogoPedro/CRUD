using Newtonsoft.Json;
namespace MyApplication.Model
{
    public class Datum
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

    public class Segment
    {
        public List<Datum> data { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }
}