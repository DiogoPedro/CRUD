
using Newtonsoft.Json;
namespace MyApplication.Model
{
    public class ListAttClient
    {
        public Id _id { get; set; }
        public DateCreated DateCreated { get; set; }
        public DateModified DateModified { get; set; }
        public bool Active { get; set; }
        public string CreatedByUser { get; set; }
        public string ModifiedByUser { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
    
        public ListAttClient(Id _id, DateCreated DateCreated, DateModified DateModified, bool Active, string CreatedByUser, string ModifiedByUser, string Nome, string Descrição)
        {
            this._id = _id;
            this.DateCreated = DateCreated;
            this.DateModified = DateModified;
            this.Active = Active;
            this.CreatedByUser = CreatedByUser;
            this.ModifiedByUser = ModifiedByUser;
            this.Nome = Nome;
            this.Descrição = Descrição;
        }
    }

    public class PutClient
    {
        public Id _id { get; set; }
        public string Nome { get; set; }
        public string Site { get; set; }
        public SegmentClients Segmento { get; set; }

        [JsonProperty("ListAttClient")]
        public List<ListAttClient> _ListAttClient { get; set; }
        public bool Active { get; set; }

        public PutClient(Id _id, string nome, string site, SegmentClients seg, List<ListAttClient> list, bool Atv)
        {
            this._id = _id;
            this.Nome = nome;
            this.Site = site;
            this.Segmento = seg;
            this._ListAttClient = list;
            this.Active = Atv;
        }
    }
}