using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class AssetsController : Controller
    {
        private Session3FinalEntities db = new Session3FinalEntities();

        public AssetsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        public ActionResult MarkTask(int taskId, bool isDone)
        {
            var task = db.PMTasks.Where(x => x.ID == taskId).First();
            task.TaskDone = isDone;
            db.SaveChanges();
            return Json(task, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTasks()
        {
            var task = from x in db.PMTasks
                       orderby x.PMScheduleTypeID, !x.TaskDone
                       select new
                       {
                           x.ScheduleKilometer,
                           x.ScheduleDate,
                           x.Asset.AssetName,
                           x.Asset.AssetSN,
                           TaskName = x.Task.Name,
                           ScheduleTypeName = x.PMScheduleType.Name,
                           x.TaskDone,
                           x.TaskID,
                           x.ID
                       };
            return Json(task, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetScheduleModels()
        {
            return Json(db.PMScheduleModels.Select(x => x.Name), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MakeTask(int taskID, int assetID, int scheduleType, DateTime? startDate)
        {
            var insertTask = new PMTask
            {
                AssetID = assetID,
                TaskID = taskID,
                PMScheduleTypeID = scheduleType,
                TaskDone = false
            };

            if (startDate != null)
            {
                insertTask.ScheduleDate = startDate;
            }

            db.PMTasks.Add(insertTask);
            db.SaveChanges();

            return Json(insertTask, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MakeRunTask(int taskID, int assetID, int scheduleType, int startRange, int endRange, int perKMIncrement)
        {
            var getCurrentRange = db.PMTasks.Where(x => x.AssetID == assetID).Select(x => x.ScheduleKilometer).ToList();

            var anyStart = from x in db.PMTasks
                           where x.AssetID == assetID
                           && startRange >= x.ScheduleKilometer && startRange <= x.ScheduleKilometer
                           select x;
            var anyEnd = from x in db.PMTasks
                         where x.AssetID == assetID
                         && endRange >= x.ScheduleKilometer && endRange <= x.ScheduleKilometer
                         select x;
            if (anyStart.Any() || anyEnd.Any())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var count = 0;
            for (int i = startRange; i <= endRange; i += perKMIncrement)
            {
                var newTask = new PMTask
                {
                    AssetID = assetID,
                    TaskID = taskID,
                    PMScheduleTypeID = scheduleType,
                    ScheduleKilometer = i,
                    TaskDone = false,
                };
                db.PMTasks.Add(newTask);
                count++;
            }

            db.SaveChanges();

            return Content(count.ToString());
        }

        public ActionResult GetTaskId(string taskName)
        {
            return Content(db.Tasks.Where(x => x.Name == taskName).First().ID.ToString());
        }

        public ActionResult GetAssetId(string assetName)
        {
            return Content(db.Assets.Where(x => x.AssetName == assetName).First().ID.ToString());
        }

        public ActionResult GetAssetNames()
        {
            return Json(db.Assets.Select(x => x.AssetName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTaskList()
        {
            return Json(db.Tasks.Select(x => x.Name), JsonRequestBehavior.AllowGet);
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