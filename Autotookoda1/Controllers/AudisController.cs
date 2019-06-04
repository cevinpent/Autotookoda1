using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Autotookoda1.Models;

namespace Autotookoda1.Controllers
{
    public class AudisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Audis
        public ActionResult Index()
        {
            return View(db.Audis.ToList());
        }

        // GET: Audis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audi audi = db.Audis.Find(id);
            if (audi == null)
            {
                return HttpNotFound();
            }
            return View(audi);
        }

        // GET: Audis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Audis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tellija,auto,viga,parandatud,tasutud")] Audi audi)
        {
            if (ModelState.IsValid)
            {
                db.Audis.Add(audi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(audi);
        }

        // GET: Audis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audi audi = db.Audis.Find(id);
            if (audi == null)
            {
                return HttpNotFound();
            }
            return View(audi);
        }

        // POST: Audis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tellija,auto,viga,parandatud,tasutud")] Audi audi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(audi);
        }

        // GET: Audis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audi audi = db.Audis.Find(id);
            if (audi == null)
            {
                return HttpNotFound();
            }
            return View(audi);
        }

        // POST: Audis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Audi audi = db.Audis.Find(id);
            db.Audis.Remove(audi);
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

		// GET: Audis/Create
		public ActionResult telli()
		{
			return View();
		}

		// POST: Audis/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult telli([Bind(Include = "id,tellija,auto,viga,parandatud,tasutud")] Audi audi)
		{
			if (ModelState.IsValid)
			{
				db.Audis.Add(audi);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(audi);
		}

		// GET: Audis/Edit/5
		public ActionResult Maksmine(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Audi audi = db.Audis.Find(id);
			if (audi == null)
			{
				return HttpNotFound();
			}
			return View(audi);
		}

		// POST: Audis/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Maksmine([Bind(Include = "id,tellija,auto,viga,parandatud,tasutud")] Audi audi)
		{
			if (ModelState.IsValid)
			{
				db.Entry(audi).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(audi);
		}
		public ActionResult maks()
		{
			var model = db.Audis.
				Where(m => m.tasutud == -1).
				ToList();
			return View(model);

		}
		public ActionResult PassFail(int? id, string part, int result)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Audi audi = db.Audis.Find(id);
			if (audi== null)
			{
				return HttpNotFound();
			}
			if (ModelState.IsValid)
			{
				switch (part)
				{
					case "maks": { audi.tasutud = result; break; }
				

					default:
						{ return HttpNotFound(); }
						break;
				}
				db.Entry(audi).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");


		}

	}
}