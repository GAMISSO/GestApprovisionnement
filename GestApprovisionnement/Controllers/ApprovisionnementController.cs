using Models;
using System;
using System.Linq;
using Data;
using Microsoft.Extensions.Logging;

namespace GestApprovisionnement.Controllers
{
    using GestApprovisionnement.Models;
    using GestApprovisionnement.ViewModels;
    using Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ApprovisionnementController : Controller
    {
        private readonly IApprovisionnementService _approvisionnementService;
        private readonly IArticleService _articleService;
        private readonly ILogger<ApprovisionnementController> _logger;
        private readonly GestAppDbContext _context;

        public ApprovisionnementController(IApprovisionnementService approvisionnementService, IArticleService articleService, ILogger<ApprovisionnementController> logger, GestAppDbContext context)
        {
            _approvisionnementService = approvisionnementService;
            _articleService = articleService;
            _logger = logger;
            _context = context;
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
            }
            ;
        }

        // [HttpGet("DebugCounts")]
        // public IActionResult DebugCounts()
        // {
        //     try
        //     {
        //         var total = _context.Approvisionnements.Count();
        //         var active = _context.Approvisionnements.Count(a => a.IsActive);
        //         var sample = _context.Approvisionnements
        //             .OrderByDescending(a => a.DateApprovisionnement)
        //             .Take(5)
        //             .Select(a => new { a.Id, a.Référence, a.IsActive, a.FournisseurId })
        //             .ToList();

        //         return Json(new { total, active, sample });
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex, "Error executing DebugCounts");
        //         return StatusCode(500, ex.Message);
        //     }
        // }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
            // si le service n'est pas implémenté, on 
        }



    }
}