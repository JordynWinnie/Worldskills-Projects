using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace API_QR_TP_Session1_5_3_2020.Controllers
{
    public class UsersController : Controller
    {
        private Session1Entities db = new Session1Entities();

        public UsersController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }
        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.User_Type);
            return View(users.ToList());
        }

        [HttpPost]
        public ActionResult GetResources(string id)
        {
            var baseQuery = (from x in db.Resources
                             select x);

            if (id != null)
            {
                var resId = int.Parse(id);
                baseQuery = baseQuery.Where(x => x.resId == resId);
            }


            var resource = (from x in baseQuery
                            group x by x.resName into y
                            select new
                            {
                                ResourceId = y.Select(x => x.resId).ToList(),
                                ResourceName = y.Key,
                                Type = y.Select(x => x.Resource_Type.resTypeName).ToList(),
                                NumberOfSkills = y.SelectMany(x => x.Resource_Allocation).Select(x=>x.Skill.skillName).ToList(),
                                AllocatedSkills = y.SelectMany(x => x.Resource_Allocation).Select(x=>x.Skill),
                                Quantity = y.Sum(x => x.remainingQuantity),

                            }).ToList();

            var resource1 = from x in resource
                            select new
                            {
                                ResourceId = x.ResourceId[0],
                                x.ResourceName,
                                x.Quantity,
                                NumberOfSkills = x.NumberOfSkills.Count,
                                ResourceType = x.Type[0],
                                x.AllocatedSkills
                            };

            return Json(resource1);
        }


        [HttpPost]
        public ActionResult DeleteResource(int resourceTypeId)
        {
            var resourceToDelete = db.Resources.Where(x=>x.resId == resourceTypeId).FirstOrDefault();
            var allocationsToDelete = db.Resource_Allocation.Where(x => x.resIdFK == resourceTypeId);

            db.Resources.Remove(resourceToDelete);
            foreach (var alloc in allocationsToDelete)
            {
                db.Resource_Allocation.Remove(alloc);
            }

            db.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult GetSkillList()
        {
            return Json(db.Skills);
        }

        [HttpPost]
        public ActionResult GetResourceTypeList()
        {
            return Json(db.Resource_Type);
        }

        [HttpPost]
        public ActionResult GetUserTypes()
        {
            return Json(db.User_Type);
        }


        [HttpPost]
        public ActionResult UpdateResource(CustomAllocation allocation)
        {
            var currentResource = db.Resources.Where(x=>x.resId == allocation.ResourceTypeId).FirstOrDefault();
            var currentAllocations = db.Resource_Allocation.Where(x => x.resIdFK == allocation.ResourceTypeId);

            currentResource.remainingQuantity = allocation.Quantity;

            foreach (var alloc in currentAllocations)
            {
                db.Resource_Allocation.Remove(alloc);
            }


            db.SaveChanges();
            if (allocation.Skills != null)
            {
                foreach (var skill in allocation.Skills)
                {
                    var newAllocation = new Resource_Allocation
                    {
                        resIdFK = allocation.ResourceTypeId,
                        skillIdFK = skill.skillId
                    };
                    db.Resource_Allocation.Add(newAllocation);
                }
            }

            db.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.Users.Where(x => x.userId.Equals(username) && x.userPw.Equals(password)).FirstOrDefault();

            if (user != null)
            {
                return Json(user);
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (!db.Users.Where(x => x.userId.Equals(user.userId)).Any())
            {
                db.Users.Add(user);
                db.SaveChanges();

                return Json(user);
            }

            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
        }

        [HttpPost]
        public ActionResult CreateResource(Resource resource)
        {
            if (!db.Resources.Where(x => x.resName.Equals(resource.resName)).Any())
            {
                db.Resources.Add(resource);
                db.SaveChanges();

                return Json(resource);
            }

            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
        }

        [HttpPost]

        public ActionResult CreateAllocations(CustomAllocation allocation)
        {
            if (!db.Resources.Where(x => x.resName.Equals(allocation.ResourceName)).Any())
            {
                var newResourceId = db.Resources.OrderByDescending(x => x.resId).Select(x => x.resId).First() + 1;
                var insertResource = new Resource
                {
                    resTypeIdFK = allocation.ResourceTypeId,
                    remainingQuantity = allocation.Quantity,
                    resName = allocation.ResourceName
                };

                db.Resources.Add(insertResource);
                db.SaveChanges();
                if (allocation.Skills != null)
                {
                    foreach (var skill in allocation.Skills)
                    {
                        var newAllocation = new Resource_Allocation
                        {
                            resIdFK = newResourceId,
                            skillIdFK = skill.skillId
                        };
                        db.Resource_Allocation.Add(newAllocation);
                    }
                }

                db.SaveChanges();

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.userTypeIdFK = new SelectList(db.User_Type, "userTypeId", "userTypeName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,userName,userPw,userTypeIdFK")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userTypeIdFK = new SelectList(db.User_Type, "userTypeId", "userTypeName", user.userTypeIdFK);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.userTypeIdFK = new SelectList(db.User_Type, "userTypeId", "userTypeName", user.userTypeIdFK);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,userName,userPw,userTypeIdFK")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userTypeIdFK = new SelectList(db.User_Type, "userTypeId", "userTypeName", user.userTypeIdFK);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
