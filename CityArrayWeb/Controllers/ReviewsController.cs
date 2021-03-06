﻿using AutoMapper;
using CityArrayDAL.Model;
using CityArrayDAL.UnitOfWork;
using CityArrayWeb.ModelView;
using log4net;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using Microsoft.AspNet.Identity;

namespace CityArrayWeb.Controllers
{
    public class ReviewsController : Controller
    {
        private IRepo db;
        private ILog logger;

        public ReviewsController(IRepo repo)
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

            IEnumerable<Review> reviews = db.Reviews.GetAll();

            if (!String.IsNullOrEmpty(searchFilter))
            {
                reviews = reviews.Where(r => r.City.Name.Contains(searchFilter));
            }

            IEnumerable<ReviewInfo> reviewsShort = Mapper.Map<List<ReviewInfo>>(reviews);

            reviewsShort = reviewsShort.OrderBy(sortFilter);

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(reviewsShort.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ListByCity(int? cityId)
        {
            //var cityId = db.Reviews.GetOne(reviewId).City.Id;
            //var reviews = db.Reviews.GetAll().Where(c => c.City.Id == cityId && c.Id != reviewId).Take(count);
            //var reviewsShort = Mapper.Map<List<ReviewInfo>>(reviews);

            return View();
        }

        public ActionResult ListByPerson(int? personId)
        {            
            var reviews = db.Reviews.GetAll().Where(c => c.Person.Id == personId);
            var reviewsShort = Mapper.Map<List<ReviewInfo>>(reviews);

            return View(reviewsShort);
        }

        public ActionResult Info(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var review = db.Reviews.GetOne(id.GetValueOrDefault());
            if (review == null)
            {
                return HttpNotFound();
            }
            var reviewView = Mapper.Map<ReviewView>(review);

            return View(reviewView);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult Add()
        {
            PopulateCitiesDropDownList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="User")]
        public ActionResult Add(ReviewModify review)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Some problems in input data. Please repeate!");
                PopulateCitiesDropDownList(int.Parse(review.CityId));
                return View(review);
            }
            try
            {
                var reviewModel = Mapper.Map<Review>(review);
                reviewModel.CreationDate = DateTime.Today;
                reviewModel.PersonId = User.Identity.GetUserId<int>();
                db.Reviews.Add(reviewModel);
                db.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Some problems on server. Please repeate!");
                PopulateCitiesDropDownList(int.Parse(review.CityId));
                return View(review);
            }
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var review = db.Reviews.GetOne(id.Value);
            if (review == null)
            {
                return HttpNotFound();
            }
            Mapper.Map<ReviewModify>(review);

            return View(review);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReviewModify review)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Some problems in input data. Please repeate!");
                PopulateCitiesDropDownList(int.Parse(review.CityId));
                return View(review);
            }
            try
            {
                var reviewModel = Mapper.Map<Review>(review);
                reviewModel.CreationDate = DateTime.Today;
                reviewModel.PersonId = 1;
                db.Reviews.Add(reviewModel);
                db.Save();
                return View();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Some problems on server. Please repeate!");
                PopulateCitiesDropDownList(int.Parse(review.CityId));
                return View(review);
            }
        }

        [ChildActionOnly]
        public ActionResult RecentReviews(int count = 4)
        {
            var reviews = db.Reviews.GetAll().OrderByDescending(p=>p.CreationDate).Take(count);
            var reviewsView = Mapper.Map<List<ReviewInfo>>(reviews);

            return PartialView("_ReviewsCards", reviewsView);
        }

        [ChildActionOnly]
        public ActionResult RecentCityReviews(int cityId, int count = 4)
        {
            var reviews = db.Reviews.GetAll().Where(p=>p.CityId == cityId).OrderByDescending(p => p.CreationDate).Take(count);
            var reviewsView = Mapper.Map<List<ReviewInfo>>(reviews);

            return PartialView("_ReviewsCards", reviewsView);
        }

        [ChildActionOnly]
        public ActionResult RecommendedReviews(int reviewId, int count)
        {
            var cityId = db.Reviews.GetOne(reviewId).City.Id;
            var reviews = db.Reviews.GetAll().Where(c => c.City.Id == cityId && c.Id != reviewId).Take(count);
            var reviewsShort = Mapper.Map<List<ReviewInfo>>(reviews);

            return PartialView("_ReviewsCards", reviewsShort);
        }

        private void PopulateCitiesDropDownList(int? cityId = null)
        {
            ViewBag.Cities = db.Cities.GetDictionary();
        }

        private void PopulateCountriesDropDownList(int? cityId = null)
        {
            ViewBag.Countries = db.Countries.GetDictionary();
        }
    }
}