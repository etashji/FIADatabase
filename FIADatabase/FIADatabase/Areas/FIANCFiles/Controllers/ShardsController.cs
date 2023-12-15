using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FIADatabase.Areas.FIANCFiles.Modules;
using FIADatabase.Contexts;

namespace FIADatabase.Areas.FIANCFiles.Controllers
{
    public class ShardsController : Controller
    {
        private FIANCFilesContext db = new FIANCFilesContext();

        // GET: FIANCFiles/Shards
        public ActionResult Index()
        {
            return View(db.Shards.OrderBy(x => x.Title).ToList());
        }

        // GET: FIANCFiles/Shards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shard shard = db.Shards.Find(id);
            if (shard == null)
            {
                return HttpNotFound();
            }
            return View(shard);
        }

        // GET: FIANCFiles/Shards/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FIANCFiles/Shards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shardId,Title,Content")] Shard shard)
        {
            if (ModelState.IsValid)
            {
                db.Shards.Add(shard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shard);
        }

        // GET: FIANCFiles/Shards/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shard shard = db.Shards.Find(id);
            if (shard == null)
            {
                return HttpNotFound();
            }
            return View(shard);
        }

        // POST: FIANCFiles/Shards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shardId,Title,Content")] Shard shard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shard);
        }

        // GET: FIANCFiles/Shards/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shard shard = db.Shards.Find(id);
            if (shard == null)
            {
                return HttpNotFound();
            }
            return View(shard);
        }

        // POST: FIANCFiles/Shards/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shard shard = db.Shards.Find(id);
            db.Shards.Remove(shard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
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
