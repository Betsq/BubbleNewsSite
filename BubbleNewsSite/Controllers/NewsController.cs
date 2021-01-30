using BubbleNewsSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BubbleNewsSite.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsContext db;
        public NewsController(NewsContext newsContext)
        {
            db = newsContext;
        }
        public IActionResult News()
        {
            return View();
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(News news)
        {
            db.News.Add(news);
            await db.SaveChangesAsync();
            return RedirectToAction("News");
        }
        #endregion
    }
}
