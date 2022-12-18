using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebAPI.Controllers
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
            var departments = db.DepartmentLocations.Where(x => x.EndDate == null).Select(x => x.Department.Name).Distinct();
            return Json(departments, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssets(string searchTerm, string department, string assetGroup, DateTime? startDate,
            DateTime? endDate)
        {
            var baseQuery = from x in db.Assets
                            where x.AssetGroup.Name == assetGroup && x.DepartmentLocation.Department.Name == department
                            select new
                            {
                                x.AssetName,
                                DepartmentName = x.DepartmentLocation.Department.Name,
                                x.AssetSN,
                                x.ID,
                                x.AssetPhotos,
                                x.WarrantyDate
                            };

            if (!string.IsNullOrEmpty(searchTerm))
            {
                baseQuery = baseQuery.Where(x => x.AssetName.ToLower().Contains(searchTerm.ToLower()));
            }

            if (startDate != null)
            {
                baseQuery = baseQuery.Where(x => x.WarrantyDate >= startDate);
            }

            if (endDate != null)
            {
                baseQuery = baseQuery.Where(x => x.WarrantyDate <= endDate);
            }

            return Json(baseQuery.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssetById(int id)
        {
            var asset = from x in db.Assets
                        where x.ID == id
                        select new
                        {
                            x.ID,
                            EmployeeName = x.Employee.FirstName + " " + x.Employee.LastName,
                            LocationName = x.DepartmentLocation.Location.Name,
                            DepartmentName = x.DepartmentLocation.Department.Name,
                            AssetSN = x.AssetSN,
                            x.AssetPhotos,
                            AssetGroup = x.AssetGroup.Name,
                            x.WarrantyDate,
                            x.AssetName,
                            x.Description
                        };
            JsonResult result = Json(asset.First(), JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;
            return result;
        }

        [HttpPost]
        public ActionResult EditAsset(Asset asset)
        {
            var checkForDuplicate = db.Assets.Where(x => x.ID != asset.ID && x.AssetName == asset.AssetName).Any();
            if (checkForDuplicate)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var currentAsset = db.Assets.Where(x => x.ID == asset.ID).First();

            currentAsset.AssetName = asset.AssetName;
            currentAsset.Description = asset.Description;
            currentAsset.EmployeeID = asset.EmployeeID;

            if (asset.WarrantyDate != null)
            {
                currentAsset.WarrantyDate = asset.WarrantyDate;
            }
            else
            {
                currentAsset.WarrantyDate = null;
            }

            currentAsset.DepartmentLocationID = asset.DepartmentLocationID;
            currentAsset.AssetSN = asset.AssetSN;

            var photos = db.AssetPhotos.Where(x => x.AssetID == asset.ID);

            if (photos.Any())
            {
                foreach (var photo in photos)
                {
                    db.AssetPhotos.Remove(photo);
                }
            }

            if (asset.AssetPhotos.Count != 0)
            {
                foreach (var photo in asset.AssetPhotos)
                {
                    photo.AssetID = asset.ID;
                    db.AssetPhotos.Add(photo);
                }
            }

            db.SaveChanges();
            return Json(currentAsset);
        }

        public ActionResult GetTransferHistory(int id)
        {
            var transferLogs = (from x in db.AssetTransferLogs
                                where x.AssetID == id
                                orderby x.TransferDate
                                select new
                                {
                                    OldDep = x.DepartmentLocation.Department.Name,
                                    NewDep = x.DepartmentLocation1.Department.Name,
                                    x.FromAssetSN,
                                    x.ToAssetSN,
                                    x.TransferDate
                                });

            return Json(transferLogs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocation(string department)
        {
            var locations = db.DepartmentLocations.Where(x => x.Department.Name == department && x.EndDate == null).Select(x => x.Location.Name).Distinct();
            return Json(locations, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSN(string department, string assetGroup, string location, int? id)
        {
            if (department == null || assetGroup == null || string.IsNullOrEmpty(location))
            {
                return Content("");
            }
            var departmentId = db.Departments.Where(x => x.Name == department).FirstOrDefault().ID;
            var assetGroupId = db.AssetGroups.Where(x => x.Name == assetGroup).FirstOrDefault().ID;
            var locationId = db.Locations.Where(x => x.Name == location).FirstOrDefault().ID;

            var departmentLocationId = db.DepartmentLocations.Where(x => x.LocationID == locationId && x.DepartmentID == departmentId);
            if (!departmentLocationId.Any())
            {
                return Content("");
            }

            var endingDigits = db.Assets.Where(x => x.DepartmentLocation.Department.ID == departmentId && x.AssetGroupID == assetGroupId).Count() + 1;
            var SN = $"{departmentId.ToString().PadLeft(2, '0')}/{assetGroupId.ToString().PadLeft(2, '0')}/{endingDigits.ToString().PadLeft(4, '0')}";

            if (id != null)
            {
                var depid = departmentLocationId.First().ID;
                var history = db.AssetTransferLogs.Where(x => x.AssetID == id && x.FromDepartmentLocationID == depid);

                if (history.Any())
                {
                    SN = history.First().FromAssetSN;
                }
            }

            return Content(SN);
        }

        public ActionResult GetAccountableParty()
        {
            var parties = from x in db.Employees
                          select new
                          {
                              Name = x.FirstName + " " + x.LastName
                          };

            List<string> names = new List<string>();
            foreach (var name in parties)
            {
                names.Add(name.Name);
            }

            return Json(names, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssetCount()
        {
            return Content(db.Assets.Count().ToString());
        }

        public ActionResult GetAssetGroup()
        {
            var assetGroups = db.AssetGroups.Select(x => x.Name);
            return Json(assetGroups, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssetGroupID(string assetGroup)
        {
            if (assetGroup == null)
            {
                return Content("");
            }
            return Content(db.AssetGroups.Where(x => x.Name == assetGroup).First().ID.ToString());
        }

        public ActionResult GetDepartmentLocation(string department, string location)
        {
            if (department == null || location == null)
            {
                return Content("");
            }

            return Content(db.DepartmentLocations.Where(x => x.Department.Name == department && x.Location.Name == location && x.EndDate == null).First().ID.ToString());
        }

        public ActionResult GetEmployeeID(string employeeName)
        {
            if (employeeName == null)
            {
                return Content("");
            }

            var employee = from x in db.Employees
                           where employeeName.Contains(x.FirstName) && employeeName.Contains(x.LastName)
                           select x.ID;

            return Content(employee.First().ToString());
        }

        public ActionResult TransferAsset(string currentAssetSN, string changedAssetSN, long fromDepartmentLocation, long toDepartmentLocation, int id)
        {
            var insertTransfer = new AssetTransferLog
            {
                AssetID = id,
                FromAssetSN = currentAssetSN,
                ToAssetSN = changedAssetSN,
                FromDepartmentLocationID = fromDepartmentLocation,
                ToDepartmentLocationID = toDepartmentLocation,
                TransferDate = DateTime.Now
            };
            var assetToChange = db.Assets.Where(x => x.ID == id).First();

            assetToChange.AssetSN = changedAssetSN;
            assetToChange.DepartmentLocationID = toDepartmentLocation;
            db.AssetTransferLogs.Add(insertTransfer);
            db.SaveChanges();

            return Json(assetToChange, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateAsset(Asset asset)
        {
            if (db.AssetPhotos.Where(x => x.AssetID == asset.ID).Any())
            {
                //edit
            }

            var imgList = asset.AssetPhotos;
            asset.AssetPhotos = null;
            db.Assets.Add(asset);

            db.SaveChanges();

            Console.WriteLine("AssetID: " + asset.ID);
            foreach (var img in imgList)
            {
                img.AssetID = asset.ID;
                db.AssetPhotos.Add(img);
            }
            db.SaveChanges();

            return Json(asset);
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