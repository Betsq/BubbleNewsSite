using BubbleNewsSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> news(string typeNews)
        {
            var nw = from n in db.News select n;
            if (typeNews != null)
            {
                nw = nw.Where(ne => ne.NewsType.Contains(typeNews) && ne.HideNews != true);
                
                return View(await nw.OrderByDescending(ne => ne.DateCreateNews).ToListAsync());
            }
            return View(await db.News.Where(ne => ne.HideNews != true).OrderByDescending(ne => ne.DateCreateNews).ToListAsync());
        }

        public async Task<IActionResult> NewsCRUD()
        {
            return View(await db.News.ToListAsync());
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
            var getCurTime = DateTime.Now;
            var nw = new News { NewsType = news.NewsType, Article = news.Article, Description = news.Description,
                HideNews = news.HideNews, Img = news.Img, DateCreateNews = getCurTime };
            db.News.Add(nw);
            await db.SaveChangesAsync();
            return RedirectToAction("News");
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                News news = await db.News.FirstOrDefaultAsync(n => n.Id == id);
                if (news != null)
                    return View(news); 
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(News news)
        {
            db.News.Update(news);
            await db.SaveChangesAsync();
            return RedirectToAction("News");
        }
        #endregion

        #region Details
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                News news = await db.News.FirstOrDefaultAsync(n => n.Id == id);
                if (news != null)
                    return View(news);
            }
            return NotFound();
        }
        #endregion

        #region Delete
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                News news = await db.News.FirstOrDefaultAsync(p => p.Id == id);
                if (news != null)
                    return View(news);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            News news = await db.News.FirstOrDefaultAsync(p => p.Id == id);
            if (news != null)
            {
                db.News.Remove(news);
                await db.SaveChangesAsync();
                return RedirectToAction("News");
            }
            return NotFound();
        }
        #endregion

        public async Task<IActionResult> NewsPage(int? id)
        {
            if (id != null)
            {
                News news = await db.News.FirstOrDefaultAsync(ne => ne.Id == id);
                if (news != null)
                {
                    return View(news);
                }
            }
            return NotFound();
        }
    }
}
