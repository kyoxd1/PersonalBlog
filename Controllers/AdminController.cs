using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers
{
    public class AdminController : Controller
    {
        private readonly ArticleService _articleService;
        private readonly AuthService _authService;

        public AdminController(ArticleService articleService, AuthService authService)
        {
            _articleService = articleService;
            _authService = authService;
        }

        private bool IsAuthenticated() => HttpContext.Session.GetString("IsAdmin") == "true";

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (_authService.Authenticate(username, password))
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if (!IsAuthenticated()) return RedirectToAction("Login");
            return View(_articleService.GetAllArticles());
        }

        public IActionResult Add() => IsAuthenticated() ? View() : RedirectToAction("Login");

        [HttpPost]
        public IActionResult Add(Article article)
        {
            if (!IsAuthenticated()) return RedirectToAction("Login");
            _articleService.SaveArticle(article);
            return RedirectToAction("Dashboard");
        }

        public IActionResult Edit(string id)
        {
            if (!IsAuthenticated()) return RedirectToAction("Login");
            return View(_articleService.GetArticle(id));
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            if (!IsAuthenticated()) return RedirectToAction("Login");
            _articleService.SaveArticle(article);
            return RedirectToAction("Dashboard");
        }

        public IActionResult Delete(string id)
        {
            if (!IsAuthenticated()) return RedirectToAction("Login");
            _articleService.DeleteArticle(id);
            return RedirectToAction("Dashboard");
        }
    }
}