﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldTravelBlog.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldTravelBlog.Controllers
{
    public class PeopleController : Controller
    {
        private WorldTravelBlogContext db = new WorldTravelBlogContext();


        public IActionResult Index()
        {
            var thisPerson = db.People
                               .Include(x => x.Experience)
                               .Include(x => x.Location)
                               .ToList();
            
            return View(thisPerson);
        }

        public IActionResult Details(int id)
        {
            Person thisPerson = db.People
                               .Include(x => x.Experience)
                               .Include(x => x.Location)
                               .FirstOrDefault(x => x.PersonId == id);
            return View(thisPerson);
        }

        public IActionResult Create()
        {
            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "Description");
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "City");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisPerson = db.People.FirstOrDefault(x => x.PersonId == id);
            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "Description");
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "City");
            return View(thisPerson);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisPerson = db.People.FirstOrDefault(x => x.PersonId == id);
            return View(thisPerson);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPerson = db.People.FirstOrDefault(x => x.PersonId == id);
            db.People.Remove(thisPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
