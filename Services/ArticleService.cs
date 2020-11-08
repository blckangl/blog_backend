using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using blog.Models;

namespace blog.Services
{
    public class ArticleService
    {
        private List<Article> articles = new List<Article>();
        private long id;

        public ArticleService()
        {
            articles.Add(new Article() {Id = 0, Name = "Article 1", Text = "Content 1", Image = "image_url"});
            articles.Add(new Article() {Id = 1, Name = "Article 2", Text = "Content 2", Image = "image_url"});
            articles.Add(new Article() {Id = 2, Name = "Article 3", Text = "Content 3", Image = "image_url"});

            id = articles.Count;
        }

        public Article GetArticleByd(long id)
        {
            var articleQuery = from article in articles
                where (article.Id == id)
                select article;

            var selectedArticle = articleQuery.FirstOrDefault();

            return selectedArticle;
        }

        public List<Article> getAllArticles()
        {
            return articles;
        }

        public Article AddArticle(Article art)
        {
            id++;
            var newArticle = art;
            newArticle.Id = id;
            articles.Add(newArticle);
            return newArticle;
        }

        public Article UpdateArticle(long id, Article art)
        {
            var articleQuery = from article in articles
                where (article.Id == id)
                select article;

            var selectedArticle = articleQuery.FirstOrDefault();
            if (selectedArticle == null)
            {
                return null;
            }

            selectedArticle.Name = art.Name;
            selectedArticle.Text = art.Text;
            selectedArticle.Image = art.Image;

            return selectedArticle;
        }

        public bool DeleteArticle(long id)
        {
            var articleQuery = from article in articles
                where (article.Id == id)
                select article;
            var selectedArticle = articleQuery.FirstOrDefault();
            if (selectedArticle == null)
            {
                return false;
            }

            return articles.Remove(selectedArticle);
        }
    }
}