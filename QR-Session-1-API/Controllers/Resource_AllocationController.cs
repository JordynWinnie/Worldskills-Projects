using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QR_Session_1_API;

namespace QR_Session_1_API.Controllers
{
    public class Resource_AllocationController : Controller
    {
        private Session1Entities db = new Session1Entities();

        public Resource_AllocationController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: Resource_Allocation
        [HttpPost]
        public ActionResult Index()
        {
            var resource_Allocation = db.Resource_Allocation;
            return Json(resource_Allocation);
        }

        

        

        // POST: Resource_Allocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "allocId,resIdFK,skillIdFK")] Resource_Allocation resource_Allocation)
        {
            
            if (ModelState.IsValid)
            {
                var currentallocID = (db.Resource_Allocation.OrderByDescending(x => x.allocId).Select(x => x.allocId).First() + 1);
                resource_Allocation.allocId = currentallocID;
                db.Resource_Allocation.Add(resource_Allocation);
                db.SaveChanges();
                return Json(resource_Allocation);
            }
            else
            {
                return Json("Error");
            }
        }

        // GET: Resource_Allocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource_Allocation resource_Allocation = db.Resource_Allocation.Find(id);
            if (resource_Allocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.resIdFK = new SelectList(db.Resources, "resId", "resName", resource_Allocation.resIdFK);
            ViewBag.skillIdFK = new SelectList(db.Skills, "skillId", "skillName", resource_Allocation.skillIdFK);
            return View(resource_Allocation);
        }

        // POST: Resource_Allocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "allocId,resIdFK,skillIdFK")] Resource_Allocation resource_Allocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resource_Allocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.resIdFK = new SelectList(db.Resources, "resId", "resName", resource_Allocation.resIdFK);
            ViewBag.skillIdFK = new SelectList(db.Skills, "skillId", "skillName", resource_Allocation.skillIdFK);
            return View(resource_Allocation);
        }

        // GET: Resource_Allocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource_Allocation resource_Allocation = db.Resource_Allocation.Find(id);
            if (resource_Allocation == null)
            {
                return HttpNotFound();
            }
            return View(resource_Allocation);
        }

        // POST: Resource_Allocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource_Allocation resource_Allocation = db.Resource_Allocation.Find(id);
            db.Resource_Allocation.Remove(resource_Allocation);
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
