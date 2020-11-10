using System.ComponentModel.DataAnnotations;

namespace blog.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
    }
}