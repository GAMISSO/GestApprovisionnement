using Microsoft.Extensions.Logging;
using Data;
using Models;

namespace Services
{
    public class ApprovisionnementService : IApprovisionnementService
    {
        private readonly GestAppDbContext _context;
        private readonly ILogger<ApprovisionnementService> _logger;
        private static int _currentId = 1;


        public ApprovisionnementService(GestAppDbContext context, ILogger<ApprovisionnementService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Approvisionnement> CreateApprovisionnementAsync(Approvisionnement approvisionnement)
        {
            approvisionnement.Id = _currentId++;
            _context.Approvisionnements.Add(approvisionnement);
            return await Task.FromResult(approvisionnement);
        }

        public IEnumerable<Approvisionnement> GetApprovisionnementByIdAsync(int id)
        {
            var result = _context.Approvisionnements.Where(a => a.Id == id);
            return result;
        }

        public IEnumerable<Approvisionnement> GetAllApprovisionnements()
        {
            try
            {
                return _context.Approvisionnements
                .Where(d => d.IsActive)
                .OrderByDescending(d => d.DateApprovisionnement)
                .ToList();
                // _logger.LogInformation("Fetching departements from database.");
            }
            catch (Exception)
            {
                _logger.LogError( "An error occurred while fetching departements.");
                throw;
            }
        }
    }
}