using System.Collections.Generic;
using blog.Models;
using blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    
    [ApiController]
    [Route("api/articles")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;
        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }
        
        [HttpGet]
        public List<Article> getAll()
        {
            return _articleService.getAllArticles();
        }

        [HttpPut("{id}")]
        public Article UpdateArticle(long id, Article art)
        {
           return _articleService.UpdateArticle(id, art);
        }

        [HttpGet("{id}")]
        public Article getArticleById(long id)
        {
            return _articleService.GetArticleByd(id);
        }

        [HttpDelete("{id}")]
        public bool DeleteArticle(long id)
        {
            return _articleService.DeleteArticle(id);
        }
    }
}