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
        public IActionResult News()
        {
            return View(db.News.ToList());
        }

        public async Task<IActionResult> NewsCDDE()
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
            db.News.Add(news);
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
                    return View(); 
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
    }
}
