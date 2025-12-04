namespace Models
{
    public class Fournisseur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Approvisionnement> Approvisionnements { get; set; } = new List<Approvisionnement>();
    }
}