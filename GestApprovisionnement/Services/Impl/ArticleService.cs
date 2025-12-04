using Data;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class ArticleService : IArticleService
    {
        private readonly GestAppDbContext _context;
        private readonly ILogger<ArticleService> _logger;

        public ArticleService(GestAppDbContext context, ILogger<ArticleService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Models.Article> CreateArticle(Models.Article article)
        {
            try
            {
                _context.Articles.Add(article);
                await _context.SaveChangesAsync();
                return article;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating article");
                throw;
            }
        }

        public IEnumerable<Models.Article> GetAllArticles()
        {
            try
            {
                return _context.Articles.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all articles");
                throw;
            }
        }

        public Models.Article GetArticleByIdAsync(int id)
        {
            try
            {
                return _context.Articles.FirstOrDefault(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving article with id {id}");
                throw;
            }
        }
    }
}