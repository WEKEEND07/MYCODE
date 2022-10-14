using Sqlmvcconnection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sqlmvcconnection.Controllers
{
    public class LayerController : Controller
    {
        // GET: Layer
        public ActionResult Index()
        {
            StudentLayer Sl = new StudentLayer();
            List<Student> st = Sl.St.ToList();
            return View(st);
        }
        public ActionResult Details(int id)
        {
            StudentLayer Sl = new StudentLayer();
            Student St = Sl.St.Single(stu => stu.Id == id);
            return View(St);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student St1)
        {
            if (ModelState.IsValid)
            {
                StudentLayer Sl = new StudentLayer();
                Sl.AddStudent(St1);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentLayer Sl = new StudentLayer();
            Student St = Sl.St.Single(stu => stu.Id == id);
            return View(St);
        }
        [HttpPost]
        public ActionResult Edit(Student St1)
        {
            if (ModelState.IsValid)
            {
                StudentLayer Sl = new StudentLayer();
                Sl.SaveStudent(St1);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            StudentLayer Sl = new StudentLayer();
            Student St = Sl.St.Single(stu =>stu.Id == id);
            return View(St);   
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentLayer Sl = new StudentLayer();
            Sl.DeleteStudent(id);
            return RedirectToAction("Index");
        }
        
    }
}