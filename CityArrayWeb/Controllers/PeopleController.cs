using AutoMapper;
using CityArrayDAL.UnitOfWork;
using CityArrayWeb.ModelView;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using CityArrayDAL.Model;
using System.Linq.Dynamic;

namespace CityArrayWeb.Controllers
{
    public class PeopleController : Controller
    {
        private IRepo db;
        private ILog logger;

        public PeopleController(IRepo repo)
        {
            db = repo;
            logger = LogManager.GetLogger(this.GetType());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string sortFilter, string searchFilter, int? page)
        {
            sortFilter = sortFilter ?? "Id ascending";
            ViewBag.sortFilter = sortFilter;
            ViewBag.searchFilter = searchFilter;

            IEnumerable<Person> people = db.People.GetAll();

            if (!String.IsNullOrEmpty(searchFilter))
            {
                people = people.Where(r =>
                    r.NickName.Contains(searchFilter) ||
                    r.FirstName.Contains(searchFilter) ||
                    r.LastName.Contains(searchFilter));
            }

            IEnumerable<PersonInfo> peopleInfo = Mapper.Map<List<PersonInfo>>(people);

            peopleInfo = peopleInfo.OrderBy(sortFilter);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(peopleInfo.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Info(int? id)
        {
            var count = 4;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = db.People.GetOne(id.Value);
            person.Reviews = person.Reviews.OrderByDescending(r => r.CreationDate).Take(count).ToList();
            person.WishedCities = person.WishedCities.OrderByDescending(r => r.Date).Take(count).ToList();

            var personView = Mapper.Map<PersonView>(person);

            return View(personView);
        }

        public ActionResult Reviews(int? id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Person = db.People.GetOne(id.Value).NickName;

            var reviews = db.People.GetOne(id.Value).Reviews.OrderByDescending(r => r.CreationDate).ToList();

            var reviewsView = Mapper.Map<List<ReviewInfo>>(reviews);

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(reviewsView.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Wishes(int? id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Person = db.People.GetOne(id.Value).NickName;

            var wishes = db.People.GetOne(id.Value).WishedCities.OrderByDescending(r => r.Date).ToList();

            var wishesView = Mapper.Map<List<WishedCityView>>(wishes);

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(wishesView.ToPagedList(pageNumber, pageSize));
        }

        [ChildActionOnly]
        public ActionResult MostActivePeople(int count = 4)
        {
            var people = db.People.GetAll().OrderByDescending(p => p.Reviews.Count + p.WishedCities.Count);
            var peopleView = Mapper.Map<List<PersonInfo>>(people);

            return PartialView("_PeopleCards", peopleView);
        }

        [ChildActionOnly]
        public ActionResult RecentlyAddedPeople(int count = 4)
        {
            var people = db.People.GetAll().OrderByDescending(p => p.AddDay);
            var peopleView = Mapper.Map<List<PersonInfo>>(people);

            return PartialView("_PeopleCards", peopleView);
        }
    }
}