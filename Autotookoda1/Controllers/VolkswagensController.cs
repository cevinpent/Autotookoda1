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
    public class VolkswagensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Volkswagens
        public ActionResult Index()
        {
            return View(db.Volkswagens.ToList());
        }

        // GET: Volkswagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volkswagen volkswagen = db.Volkswagens.Find(id);
            if (volkswagen == null)
            {
                return HttpNotFound();
            }
            return View(volkswagen);
        }

        // GET: Volkswagens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volkswagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tellija,auto,viga,parandatud,tasutud")] Volkswagen volkswagen)
        {
            if (ModelState.IsValid)
            {
                db.Volkswagens.Add(volkswagen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volkswagen);
        }

        // GET: Volkswagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volkswagen volkswagen = db.Volkswagens.Find(id);
            if (volkswagen == null)
            {
                return HttpNotFound();
            }
            return View(volkswagen);
        }

        // POST: Volkswagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tellija,auto,viga,parandatud,tasutud")] Volkswagen volkswagen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volkswagen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volkswagen);
        }

        // GET: Volkswagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volkswagen volkswagen = db.Volkswagens.Find(id);
            if (volkswagen == null)
            {
                return HttpNotFound();
            }
            return View(volkswagen);
        }

        // POST: Volkswagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volkswagen volkswagen = db.Volkswagens.Find(id);
            db.Volkswagens.Remove(volkswagen);
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
		public ActionResult telli()
		{
			return View();
		}

		// POST: Audis/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult telli([Bind(Include = "id,tellija,auto,viga,parandatud,tasutud")] Volkswagen volkswagen)
		{
			if (ModelState.IsValid)
			{
				db.Volkswagens.Add(volkswagen);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(volkswagen);
		}

		// GET: Audis/Edit/5
		public ActionResult Maksmine(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Volkswagen volkswagen = db.Volkswagens.Find(id);
			if (volkswagen == null)
			{
				return HttpNotFound();
			}
			return View(volkswagen);
		}

		// POST: Audis/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Maksmine([Bind(Include = "id,tellija,auto,viga,parandatud,tasutud")] Volkswagen volkswagen)
		{
			if (ModelState.IsValid)
			{
				db.Entry(volkswagen).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(volkswagen);
		}
		public ActionResult maks()
		{
			var model = db.Volkswagens.
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
			Volkswagen volkswagen = db.Volkswagens.Find(id);
			if (volkswagen == null)
			{
				return HttpNotFound();
			}
			if (ModelState.IsValid)
			{
				switch (part)
				{
					case "maks": { volkswagen.tasutud = result; break; }
					case "parandus": { volkswagen.parandatud = result; break; }


					default:
						{ return HttpNotFound(); }
						break;
				}
				db.Entry(volkswagen).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");


		}

		public ActionResult parandus()
		{
			var volkswagens = db.Volkswagens.
				Where(m => m.parandatud == -1).
				ToList();
			return View(volkswagens);

		}



		// POST: Audis/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Parandamine([Bind(Include = "id,tellija,auto,viga,parandatud,tasutud")] Volkswagen volkswagen)
		{
			if (ModelState.IsValid)
			{
				db.Entry(volkswagen).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(volkswagen);
		}

	}
}
