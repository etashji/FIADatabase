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
using static System.Net.WebRequestMethods;

namespace FIADatabase.Areas.FIANCFiles.Controllers
{
    public class ProloguesController : Controller
    {
        private FIANCFilesContext db = new FIANCFilesContext();

        // GET: FIANCFiles/Prologues
        public ActionResult Index()
        {
            return View(db.Prologues.OrderBy(s => s.orderNumber).ToList());
        }

        // GET: FIANCFiles/Prologues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prologue prologue = db.Prologues.Find(id);
            if (prologue == null)
            {
                return HttpNotFound();
            }
            return View(prologue);
        }

        // GET: FIANCFiles/Prologues/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FIANCFiles/Prologues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prologueId,orderNumber,Title,areaMap,districtMap,bureauMap,localMap,Briefing,Video,AAR")] Prologue prologue, 
            HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            if (file1 != null) 
            {
                prologue.areaMap = ImageToByteArray(file1);
            }
            if (file2 != null)
            {
                prologue.districtMap = ImageToByteArray(file2);
            }
            if (file3 != null)
            {
                prologue.bureauMap = ImageToByteArray(file3);
            }
            if (file4 != null)
            {
                prologue.localMap = ImageToByteArray(file4);
            }
            if (ModelState.IsValid)
            {
                db.Prologues.Add(prologue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prologue);
        }

        // GET: FIANCFiles/Prologues/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prologue prologue = db.Prologues.Find(id);
            if (prologue == null)
            {
                return HttpNotFound();
            }
            return View(prologue);
        }

        // POST: FIANCFiles/Prologues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prologueId,orderNumber,Title,areaMap,districtMap,bureauMap,localMap,Briefing,Video,AAR")] Prologue prologue, 
            HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            
            if (ModelState.IsValid)
            {
                if (file1 != null)
                {
                    prologue.areaMap = ImageToByteArray(file1);
                }
                if (file2 != null)
                {
                    prologue.districtMap = ImageToByteArray(file2);
                }
                if (file3 != null)
                {
                    prologue.bureauMap = ImageToByteArray(file3);
                }
                if (file4 != null)
                {
                    prologue.localMap = ImageToByteArray(file4);
                }
                db.Entry(prologue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prologue);
        }

        // GET: FIANCFiles/Prologues/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prologue prologue = db.Prologues.Find(id);
            if (prologue == null)
            {
                return HttpNotFound();
            }
            return View(prologue);
        }

        // POST: FIANCFiles/Prologues/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prologue prologue = db.Prologues.Find(id);
            db.Prologues.Remove(prologue);
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
