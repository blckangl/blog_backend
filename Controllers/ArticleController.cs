﻿using System.Collections.Generic;
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
        public async Task<IActionResult> getAll()
        {

            var list = await _context.Article.ToListAsync();
            return new JsonResult(list)
            {
                StatusCode = 200
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getArticleById(int id)
        {

            Article art = await _context.Article
                                        .Where(x => x.ArticleId == id)
                                        .FirstOrDefaultAsync();



            return new JsonResult(art);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            Article art = await _context.Article
                                        .Where(x => x.ArticleId == id)
                                        .FirstOrDefaultAsync();
            var result = _context.Article.Remove(art);
            _context.SaveChanges();

            return new JsonResult("") { StatusCode = 202 };

        }

        [HttpPut("{id}")]
        public IActionResult UpdateArticle(int id, Article art)
        {
            var article = _context.Article
                                     .FirstOrDefault(x => x.ArticleId == id);

            article.Text = art.Text;
            article.Name = art.Name;
            article.Image = art.Image;

            _context.SaveChanges();

            return new JsonResult(article) { StatusCode = 201 };

        }

        [HttpPost()]
        public IActionResult AddArticle(Article art)
        {
            _context.Article.Add(art);
            _context.SaveChanges();

            return new JsonResult(art);
        }
    }
}