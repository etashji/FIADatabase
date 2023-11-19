using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FIADatabase.Areas.FIANCFiles.Modules;
using FIADatabase.Contexts;
using Syncfusion.EJ2.RichTextEditor;

namespace FIADatabase.Areas.FIANCFiles.Controllers
{
    public class HVIsController : Controller
    {
        private FIANCFilesContext db = new FIANCFilesContext();

        // GET: FIANCFiles/HVIs
        [Authorize]
        public ActionResult Index()
        {
            return View(db.HVIs.OrderBy(s => s.lastName).ToList());
        }

        // GET: FIANCFiles/HVIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HVI hVI = db.HVIs.Find(id);
            if (hVI == null)
            {
                return HttpNotFound();
            }
            return View(hVI);
        }

        // GET: FIANCFiles/HVIs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FIANCFiles/HVIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HVIId,Portrait,lastName,firstName,Alias,DateofBirth,Bio")] HVI hVI, HttpPostedFileBase file1)
        {
            if (file1 != null)
            {
                hVI.Portrait = ImageToByteArray(file1);
            }
            if (ModelState.IsValid)
            {
                db.HVIs.Add(hVI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hVI);
        }

        // GET: FIANCFiles/HVIs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HVI hVI = db.HVIs.Find(id);
            if (hVI == null)
            {
                return HttpNotFound();
            }
            return View(hVI);
        }

        // POST: FIANCFiles/HVIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HVIId,Portrait,lastName,firstName,Alias,DateofBirth,Bio")] HVI hVI, HttpPostedFileBase file1)
        {
            if (file1 != null)
            {
                hVI.Portrait = ImageToByteArray(file1);
            }
            if (ModelState.IsValid)
            {
                db.Entry(hVI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hVI);
        }

        // GET: FIANCFiles/HVIs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HVI hVI = db.HVIs.Find(id);
            if (hVI == null)
            {
                return HttpNotFound();
            }
            return View(hVI);
        }

        // POST: FIANCFiles/HVIs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HVI hVI = db.HVIs.Find(id);
            db.HVIs.Remove(hVI);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        public byte[] ImageToByteArray(HttpPostedFileBase imageIn)
        {
            MemoryStream target = new MemoryStream();
            imageIn.InputStream.CopyTo(target);
            byte[] bytes = target.ToArray();
            return bytes;
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
