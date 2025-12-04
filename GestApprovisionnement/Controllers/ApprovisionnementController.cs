using Models;

namespace GestApprovisionnement.Controllers
{
    using GestApprovisionnement.Models;
    using Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    

    public class ApprovisionnementController : Controller
    {
        private readonly IApprovisionnementService _approvisionnementService;
        private readonly ILogger<ApprovisionnementController> _logger;

        public ApprovisionnementController(IApprovisionnementService approvisionnementService,ILogger<ApprovisionnementController> logger)
        {
            _approvisionnementService = approvisionnementService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var approvisionnements = _approvisionnementService.GetAllApprovisionnements();
                return View(approvisionnements);
            }
            catch (Exception)
            {
                // Log the exception (not implemented here for brevity)
                _logger.LogError("An error occurred while loading the departement index.");
                return View(new List<Approvisionnement>());
            };
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Approvisionnement approvisionnement)
        {
            if (approvisionnement == null)
            {
                return BadRequest("Invalid approvisionnement data.");
            }

            try
            {
                var createdApprovisionnement = _approvisionnementService.CreateApprovisionnementAsync(approvisionnement);
                return Ok(createdApprovisionnement);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}