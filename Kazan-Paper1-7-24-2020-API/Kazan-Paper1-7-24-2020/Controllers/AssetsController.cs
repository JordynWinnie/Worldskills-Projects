using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kazan_Paper1_7_24_2020;

namespace Kazan_Paper1_7_24_2020.Controllers
{
    public class AssetsController : Controller
    {
        private Session1Entities db = new Session1Entities();

        public AssetsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: Assets
        public ActionResult Index()
        {
            var assets = db.Assets.Include(a => a.AssetGroup).Include(a => a.DepartmentLocation).Include(a => a.Employee);
            return View(assets.ToList());
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
            var assetInfo = from x in db.Assets
                            select new
                            {
                                x.AssetName,
                                DepartmentName = x.DepartmentLocation.Department.Name,
                                x.AssetSN,
                                AssetGroupName = x.AssetGroup.Name,
                                x.WarrantyDate,
                            };
            return Json(assetInfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDepartmentLocations()
        {
            var departmentLocationInformation = from x in db.DepartmentLocations
                                                where x.EndDate == null
                                                select new
                                                {
                                                    DepartmentName = x.Department.Name,
                                                    DepartmentLocationName = x.Location.Name
                                                };
            return Json(departmentLocationInformation, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CalculateSN(string department, string assetGroup)
        {
            var departmentID = db.Departments.Where(x => x.Name.Equals(department)).Select(x => x.ID).First();
            var assetGroupID = db.AssetGroups.Where(x => x.Name.Equals(assetGroup)).Select(x => x.ID).First();

            var asset = db.Assets.Where(x => x.DepartmentLocation.DepartmentID == departmentID && x.AssetGroupID == assetGroupID).ToList();

            return Content(
                $"{departmentID.ToString().PadLeft(2, '0')}/{assetGroupID.ToString().PadLeft(2, '0')}/{(asset.Count + 1).ToString().PadLeft(4, '0')}");
        }

        public ActionResult GetEmployeeNames()
        {
            return Json(db.Employees, JsonRequestBehavior.AllowGet);
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

        public ActionResult AddAsset(string assetName, string department, string location, string employee, string assetGroup, string description, string warranty, string assetSN)
        {
            var departmentLocationId = (from x in db.DepartmentLocations
                                        where x.Department.Name.Equals(department) && x.Location.Name.Equals(location)
                                        select x).First().ID;

            var employeeId = (from x in db.Employees
                              where (x.FirstName + " " + x.LastName).Equals(employee)
                              select x).First().ID;

            var assetGroupId = db.AssetGroups.Where(x => x.Name.Equals(assetGroup)).First().ID;
            DateTime? warrantyDT = null;
            if (!warranty.Equals(string.Empty))
            {
                warrantyDT = DateTime.Parse(warranty);
            }

            var insertAsset = new Asset
            {
                AssetName = assetName,
                DepartmentLocationID = departmentLocationId,
                EmployeeID = employeeId,
                AssetGroupID = assetGroupId,
                Description = description,
                WarrantyDate = warrantyDT,
                AssetSN = assetSN
            };
            db.Assets.Add(insertAsset);
            db.SaveChanges();
            return Content("Success");
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