using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IArticleService articleService,ILogger<ArticleController> logger)
        {
            _articleService = articleService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var articles = _articleService.GetAllArticles();
                return View(articles);
            }
            catch (Exception)
            {
                // Log the exception (not implemented here for brevity)
                _logger.LogError("An error occurred while loading the departement index.");
                return View(new List<Article>());
            };
        }
    }
}