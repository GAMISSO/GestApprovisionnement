using Data;

namespace Services
{
    public class ArticleService : IArticleService
    {
        private readonly GestAppDbContext _context;
        private readonly ILogger<ApprovisionnementService> _logger;
        public Task<Models.Article> CreateArticle(Models.Article article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Article> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public Models.Article GetArticleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}