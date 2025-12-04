using Models;

namespace Services
{
    public interface IApprovisionnementService
    {
        Task<Approvisionnement> CreateApprovisionnementAsync(Approvisionnement approvisionnement);
        IEnumerable<Approvisionnement> GetApprovisionnementByIdAsync(int id);
        IEnumerable<Approvisionnement> GetAllApprovisionnements();
    }
}