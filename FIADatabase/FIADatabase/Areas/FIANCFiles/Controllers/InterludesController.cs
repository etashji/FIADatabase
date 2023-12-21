using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FIADatabase.Areas.FIANCFiles.Modules;
using FIADatabase.Contexts;
using FIADatabase.Migrations;

namespace FIADatabase.Areas.FIANCFiles.Controllers
{
    public class InterludesController : Controller
    {
        private FIANCFilesContext db = new FIANCFilesContext();

        // GET: FIANCFiles/Interludes
        public ActionResult Index()
        {
            return View(db.Interludes.OrderBy(s => s.orderNumber).ToList());
        }

        // GET: FIANCFiles/Interludes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interlude interlude = db.Interludes.Find(id);
            if (interlude == null)
            {
                return HttpNotFound();
            }
            return View(interlude);
        }

        // GET: FIANCFiles/Interludes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FIANCFiles/Interludes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "interludeId,orderNumber,Title,areaMap,districtMap,bureauMap,localMap,Briefing,Video,AAR")] Interlude interlude,
            HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            if (file1 != null)
            {
                interlude.areaMap = ImageToByteArray(file1);
            }
            if (file2 != null)
            {
                interlude.districtMap = ImageToByteArray(file2);
            }
            if (file3 != null)
            {
                interlude.bureauMap = ImageToByteArray(file3);
            }
            if (file4 != null)
            {
                interlude.localMap = ImageToByteArray(file4);
            }
            if (ModelState.IsValid)
            {
                db.Interludes.Add(interlude);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interlude);
        }

        // GET: FIANCFiles/Interludes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interlude interlude = db.Interludes.Find(id);
            if (interlude == null)
            {
                return HttpNotFound();
            }
            return View(interlude);
        }

        // POST: FIANCFiles/Interludes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "interludeId,orderNumber,Title,areaMap,districtMap,bureauMap,localMap,Briefing,Video,AAR")] Interlude interlude,
            HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            if (file1 != null)
            {
                interlude.areaMap = ImageToByteArray(file1);
            }
            if (file2 != null)
            {
                interlude.districtMap = ImageToByteArray(file2);
            }
            if (file3 != null)
            {
                interlude.bureauMap = ImageToByteArray(file3);
            }
            if (file4 != null)
            {
                interlude.localMap = ImageToByteArray(file4);
            }
            if (ModelState.IsValid)
            {
                db.Entry(interlude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interlude);
        }

        // GET: FIANCFiles/Interludes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interlude interlude = db.Interludes.Find(id);
            if (interlude == null)
            {
                return HttpNotFound();
            }
            return View(interlude);
        }

        // POST: FIANCFiles/Interludes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interlude interlude = db.Interludes.Find(id);
            db.Interludes.Remove(interlude);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public byte[] ImageToByteArray(HttpPostedFileBase imageIn)
        {
            MemoryStream target = new MemoryStream();
            imageIn.InputStream.CopyTo(target);
            byte[] bytes = target.ToArray();
            return bytes;
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
