using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApi;

namespace WebApi.Controllers
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
            var departments = db.DepartmentLocations.Where(x => x.EndDate == null);
            return Json(departments.Select(x => x.Department.Name).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssetGroups()
        {
            return Json(db.AssetGroups.Select(x => x.Name), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCount()
        {
            return Content(db.Assets.Count().ToString());
        }

        public ActionResult GetAccountableParty()
        {
            var accountableParty = from x in db.Employees
                                   select new
                                   {
                                       Name = x.FirstName + " " + x.LastName
                                   };

            var list = new List<string>();
            list.AddRange(accountableParty.Select(x => x.Name));

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocation(string departmentName)
        {
            var location = db.DepartmentLocations.Where(x => x.EndDate == null && x.Department.Name == departmentName).Select(x => x.Location.Name).Distinct();
            return Json(location, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssetList(string departmentName, string assetGroup, string searchPattern, DateTime? startDate, DateTime? endDate)
        {
            var assets = from x in db.Assets
                         where x.DepartmentLocation.Department.Name == departmentName && x.AssetGroup.Name == assetGroup
                         select x;

            if (!string.IsNullOrEmpty(searchPattern))
            {
                assets = assets.Where(x => x.AssetName.ToLower().Contains(searchPattern.ToLower()));
            }

            if (startDate != null)
            {
                assets = assets.Where(x => x.WarrantyDate >= startDate);
            }

            if (endDate != null)
            {
                assets = assets.Where(x => x.WarrantyDate <= endDate);
            }

            var final = from x in assets
                        select new
                        {
                            AssetGroupName = x.AssetGroup.Name,
                            DepartmentName = x.DepartmentLocation.Department.Name,
                            WarrantyDate = x.WarrantyDate,
                            AssetName = x.AssetName,
                            AssetSN = x.AssetSN,
                            AssetDescription = x.Description,
                            ID = x.ID,
                            x.AssetPhotos
                        };
            return Json(final, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSN(string departmentName, string assetGroup)
        {
            if (string.IsNullOrEmpty(departmentName) || string.IsNullOrEmpty(assetGroup))
            {
                return Content("");
            }
            var departmentId = db.Departments.Where(x => x.Name == departmentName).First().ID.ToString();
            var assetGroupId = db.AssetGroups.Where(x => x.Name == assetGroup).First().ID.ToString();

            var assetnn = (from x in db.Assets
                           where x.AssetGroup.Name == assetGroup && x.DepartmentLocation.Department.Name == departmentName
                           select x).Count() + 1;
            return Content($"{departmentId.PadLeft(2, '0')}/{assetGroupId.PadLeft(2, '0')}/{assetnn.ToString().PadLeft(4, '0')}");
        }

        public ActionResult UploadAsset(string assetName, string assetGroup, string locationName, string departmentName,
            string employeeName, string description, string assetSN, DateTime? expiredWarranty)
        {
            var assetGroupId = db.AssetGroups.Where(x => x.Name == assetGroup).First().ID;
            var departmentLocationId = db.DepartmentLocations.Where(x => x.Department.Name == departmentName && x.Location.Name == locationName && x.EndDate == null).First().ID;
            var employeeId = db.Employees.Where(x => employeeName.Contains(x.FirstName) && employeeName.Contains(x.LastName)).First().ID;

            if (db.Assets.Where(x => x.AssetName == assetName).Any())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var asset = new Asset
            {
                AssetName = assetName,
                EmployeeID = employeeId,
                AssetSN = assetSN,
                WarrantyDate = expiredWarranty,
                DepartmentLocationID = departmentLocationId,
                AssetGroupID = assetGroupId,
                Description = description,
            };

            db.Assets.Add(asset);
            db.SaveChanges();

            return Json(asset, JsonRequestBehavior.AllowGet);
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