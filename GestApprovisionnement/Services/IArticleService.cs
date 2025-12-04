namespace Services
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        Task<Article> CreateArticle(Article article);
        Article GetArticleByIdAsync(int id);
        IEnumerable<Article> GetAllArticles();
    }
}