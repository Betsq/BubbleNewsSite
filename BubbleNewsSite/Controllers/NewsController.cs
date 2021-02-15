using BubbleNewsSite.Models;
using BubbleNewsSite.ViewModels;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;
        public NewsController(NewsContext newsContext, UserManager<User> userManager)
        {
            db = newsContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> news(string typeNews, int page = 1)
        {

            int pageSize = 3;

            var news = from n in db.News select n;

            var count = await news.CountAsync();

            //Currently does not work together with the choice of the type of news
            if (typeNews != null)
            {
                news = news.Where(ne => ne.NewsType.Contains(typeNews) && ne.HideNews != true);
                var items = await news.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

                PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

                IndexViewModel viewModel = new IndexViewModel
                {
                    PageViewModel = pageViewModel,
                    News = items
                };
                return View(viewModel);
            }
            else
            {
                var items = await news.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

                IndexViewModel viewModel = new IndexViewModel
                {
                    PageViewModel = pageViewModel,
                    News = items
                };
                return View(viewModel);
            }
        }


        public async Task<IActionResult> NewsCRUD()
        {
            return View(await db.News.OrderByDescending(ne => ne.DateCreateNews).ToListAsync());
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
            var getFirstName = _userManager.GetUserAsync(User).Result.FirstName;
            var getLastName = _userManager.GetUserAsync(User).Result.LastName;
            string whoCreated = getFirstName + " " + getLastName;

            var getCurTime = DateTime.Now;

            var nw = new News { NewsType = news.NewsType, Article = news.Article, Description = news.Description,
                HideNews = news.HideNews, Img = news.Img, DateCreateNews = getCurTime, WhoCreated = whoCreated,
                IsNewsDay = news.IsNewsDay, IsNewsWeek = news.IsNewsWeek
            };

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
                    if (Request.Cookies.ContainsKey(news.Id.ToString()))
                    {
                        string name = Request.Cookies[news.Id.ToString()];
                    }
                    else
                    {
                        Response.Cookies.Append(news.Id.ToString(), news.Id.ToString());
                        news.CountViews += 1;
                    }

                    db.News.Update(news);

                    await db.SaveChangesAsync();

                    return View(news);
                }
            }
            return NotFound();
        }
    }
}
