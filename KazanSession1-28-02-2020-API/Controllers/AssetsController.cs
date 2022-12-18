using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace KazanSession1_28_02_2020_API.Controllers
{
    public class AssetsController : Controller
    {
        public Session1Entities db = new Session1Entities();

        

        public AssetsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }
        [HttpPost]
        public ActionResult GetSample()
        {
            var asset = from x in db.Assets
                        select x;

            return Json(asset);
        }

        public ActionResult GetAllEmployees()
        {
            var employees = from x in db.Employees
                            select new
                            {
                                EmployeeID = x.ID,
                                EmployeeFirstName = x.FirstName,
                                EmployeeLastName = x.LastName
                            };

            return Json(employees);
        }

        public ActionResult GetAllDepartmentLocations()
        {
            var departmentLocation = from x in db.DepartmentLocations
                                     where x.EndDate == null
                                     select new
                                     {
                                         DepartmentName = x.Department.Name,
                                         LocationName = x.Location.Name,
                                         DepartmentLocationID = x.ID
                                     };

            return Json(departmentLocation);
        }

        [HttpPost]
        public ActionResult GetAllTransferHistory(long id)
        {
            var transHistory = from x in db.AssetTransferLogs
                               where x.AssetID == id
                               orderby x.TransferDate descending
                               select x;

            return Json(transHistory);
        }

        [HttpPost]
        public ActionResult GetAssetDetails()
        {
            var assets = from x in db.Assets
                         select new
                         {
                             x.AssetName,
                             DepartmentName = x.DepartmentLocation.Department.Name,
                             AssetGroupName = x.AssetGroup.Name,
                             x.WarrantyDate,
                             AssetGroupID = x.AssetGroup.ID,
                             DepartmentID = x.DepartmentLocation.Department.ID,
                             AssetSN = x.AssetSN,
                             UUID = x.ID,
                             Description = x.Description,
                             LocationName = x.DepartmentLocation.Location.Name,
                             EmployeeID = x.EmployeeID,
                             EmployeeFirstName = x.Employee.FirstName,
                             EmployeeLastName = x.Employee.LastName,
                             AssetPhotos = x.AssetPhotos.ToList(),
                             DepartmentLocationID = x.DepartmentLocationID
                         };
            return new JsonResult()
            {
                Data = assets,
                MaxJsonLength = Int32.MaxValue
            };
        }

        [HttpPost]
        public ActionResult GetDepartment()
        {
            var departments = from x in db.Departments
                              
                              select new
                              {
                                  DepartmentID = x.ID,
                                  DepartmentName = x.Name
                              };
            return Json(departments);
        }

        [HttpPost]
        public ActionResult GetAssetGroup()
        {
            var assetGroups = from x in db.AssetGroups
                              select new
                              {
                                  AssetGroupID = x.ID,
                                  AssetGroupName = x.Name
                              };
            return Json(assetGroups);
        }

        // GET: Assets
        public ActionResult Index()
        {
            var assets = db.Assets;
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

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,AssetSN,AssetName,DepartmentLocationID,EmployeeID,AssetGroupID,Description,WarrantyDate")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                if (asset.Description == null)
                {
                    asset.Description = "";
                }

                db.Assets.Add(asset);
                db.SaveChanges();
                return Json(asset);
            }

            ViewBag.AssetGroupID = new SelectList(db.AssetGroups, "ID", "Name", asset.AssetGroupID);
            ViewBag.DepartmentLocationID = new SelectList(db.DepartmentLocations, "ID", "ID", asset.DepartmentLocationID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", asset.EmployeeID);
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult RemoveOldPhotos(long id)
        {
            var oldphotos = from x in db.AssetPhotos
                            where x.AssetID == id
                            select x;

            foreach (var item in oldphotos)
            {
                db.AssetPhotos.Remove(item);
               
            }
            db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult CreateAssetPhotos(List<AssetPhoto> assetPhoto)
        {
            if (assetPhoto != null)
            {
                try
                {
                    foreach (var item in assetPhoto)
                    {
                        db.AssetPhotos.Add(item);
                    }
                    db.SaveChanges();
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {

                    return Json(ex);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            
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
        public ActionResult EditAsset([Bind(Include = "ID,AssetSN,AssetName,DepartmentLocationID,EmployeeID,AssetGroupID,Description,WarrantyDate")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(asset.Description))
                {
                    asset.Description = "";
                }
                db.Entry(asset).State = EntityState.Modified;
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
        public ActionResult DeleteConfirmed(long id)
        {
            Asset asset = db.Assets.Find(id);
            db.Assets.Remove(asset);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddAssetTransferLog(AssetTransferLog assetTransferLog)
        {
            var currentAsset = (from x in db.Assets
                               where x.ID == assetTransferLog.AssetID
                               select x).First();

            currentAsset.DepartmentLocationID = assetTransferLog.ToDepartmentLocationID;
            currentAsset.AssetSN = assetTransferLog.ToAssetSN;

            try
            {
                db.AssetTransferLogs.Add(assetTransferLog);
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.UnsupportedMediaType);
            }
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
