using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using QR_TP_Session2_5_28_2020_API;

namespace QR_TP_Session2_5_28_2020_API.Controllers
{
    public class PackagesController : Controller
    {
        private Session2Entities db = new Session2Entities();

        public PackagesController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        [HttpPost]
        public ActionResult Login(string userID, string password)
        {
            var userToCheck = db.Users.Where(x => x.userId == userID && x.passwd == password);
            if (userToCheck.Any())
            {
                return Json(userToCheck.First());
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult CreateAccount(User user)
        {
            if (db.Users.Where(x => x.userId == user.userId).Any())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return Json(user);
        }

        // GET: Packages
        public ActionResult Index()
        {
            return View(db.Packages.ToList());
        }

        // GET: Packages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        [HttpPost]
        public ActionResult GetPackages(int accessType)
        {
            if (accessType == 1)
            {
                var package = from x in db.Packages
                              select new
                              {
                                  PackageID = x.packageId,
                                  Tier = x.packageTier,
                                  Name = x.packageName,
                                  Value = x.packageValue,
                                  Quantity = x.packageQuantity,
                                  isOnline = x.Benefits.Where(y => y.benefitName.Equals("Online")).Any(),
                                  isFlyer = x.Benefits.Where(y => y.benefitName.Equals("Flyer")).Any(),
                                  isBanner = x.Benefits.Where(y => y.benefitName.Equals("Banner")).Any()
                              };

                return Json(package);
            }
            else
            {
                var package = from x in db.Packages
                              where x.packageQuantity != 0
                              select new
                              {
                                  PackageID = x.packageId,
                                  Tier = x.packageTier,
                                  Name = x.packageName,
                                  Value = x.packageValue,
                                  Quantity = x.packageQuantity,
                                  isOnline = x.Benefits.Where(y => y.benefitName.Equals("Online")).Any(),
                                  isFlyer = x.Benefits.Where(y => y.benefitName.Equals("Flyer")).Any(),
                                  isBanner = x.Benefits.Where(y => y.benefitName.Equals("Banner")).Any()
                              };

                return Json(package);
            }
        }

        [HttpPost]
        public ActionResult AttemptBooking(int packageID, int bookingQuantity, string currentUserID)
        {
            var packageAmount = db.Packages.Where(x => x.packageId == packageID)
                .Select(x => x.packageQuantity).FirstOrDefault();

            if (bookingQuantity <= packageAmount)
            {
                var insertBooking = new Booking
                {
                    quantityBooked = bookingQuantity,
                    userIdFK = currentUserID,
                    packageIdFK = packageID,
                    status = "Pending"
                };

                var packageToModify = db.Packages.Where(x => x.packageId == packageID).First();
                packageToModify.packageQuantity -= bookingQuantity;
                db.Bookings.Add(insertBooking);
                db.SaveChanges();

                return Json(insertBooking);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult GetBookings()
        {
            var booking = from x in db.Bookings
                          select new
                          {
                              x.bookingId,
                              x.userIdFK,
                              x.packageIdFK,
                              x.quantityBooked,
                              x.status,
                              companyName = x.User.name,
                              packageName = x.Package.packageName,
                              packageTier = x.Package.packageTier,
                              packageValue = x.Package.packageValue
                          };

            return Json(booking);
        }

        [HttpPost]
        public ActionResult ChangeBookingStatus(int bookingID, bool approved)
        {
            var bookingToModify = db.Bookings.Where(x => x.bookingId == bookingID).FirstOrDefault();

            if (approved)
            {
                bookingToModify.status = "Approved";
            }
            else
            {
                bookingToModify.status = "Rejected";
                var packageReference = bookingToModify.packageIdFK;
                var packageToModify = db.Packages.Where(x => x.packageId == packageReference).First();

                packageToModify.packageQuantity += bookingToModify.quantityBooked;
            }

            db.SaveChanges();
            return Json("Process Done");
        }

        [HttpPost]
        public ActionResult DeleteBooking(int bookingID)
        {
            var bookingToDelete = db.Bookings.Where(x => x.bookingId == bookingID).First();
            var packageAffected = db.Packages.Where(x => x.packageId == bookingToDelete.packageIdFK).First();
            var ownerOfBooking = bookingToDelete.userIdFK;

            if (db.Bookings.Where(x => x.userIdFK != ownerOfBooking).Count() != 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            packageAffected.packageQuantity += bookingToDelete.quantityBooked;

            db.Bookings.Remove(bookingToDelete);
            db.SaveChanges();
            return Json(packageAffected);
        }

        [HttpPost]
        public ActionResult AddPackage(string tier, string packageName, int packageValue, int packageQuantity,
            bool isOnline, bool isFlyer, bool isBanner)
        {
            if (db.Packages.Where(x=>x.packageName.Equals(packageName)).Any())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var packageId = db.Packages.OrderByDescending(x => x.packageId).Select(x => x.packageId).First() + 1;
            var insertPackage = new Package
            {
                packageId = packageId,
                packageTier = tier,
                packageName = packageName,
                packageValue = packageValue,
                packageQuantity = packageQuantity
            };

            db.Packages.Add(insertPackage);

            if (isOnline)
            {
                var insertBenefit = new Benefit
                {
                    packageIdFK = packageId,
                    benefitName = "Online"
                };
                db.Benefits.Add(insertBenefit);
            }

            if (isFlyer)
            {
                var insertBenefit = new Benefit
                {
                    packageIdFK = packageId,
                    benefitName = "Flyer"
                };
                db.Benefits.Add(insertBenefit);
            }

            if (isBanner)
            {
                var insertBenefit = new Benefit
                {
                    packageIdFK = packageId,
                    benefitName = "Banner"
                };
                db.Benefits.Add(insertBenefit);
            }

            db.SaveChanges();
            return Json("Done");
        }

        [HttpPost]
        public ActionResult UpdateBooking(int bookingID, int quantityToUpdate)
        {
            var package = db.Bookings.Where(x => x.bookingId == bookingID)
                .Select(x => x.Package).First();

            var booking = db.Bookings.Where(x => x.bookingId == bookingID).First();

            var extraToBook = quantityToUpdate - booking.quantityBooked;
            if (extraToBook <= package.packageQuantity)
            {
                package.packageQuantity -= extraToBook;
                booking.quantityBooked += extraToBook;
                db.SaveChanges();
                return Json(extraToBook);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: Packages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "packageId,packageTier,packageName,packageValue,packageQuantity")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Packages.Add(package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(package);
        }

        // GET: Packages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "packageId,packageTier,packageName,packageValue,packageQuantity")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(package);
        }

        // GET: Packages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = db.Packages.Find(id);
            db.Packages.Remove(package);
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