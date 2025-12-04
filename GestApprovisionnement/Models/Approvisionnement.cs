using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Approvisionnement
    {
        public int Id { get; set; }
        public DateTime DateApprovisionnement {get; set; }=DateTime.Now;
        [Required(ErrorMessage ="La date  est obligatoire")]
        [StringLength(50, ErrorMessage ="Le nom du département ne doit pas dépasser 50 caractères")]
        public string Référence { get; set; }
        [Required(ErrorMessage ="La date  est obligatoire")]
        public int FournisseurId { get; set; }
        public required Fournisseur Fournisseur { get; set; }
        public List<Details> Detailss { get; set; } = new List<Details>();
        public bool IsActive { get; set; }=true;
        [Required(ErrorMessage ="La date  est obligatoire")]
        public string MontantTotal { get; set; }
        public string Observations { get; set; }

    }
}