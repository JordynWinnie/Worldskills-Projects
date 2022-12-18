using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KazanSession1_17_03_2020_API;

namespace KazanSession1_17_03_2020_API.Controllers
{
    public class AssetsController : Controller
    {
        public Session1Entities db = new Session1Entities();

        public AssetsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: Assets
        [HttpPost]
        public ActionResult Index()
        {   
            var assets = db.Assets;
            return Json(assets);
        }

        [HttpPost]
        public ActionResult GetDepartments()
        {
            var departments = (from x in db.DepartmentLocations
                               where x.EndDate == null
                               select x.Department.Name).Distinct();
            return Json(departments);
        }

        [HttpPost]
        public ActionResult GetAssetGroups()
        {
            var assetGroups = (from x in db.AssetGroups
                               select x.Name).Distinct();

            return Json(assetGroups);
        }

        [HttpPost]
        public ActionResult GetAssets()
        {
            var assets = from x in db.Assets
                         select new
                         {
                             UUID = x.ID,
                             AssetPhotos = x.AssetPhotos,
                             AssetName = x.AssetName,
                             DepartmentLocationID = x.DepartmentLocationID,
                             WarrantyDate = x.WarrantyDate,
                             AssetGroupName = x.AssetGroup.Name,
                             AssetSN = x.AssetSN,
                             LocationName = x.DepartmentLocation.Location.Name,
                             DepartmentName = x.DepartmentLocation.Department.Name,
                             EmployeeID = x.EmployeeID
                         };

            return Json(assets);
        }

        // GET: Assets/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // GET: Assets/Create
        public ActionResult Create()
        {
            ViewBag.AssetGroupID = new SelectList(db.AssetGroups, "ID", "Name");
            ViewBag.DepartmentLocationID = new SelectList(db.DepartmentLocations, "ID", "ID");
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AssetSN,AssetName,DepartmentLocationID,EmployeeID,AssetGroupID,Description,WarrantyDate")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Assets.Add(asset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetGroupID = new SelectList(db.AssetGroups, "ID", "Name", asset.AssetGroupID);
            ViewBag.DepartmentLocationID = new SelectList(db.DepartmentLocations, "ID", "ID", asset.DepartmentLocationID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", asset.EmployeeID);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetGroupID = new SelectList(db.AssetGroups, "ID", "Name", asset.AssetGroupID);
            ViewBag.DepartmentLocationID = new SelectList(db.DepartmentLocations, "ID", "ID", asset.DepartmentLocationID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", asset.EmployeeID);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AssetSN,AssetName,DepartmentLocationID,EmployeeID,AssetGroupID,Description,WarrantyDate")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetGroupID = new SelectList(db.AssetGroups, "ID", "Name", asset.AssetGroupID);
            ViewBag.DepartmentLocationID = new SelectList(db.DepartmentLocations, "ID", "ID", asset.DepartmentLocationID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", asset.EmployeeID);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Asset asset = db.Assets.Find(id);
            db.Assets.Remove(asset);
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
