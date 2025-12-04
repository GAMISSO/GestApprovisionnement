namespace Models
{
    public class Details
    {
        public int Id { get; set; }
        public int ApprovisionnementId { get; set; }
        public required Approvisionnement Approvisionnement { get; set; }
        public int ArticleId { get; set; }
        public required Article Article { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
        public decimal Montant { get; set; }

    }
}