using Models;
using System;
using System.Linq;

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

        public ApprovisionnementController(IApprovisionnementService approvisionnementService, IArticleService articleService, ILogger<ApprovisionnementController> logger)
        {
            _approvisionnementService = approvisionnementService;
            _articleService = articleService;
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
            }
            ;
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                IEnumerable<Article> articles;
                try
                {
                    articles = _articleService.GetAllArticles() ?? Enumerable.Empty<Article>();
                }
                catch (Exception ex)
                {
                    // si le service n'est pas implémenté, on renvoie une liste vide au lieu de planter
                    _logger.LogWarning(ex, "Unable to load articles for Create view, returning empty list.");
                    articles = Enumerable.Empty<Article>();
                }

                var vm = new ApprovisionnementCreateViewModel
                {
                    Approvisionnement = new Approvisionnement { Fournisseur = new Fournisseur() },
                    Articles = articles
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error preparing Create view");
                return View(new ApprovisionnementCreateViewModel());
            }
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