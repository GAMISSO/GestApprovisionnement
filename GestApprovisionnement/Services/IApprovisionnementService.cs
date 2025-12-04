using Models;

namespace Services
{
    public interface IApprovisionnementService
    {
        IEnumerable<Approvisionnement> GetAllApprovisionnements();
    }
}