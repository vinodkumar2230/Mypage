using Mypage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mypage.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Home
        public ActionResult Index()
        {
            //List<Employee> dbList = new List<Employee>();

            //    Employee db = new Employee();
            //    db.Id = 1;
            //    db.Name = "Nilesh";
            //    dbList.Add(db);

            return View(db.Employeess.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employees employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Employeess.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(employee);
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Details()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Employees employee = db.Employeess.Find(Id);
            if (employee == null)
                return HttpNotFound();
            return View(employee);
        }
        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            {
                if (Id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Employees employee = db.Employeess.Find(Id);
                if (employee == null)
                    return HttpNotFound();
                return View(employee);
            }
        }
        [HttpPost]
        public ActionResult Edit(Employees employe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(employe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employe);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            {
                if (Id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Employees employee = db.Employeess.Find(Id);
                if (employee == null)
                    return HttpNotFound();
                return View(employee);
            }
        }
        [HttpPost]
        public ActionResult Delete(int? Id, Employees employ)
        {
            try
            {
                Employees em = new Employees();
                if (ModelState.IsValid)
                {
                    if (Id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    employ = db.Employeess.Find(Id);
                    if (employ == null)
                        return HttpNotFound();
                    db.Employeess.Remove(employ);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                return View(employ);
            }
            catch
            {
                return View();
            }
        }




    }

}
