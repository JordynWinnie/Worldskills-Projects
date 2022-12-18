using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Covid19API;

namespace Covid19API.Controllers
{
    public class ContactTracingsController : Controller
    {
        private CovidEntities db = new CovidEntities();

        public ContactTracingsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: ContactTracings
        [HttpPost]
        public ActionResult Index()
        {
            var contactTracings = db.ContactTracings;
            return new JsonResult
            {
                Data = contactTracings
            };
        }

        [HttpPost]
        public ActionResult GetLocationID(int floorNumber, int unitNumber)
        {
            var location = db.Locations.Where(x => x.LocationFloor == floorNumber && x.LocationUnitNumber == unitNumber).FirstOrDefault();

            if (location == null)
            {
                return HttpNotFound();
            }
            else
            {
                return Json(location);
            }
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.FTEs.Where(x => x.UserID == username && x.NRIC == password).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return Json(user);
        }

        // POST: ContactTracings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,FTE_ID,LocationID,FullName,Email,Contact,Temp,RegisterDateTime,ExitDateTime")] ContactTracing contactTracing)
        {
            if (ModelState.IsValid)
            {
                contactTracing.ID = (db.ContactTracings.OrderByDescending(x => x.ID).Select(x=>x.ID).First() + 1)   ;
                db.ContactTracings.Add(contactTracing);
                db.SaveChanges();
                return Json(contactTracing);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: ContactTracings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FTE_ID,LocationID,FullName,Email,Contact,Temp,RegisterDateTime,ExitDateTime")] ContactTracing contactTracing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactTracing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FTE_ID = new SelectList(db.FTEs, "ID", "NRIC", contactTracing.FTE_ID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "LocationName", contactTracing.LocationID);
            return View(contactTracing);
        }

        

        // POST: ContactTracings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ContactTracing contactTracing = db.ContactTracings.Find(id);
            db.ContactTracings.Remove(contactTracing);
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
