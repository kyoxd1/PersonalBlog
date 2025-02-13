using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticleService _articleService;
    
        public HomeController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            return View(_articleService.GetAllArticles());
        }

        public IActionResult Article(string id)
        {
            return View(_articleService.GetArticle(id));
        }
    }
}
