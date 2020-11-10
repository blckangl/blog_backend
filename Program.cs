using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Models;
using blog.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDb();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        public static void CreateDb()
        {
            using (var context = new ArticleContext())
            {
                context.Database.EnsureCreated();

                context.Article.Add(new Article() { Name = "test", Image = "aze", Text = "azd" });
                context.SaveChanges();
            }

        }
    }
}
