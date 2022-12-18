using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KazanPaper1_7_31_2020_API;

namespace KazanPaper1_7_31_2020_API.Controllers
{
    public class GenericController : Controller
    {
        private Session1Entities db = new Session1Entities();

        public GenericController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: Generic
        public ActionResult Index()
        {
            var assets = db.Assets.Include(a => a.AssetGroup).Include(a => a.DepartmentLocation).Include(a => a.Employee);
            return View(assets.ToList());
        }

        // GET: Generic/Details/5
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

        public ActionResult GetDepartments()
        {
            return Json(db.Departments, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssetGroups()
        {
            return Json(db.AssetGroups, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssetInformation()
        {
            var assetQuery = from x in db.Assets
                             select new
                             {
                                 Asset = x,
                                 DepartmentName = x.DepartmentLocation.Department.Name,
                                 AssetGroupName = x.AssetGroup.Name
                             };
            return Json(assetQuery, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployees()
        {
            var employeeQuery = from x in db.Employees
                                select x;

            return Json(employeeQuery, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDepartmentLocations()
        {
            var departmentLocationQuery = from x in db.DepartmentLocations
                                          where x.EndDate == null
                                          select new
                                          {
                                              DepartmentName = x.Department.Name,
                                              LocationName = x.Location.Name
                                          };

            return Json(departmentLocationQuery, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssetSN(string departmentName, string assetGroup)
        {
            var departmentID = db.Departments.Where(x => x.Name.Equals(departmentName)).Select(x => x.ID).FirstOrDefault();
            var assetGroupID = db.AssetGroups.Where(x => x.Name.Equals(assetGroup)).Select(x => x.ID).FirstOrDefault();

            var currentAssetCount = db.Assets.Where(x => x.DepartmentLocation.DepartmentID == departmentID &&
            x.AssetGroupID == assetGroupID).Count();

            return Content($"{departmentID.ToString().PadLeft(2, '0')}/{assetGroupID.ToString().PadLeft(2, '0')}" +
                $"/{(++currentAssetCount).ToString().PadLeft(4, '0')}");
        }

        public ActionResult AddAsset(string assetSN, string assetName, string department,
            string location, string employee, string assetGroup, string description, string warrantyDate)
        {
            var departmentLocationID = db.DepartmentLocations.Where(x => x.Location.Name.Equals(location) && x.Department.Name.Equals(department)).FirstOrDefault();
            var employeeID = (from x in db.Employees
                              where (x.FirstName + " " + x.LastName) == employee
                              select x.ID).FirstOrDefault();

            var assetGroupID = db.AssetGroups.Where(x => x.Name.Equals(assetGroup)).FirstOrDefault();

            if (db.Assets.Where(x => x.AssetName.Equals(assetName)).Any())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DateTime? rawDate = null;
            if (!warrantyDate.Equals(string.Empty))
            {
                rawDate = DateTime.Parse(warrantyDate);
            }
            var insertAsset = new Asset
            {
                AssetName = assetName,
                AssetSN = assetSN,
                DepartmentLocationID = departmentLocationID.ID,
                EmployeeID = employeeID,
                AssetGroupID = assetGroupID.ID,
                Description = description,
                WarrantyDate = rawDate
            };

            db.Assets.Add(insertAsset);
            db.SaveChanges();
            return Json("Sucess", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssetFromID(int id)
        {
            var assetQuery = from x in db.Assets
                             where x.ID == id
                             select new
                             {
                                 Asset = x,
                                 DepartmentName = x.DepartmentLocation.Department.Name,
                                 AssetGroupName = x.AssetGroup.Name,
                                 LocationName = x.DepartmentLocation.Location.Name
                             };

            return Json(assetQuery.First(), JsonRequestBehavior.AllowGet);
        }

        // POST: Generic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
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

        // GET: Generic/Edit/5
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

        // POST: Generic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
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

        // GET: Generic/Delete/5
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

        // POST: Generic/Delete/5
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