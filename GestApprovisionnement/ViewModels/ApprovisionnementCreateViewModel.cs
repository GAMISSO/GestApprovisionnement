using System.Collections.Generic;
using Models;

namespace GestApprovisionnement.ViewModels
{
    public class ApprovisionnementCreateViewModel
    {
        public Approvisionnement Approvisionnement { get; set; } 
        public IEnumerable<Article> Articles { get; set; } = new List<Article>();
    }
}
