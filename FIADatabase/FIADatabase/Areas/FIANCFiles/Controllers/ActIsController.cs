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
using ActI = FIADatabase.Areas.FIANCFiles.Modules.ActI;

namespace FIADatabase.Areas.FIANCFiles.Controllers
{
    public class ActIsController : Controller
    {
        private FIANCFilesContext db = new FIANCFilesContext();

        // GET: FIANCFiles/ActIs
        public ActionResult Index()
        {
            return View(db.ActIs.OrderBy(s => s.orderNumber).ToList());
        }

        // GET: FIANCFiles/ActIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActI actI = db.ActIs.Find(id);
            if (actI == null)
            {
                return HttpNotFound();
            }
            return View(actI);
        }

        // GET: FIANCFiles/ActIs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FIANCFiles/ActIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActIId,orderNumber,Title,areaMap,districtMap,bureauMap,localMap,Briefing,Video,AAR")] ActI actI,
            HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            if (file1 != null)
            {
                actI.areaMap = ImageToByteArray(file1);
            }
            if (file2 != null)
            {
                actI.districtMap = ImageToByteArray(file2);
            }
            if (file3 != null)
            {
                actI.bureauMap = ImageToByteArray(file3);
            }
            if (file4 != null)
            {
                actI.localMap = ImageToByteArray(file4);
            }
            if (ModelState.IsValid)
            {
                db.ActIs.Add(actI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actI);
        }

        // GET: FIANCFiles/ActIs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActI actI = db.ActIs.Find(id);
            if (actI == null)
            {
                return HttpNotFound();
            }
            return View(actI);
        }

        // POST: FIANCFiles/ActIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActIId,orderNumber,Title,areaMap,districtMap,bureauMap,localMap,Briefing,Video,AAR")] ActI actI,
            HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            if (ModelState.IsValid)
            {
                if (file1 != null)
                {
                    actI.areaMap = ImageToByteArray(file1);
                }
                if (file2 != null)
                {
                    actI.districtMap = ImageToByteArray(file2);
                }
                if (file3 != null)
                {
                    actI.bureauMap = ImageToByteArray(file3);
                }
                if (file4 != null)
                {
                    actI.localMap = ImageToByteArray(file4);
                }
                db.Entry(actI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actI);
        }

        // GET: FIANCFiles/ActIs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActI actI = db.ActIs.Find(id);
            if (actI == null)
            {
                return HttpNotFound();
            }
            return View(actI);
        }

        // POST: FIANCFiles/ActIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            ActI actI = db.ActIs.Find(id);
            db.ActIs.Remove(actI);
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

        public ActionResult NCIndex()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
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
