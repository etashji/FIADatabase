using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using FIADatabase.Areas.FIAUsers.Models;
using FIADatabase.Contexts;

namespace FIADatabase.Areas.FIAUsers.Controllers
{
    public class UsersController : Controller
    {
        private FIAUsersContext db = new FIAUsersContext();

        // GET: FIAUsers/Users
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: FIAUsers/Users/Details/5
        [Authorize]
        public ActionResult Details(int? id)
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

        // GET: FIAUsers/Users/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FIAUsers/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username,Password,ConfirmPassword,Salt,HashedPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                user.Salt = Crypto.GenerateSalt();
                string password = user.Password + user.Salt;
                user.HashedPassword = Crypto.HashPassword(password);
                user.Password = "";
                user.ConfirmPassword = "";
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: FIAUsers/Users/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
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

        // POST: FIAUsers/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Username,Password,ConfirmPassword,Salt,HashedPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: FIAUsers/Users/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
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

        // POST: FIAUsers/Users/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {
            bool userExists = db.Users.Any(x => x.Username == user.Username);
            if (userExists) 
            {
                User u = db.Users.FirstOrDefault(x => x.Username == user.Username);
                string password = user.Password + u.Salt;
                bool userExist = Crypto.VerifyHashedPassword(u.HashedPassword, password);

                if (userExist)
                {
                    FormsAuthentication.SetAuthCookie(u.Username, false);
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return Redirect("/Home/Index");
                }

                ModelState.AddModelError("", "Username or Password is incorrect.");

                return View();
            }

            ModelState.AddModelError("", "Username or Password is incorrect.");

            return View();

        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
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
