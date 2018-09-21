using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSLWebAPIAuth.Models;

namespace SSLWebAPIAuth.Controllers
{
    
    public class UserModulesController : Controller
    {
        private Entities db = new Entities();

        // GET: UserModules
        public ActionResult Index()
        {
            var userModules = db.UserModules.Include(u => u.AspNetUser).Include(u => u.Module);
            return View(userModules.ToList());
        }

        // GET: UserModules/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModule userModule = db.UserModules.Find(id);
            if (userModule == null)
            {
                return HttpNotFound();
            }
            return View(userModule);
        }

        // GET: UserModules/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.MacAddress = new SelectList(db.Modules, "MacAddress", "MacAddress");
            return View();
        }

        // POST: UserModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MacAddress,DateIssued")] UserModule userModule)
        {
            if (ModelState.IsValid)
            {
                db.UserModules.Add(userModule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", userModule.Id);
            ViewBag.MacAddress = new SelectList(db.Modules, "MacAddress", "MacAddress", userModule.MacAddress);
            return View(userModule);
        }

        // GET: UserModules/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModule userModule = db.UserModules.Find(id);
            if (userModule == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", userModule.Id);
            ViewBag.MacAddress = new SelectList(db.Modules, "MacAddress", "MacAddress", userModule.MacAddress);
            return View(userModule);
        }

        // POST: UserModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MacAddress,DateIssued")] UserModule userModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", userModule.Id);
            ViewBag.MacAddress = new SelectList(db.Modules, "MacAddress", "MacAddress", userModule.MacAddress);
            return View(userModule);
        }

        // GET: UserModules/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModule userModule = db.UserModules.Find(id);
            if (userModule == null)
            {
                return HttpNotFound();
            }
            return View(userModule);
        }

        // POST: UserModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserModule userModule = db.UserModules.Find(id);
            db.UserModules.Remove(userModule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
