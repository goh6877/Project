using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Background_Management.Models;

namespace Background_Management.Controllers
{
    public class MembersDatasController : Controller
    {
        private MembersEntities db = new MembersEntities();

        // GET: MembersDatas
        public ActionResult Index()
        {
            return View(db.MembersData.ToList());
        }

        // GET: MembersDatas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersData membersData = db.MembersData.Find(id);
            if (membersData == null)
            {
                return HttpNotFound();
            }
            return View(membersData);
        }

        // GET: MembersDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembersDatas/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserPassWord,UserName,Phone,Address")] MembersData membersData)
        {
            if (ModelState.IsValid)
            {
                db.MembersData.Add(membersData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membersData);
        }

        // GET: MembersDatas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersData membersData = db.MembersData.Find(id);
            if (membersData == null)
            {
                return HttpNotFound();
            }
            return View(membersData);
        }

        // POST: MembersDatas/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserPassWord,UserName,Phone,Address")] MembersData membersData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membersData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membersData);
        }

        // GET: MembersDatas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersData membersData = db.MembersData.Find(id);
            if (membersData == null)
            {
                return HttpNotFound();
            }
            return View(membersData);
        }

        // POST: MembersDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MembersData membersData = db.MembersData.Find(id);
            db.MembersData.Remove(membersData);
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
