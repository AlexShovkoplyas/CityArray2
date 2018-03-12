using AutoMapper;
using CityArrayDAL.UnitOfWork;
using CityArrayWeb.ModelView;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CityArrayWeb.Controllers
{
    public class WishesController : Controller
    {
        private IRepo db;
        private ILog logger;

        public WishesController(IRepo repo)
        {
            db = repo;
            logger = LogManager.GetLogger(this.GetType());
        }

        [ChildActionOnly]
        public ActionResult RecentWishes(int count=4)
        {
            var wishes = db.Wishes.GetAll().OrderByDescending(p=>p.Date).Take(count);
            var wishesView = Mapper.Map<List<WishedCityView>>(wishes);
            return PartialView("_WishesCards", wishesView);                
        }

    }
}