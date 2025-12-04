namespace Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int montant { get; set; }
        public List<Approvisionnement> Approvisionnements { get; set; } = new List<Approvisionnement>();
    }
}