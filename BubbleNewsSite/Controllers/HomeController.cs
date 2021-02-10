using BubbleNewsSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BubbleNewsSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

       private readonly  NewsContext db;

        public HomeController(ILogger<HomeController> logger, NewsContext newsContext)
        {
            db = newsContext;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var news = from nw in db.News select nw;
            return View(await db.News.Where(ne => ne.HideNews != true).OrderByDescending(ne => ne.DateCreateNews).ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
