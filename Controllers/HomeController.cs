using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employee_details.Models;

namespace Employee_details.Controllers
{
    public class HomeController : Controller
    {
        private tblUserInfoEntities1 db = new tblUserInfoEntities1();

        // GET: Home
        public async Task<ActionResult> Index()
        {
            return View(await db.tbluserinfoes.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbluserinfo tbluserinfo = await db.tbluserinfoes.FindAsync(id);
            if (tbluserinfo == null)
            {
                return HttpNotFound();
            }
            return View(tbluserinfo);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "empId,empName,empAddress,empDept,empMobile")] tbluserinfo tbluserinfo)
        {
            if (ModelState.IsValid)
            {
                db.tbluserinfoes.Add(tbluserinfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbluserinfo);
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbluserinfo tbluserinfo = await db.tbluserinfoes.FindAsync(id);
            if (tbluserinfo == null)
            {
                return HttpNotFound();
            }
            return View(tbluserinfo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "empId,empName,empAddress,empDept,empMobile")] tbluserinfo tbluserinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbluserinfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbluserinfo);
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbluserinfo tbluserinfo = await db.tbluserinfoes.FindAsync(id);
            if (tbluserinfo == null)
            {
                return HttpNotFound();
            }
            return View(tbluserinfo);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            tbluserinfo tbluserinfo = await db.tbluserinfoes.FindAsync(id);
            db.tbluserinfoes.Remove(tbluserinfo);
            await db.SaveChangesAsync();
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
