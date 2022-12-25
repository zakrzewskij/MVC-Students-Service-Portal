using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projektMVC.Helpers;
using projektMVC.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace projektMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var welcomeMessage = GetWelcomeMessage(User.Claims);
            return View(new Home()
            {
                WelcomeMessage= welcomeMessage
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private string GetWelcomeMessage(IEnumerable<Claim> claims)
        {
            var isNormalUser = GroupHelpers.IsNormalUser(claims);
            return $"Jesteś {(isNormalUser 
                ? "normalnym użytkownikiem (nie masz praw administratora)" 
                : "administratorem 😎")}";
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}