namespace Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int QuantiteStock { get; set; }
        public List<Details> Detailss { get; set; } = new List<Details>();
    }
}