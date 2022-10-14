using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using Sqlmvcconnection.Models;
using System.Data.Entity;

namespace Sqlmvcconnection.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        Mvcappdb db = new Mvcappdb();
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        public ActionResult Details(int Id = 0)
        {
            Student st = db.Students.Find(Id);
            return View(st);
        }
        // for insert values in database
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student st)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st);
        }
        // for edit the values
        public ActionResult Edit(int id=0)
        {
            Student st = db.Students.Find(id);
            if(st == null)
            {
                return HttpNotFound();
            }
            return View(st);
        }
        [HttpPost]
        public ActionResult Edit(Student st)
        {
            if (ModelState.IsValid)
            {
                db.Entry(st).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st);
        }
        public ActionResult Delete(int id = 0)
        {
            Student st = db.Students.Find(id);
            if(st == null)
            {
                return HttpNotFound();
            }
            return View(st);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Student st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}