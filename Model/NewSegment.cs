namespace MyApplication.Model
{
    public class NewSegment
    {
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public string CreatedByUser { get; set; }

        public NewSegment(string Nome, string Descrição, string CreatedByUser)
        {
            this.Nome = Nome;
            this.Descrição = Descrição;
            this.CreatedByUser = CreatedByUser;
        }
    }
}