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
    public class ResourcesController : Controller
    {
        private Session1Entities db = new Session1Entities();

        public ResourcesController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }
        // GET: Resources
        [HttpPost]
        public ActionResult Index()
        {
            var resources = db.Resources;
            return Json(resources);
        }

        // GET: Resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "resId,resName,resTypeIdFK,remainingQuantity")] Resource resource, string resType)
        {
            resource.resTypeIdFK = db.Resource_Type.Where(x => x.resTypeName.Equals(resType)).Select(x => x.resTypeId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                db.Resources.Add(resource);
                db.SaveChanges();
                return Json(resource);
            }

            ViewBag.resTypeIdFK = new SelectList(db.Resource_Type, "resTypeId", "resTypeName", resource.resTypeIdFK);
            return View(resource);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            ViewBag.resTypeIdFK = new SelectList(db.Resource_Type, "resTypeId", "resTypeName", resource.resTypeIdFK);
            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resId,resName,resTypeIdFK,remainingQuantity")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.resTypeIdFK = new SelectList(db.Resource_Type, "resTypeId", "resTypeName", resource.resTypeIdFK);
            return View(resource);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
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
