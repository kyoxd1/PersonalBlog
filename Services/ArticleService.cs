using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public class ArticleService
    {
        private readonly string _articlesPath = Path.Combine(Directory.GetCurrentDirectory(), "Articles");

        public ArticleService()
        {
            if (!Directory.Exists(_articlesPath))
                Directory.CreateDirectory(_articlesPath);
        }

        public List<Article> GetAllArticles()
        {
            var articles = new List<Article>();
            foreach (var file in Directory.GetFiles(_articlesPath, "*.json"))
            {
                var json = File.ReadAllText(file);
                articles.Add(JsonSerializer.Deserialize<Article>(json));
            }
            return articles;
        }

        public Article GetArticle(string id)
        {
            var path = Path.Combine(_articlesPath, $"{id}.json");
            return JsonSerializer.Deserialize<Article>(File.ReadAllText(path));
        }

        public void SaveArticle(Article article)
        {
            var path = Path.Combine(_articlesPath, $"{article.Id}.json");
            var json = JsonSerializer.Serialize(article);
            File.WriteAllText(path, json);
        }

        public void DeleteArticle(string id)
        {
            var path = Path.Combine(_articlesPath, $"{id}.json");
            File.Delete(path);
        }
    }
}
