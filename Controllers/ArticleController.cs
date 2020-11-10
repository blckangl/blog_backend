using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Models;
using blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Renci.SshNet.Security.Cryptography;

namespace blog.Controllers
{
    
    [ApiController]
    [Route("api/articles")]
    public class ArticleController : ControllerBase
    {

        private ArticleContext _context;
        public ArticleController(ArticleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  IActionResult getAll()
        {

            var list =  _context.Article.ToList();
            return new JsonResult(list) { 
            StatusCode=200
            };
        }

        //[HttpGet("{id}")]
        //public Article getArticleById(long id)
        //{
        //}

        //[HttpPut("{id}")]
        //public Article UpdateArticle(long id, Article art)
        //{
        //}

        //[HttpDelete("{id}")]
        //public bool DeleteArticle(long id)
        //{
        //}
    }
}