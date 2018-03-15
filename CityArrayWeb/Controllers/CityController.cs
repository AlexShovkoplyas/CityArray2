using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityArrayDAL.UnitOfWork;
using AutoMapper;
using CityArrayDAL.Model;
using System.IO;
using CityArrayWeb.ModelView;
using System.Net;
using System.Linq.Dynamic;
using PagedList;
using log4net;
using Newtonsoft.Json;

namespace CityArrayWeb.Controllers
{
    public class CityController : Controller
    {
        private IRepo db;
        private ILog logger;

        public CityController(IRepo repo)
        {
            db = repo;
            logger = LogManager.GetLogger(this.GetType());
        }

        public ActionResult Info(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cities = db.Cities.GetOne(id.Value);
            if (cities == null)
            {
                return HttpNotFound();
            }
            var cityView = Mapper.Map<CityView>(cities);

            return View(cityView);
        }

        public ActionResult List(string sortFilter, string searchFilter, int? page)
        {
            sortFilter = sortFilter ?? "Id ascending";
            ViewBag.sortFilter = sortFilter;
            ViewBag.searchFilter = searchFilter;

            IEnumerable<City> cities = db.Cities.GetAll();

            //ViewBag.countryId = countryId;
            //if (countryId.HasValue)
            //{
            //    cities = cities.Where(c => c.CountryId == countryId);
            //}

            if (!String.IsNullOrEmpty(searchFilter))
            {
                cities = cities.Where(c => c.Name.Contains(searchFilter));
            }

            IEnumerable<CityInfo> citiesInfo = Mapper.Map<List<CityInfo>>(cities);

            citiesInfo = citiesInfo.OrderBy(sortFilter);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(citiesInfo.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cityModel = db.Cities.GetOne(id.Value);

            if (cityModel == null)
            {
                return HttpNotFound();
            }

            var cityView = Mapper.Map<CityModify>(cityModel);

            ViewBag.Countries = db.Countries.GetDictionary();

            return View(cityView);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CityModify cityView, HttpPostedFileBase picture)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please check all values and try again!");
                return View(cityView);
            }

            if (db.Cities.GetByName(cityView.Name, cityView.CountryId) != null)
            {
                ModelState.AddModelError(string.Empty, "This city is epsent on the site!");
                return View(cityView);
            }

            try
            {
                var cityModel = Mapper.Map<City>(cityView);
                db.Cities.Update(cityModel);

                if (picture.ContentLength > 0)
                {
                    var directoryPath = Path.Combine(Server.MapPath("~/Pictures/City"), cityModel.Id.ToString());
                    Directory.CreateDirectory(directoryPath);
                    var filePath = Path.Combine(directoryPath, "main.jpg");
                    picture.SaveAs(filePath);
                }

                db.Save();

                return View(cityView);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");

                return View(cityView);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            PopulateCountriesDropDownList();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CityModify cityView, HttpPostedFileBase picture)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please check all values and try again!");
                PopulateCountriesDropDownList(cityView.CountryId);
                return View(cityView);
            }

            if (db.Cities.GetByName(cityView.Name, cityView.CountryId) != null)
            {
                ModelState.AddModelError(string.Empty, "This city is already exist on our site!");
                PopulateCountriesDropDownList(cityView.CountryId);
                return View(cityView);
            }

            var cityModel = Mapper.Map<City>(cityView);
            var addedCity = db.Cities.Add(cityModel);
            db.Save();

            if (picture?.ContentLength > 0)
            {
                var directoryPath = Path.Combine(Server.MapPath("~/Images/City"), addedCity.Id.ToString());
                Directory.CreateDirectory(directoryPath);
                var filePath = Path.Combine(directoryPath, "1.jpg");
                picture.SaveAs(filePath);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var coordinates = db.Cities.GetAll().Select(p => new CityCoord
            {
                Latitude = p.Latitude,
                Longitude = p.Longitude,
                CityId = p.Id,
                CityName = p.Name
            });

            var model = new CityIndex()
            {
                CoordinatesJson = JsonConvert.SerializeObject(coordinates, Formatting.None)
            };

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult MostReviewedCities(int count = 4)
        {
            var citiesModel = db.Cities.MostReviewedCities(count);
            var citiesView = Mapper.Map<List<CityInfo>>(citiesModel);

            return PartialView("_citiesCards", citiesView);
        }

        private void PopulateCitiesDropDownList(int? cityId = null)
        {
            var cities = db.Cities.GetAll().Select(c => new { c.Id, c.Name });
            ViewBag.Cities = new SelectList(cities, "Id", "Name", cityId);
        }

        private void PopulateCountriesDropDownList(int? cityId = null)
        {
            ViewBag.Countries = db.Countries.GetDictionary();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }


}