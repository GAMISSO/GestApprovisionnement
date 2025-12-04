using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Approvisionnement
    {
        public int Id { get; set; }
        public DateTime DateApprovisionnement {get; set; }=DateTime.Now;
        [Required(ErrorMessage ="Le nom du département est obligatoire")]
        [StringLength(50, ErrorMessage ="Le nom du département ne doit pas dépasser 50 caractères")]
        public string Référence { get; set; }
        public int FournisseurId { get; set; }
        public required Fournisseur Fournisseur { get; set; }
        public int ArticleId { get; set; }
        public required Article Article { get; set; }
        public bool IsActive { get; set; }=true;
        public string MontantTotal { get; set; }
        public int Quantite { get; set; }

    }
}