using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class WellsController : Controller
    {
        private Session5Entities1 db = new Session5Entities1();

        public WellsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        public ActionResult GetWells()
        {
            var wells = db.Wells.Select(x => x.WellName);
            return Json(wells, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetWellInformation(string wellName)
        {
            if (string.IsNullOrWhiteSpace(wellName))
            {
                var wellInfo = from x in db.WellLayers
                               orderby x.StartPoint ascending
                               select new
                               {
                                   x.Well.GasOilDepth,
                                   x.Well.Capacity,
                                   RockName = x.RockType.Name,
                                   x.StartPoint,
                                   x.EndPoint,
                                   x.RockType.BackgroundColor,
                                   x.Well.WellName
                               };
                return Json(wellInfo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var wellInfo = from x in db.WellLayers
                               where x.Well.WellName == wellName
                               orderby x.StartPoint ascending
                               select new
                               {
                                   x.Well.GasOilDepth,
                                   x.Well.Capacity,
                                   RockName = x.RockType.Name,
                                   x.StartPoint,
                                   x.EndPoint,
                                   x.RockType.BackgroundColor,
                                   x.Well.WellName
                               };
                return Json(wellInfo, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetRockLayers()
        {
            var rockLayers = db.RockTypes.Select(x => x.Name);
            return Json(rockLayers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetWellEditInfo(string wellName)
        {
            return Content(db.Wells.Where(x => x.WellName == wellName).First().ID.ToString());
        }

        // GET: Wells
        public ActionResult Index()
        {
            var wells = db.Wells.Include(w => w.WellType);
            return View(wells.ToList());
        }

        [HttpPost]
        public ActionResult PostWellInfo(RockDepthServer rockDepthServer)
        {
            if (rockDepthServer.isEditMode)
            {
                var wellToChange = db.Wells.Where(x => x.WellName == rockDepthServer.OldWellName).First();
                var rocksInLayer = db.WellLayers.Where(x => x.Well.WellName == rockDepthServer.OldWellName);

                wellToChange.WellName = rockDepthServer.WellName;
                wellToChange.GasOilDepth = rockDepthServer.DepthOfGas;
                wellToChange.Capacity = rockDepthServer.WellCapacity;

                foreach (var rock in rocksInLayer)
                {
                    db.WellLayers.Remove(rock);
                }

                foreach (var rock in rockDepthServer.RockInfo)
                {
                    var rockId = db.RockTypes.Where(x => x.Name == rock.RockName).First().ID;
                    var wellLayer = new WellLayer
                    {
                        RockTypeID = rockId,
                        StartPoint = rock.fromDepth,
                        EndPoint = rock.toDepth,
                        WellID = wellToChange.ID,
                    };
                    db.WellLayers.Add(wellLayer);
                }
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                if (db.Wells.Where(x => x.WellName == rockDepthServer.WellName).Any())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var wellInfo = new Well
                {
                    WellTypeID = 1,
                    WellName = rockDepthServer.WellName,
                    GasOilDepth = rockDepthServer.DepthOfGas,
                    Capacity = rockDepthServer.WellCapacity,
                };

                db.Wells.Add(wellInfo);
                db.SaveChanges();

                foreach (var rock in rockDepthServer.RockInfo)
                {
                    var rockId = db.RockTypes.Where(x => x.Name == rock.RockName).First().ID;
                    var wellLayer = new WellLayer
                    {
                        RockTypeID = rockId,
                        StartPoint = rock.fromDepth,
                        EndPoint = rock.toDepth,
                        WellID = wellInfo.ID,
                    };
                    db.WellLayers.Add(wellLayer);
                }

                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
        }

        // GET: Wells/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Well well = db.Wells.Find(id);
            if (well == null)
            {
                return HttpNotFound();
            }
            return View(well);
        }

        // GET: Wells/Create
        public ActionResult Create()
        {
            ViewBag.WellTypeID = new SelectList(db.WellTypes, "ID", "Name");
            return View();
        }

        // POST: Wells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,WellTypeID,WellName,GasOilDepth,Capacity")] Well well)
        {
            if (ModelState.IsValid)
            {
                db.Wells.Add(well);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WellTypeID = new SelectList(db.WellTypes, "ID", "Name", well.WellTypeID);
            return View(well);
        }

        // GET: Wells/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Well well = db.Wells.Find(id);
            if (well == null)
            {
                return HttpNotFound();
            }
            ViewBag.WellTypeID = new SelectList(db.WellTypes, "ID", "Name", well.WellTypeID);
            return View(well);
        }

        // POST: Wells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WellTypeID,WellName,GasOilDepth,Capacity")] Well well)
        {
            if (ModelState.IsValid)
            {
                db.Entry(well).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WellTypeID = new SelectList(db.WellTypes, "ID", "Name", well.WellTypeID);
            return View(well);
        }

        // GET: Wells/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Well well = db.Wells.Find(id);
            if (well == null)
            {
                return HttpNotFound();
            }
            return View(well);
        }

        // POST: Wells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Well well = db.Wells.Find(id);
            db.Wells.Remove(well);
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