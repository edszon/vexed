using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vexed.Context;
using vexed.Models;

namespace vexed.Controllers
{
    public class TipoEntregasController : Controller
    {
        private EFContext db = new EFContext();

        // GET: TipoEntregas
        public ActionResult Index()
        {
            return View(db.tipo_entrega.ToList());
        }

        // GET: TipoEntregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntrega tipoEntrega = db.tipo_entrega.Find(id);
            if (tipoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntrega);
        }

        // GET: TipoEntregas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEntregas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoEntrega,TipoDeEntrega")] TipoEntrega tipoEntrega)
        {
            if (ModelState.IsValid)
            {
                db.tipo_entrega.Add(tipoEntrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEntrega);
        }

        // GET: TipoEntregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntrega tipoEntrega = db.tipo_entrega.Find(id);
            if (tipoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntrega);
        }

        // POST: TipoEntregas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoEntrega,TipoDeEntrega")] TipoEntrega tipoEntrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEntrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEntrega);
        }

        // GET: TipoEntregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntrega tipoEntrega = db.tipo_entrega.Find(id);
            if (tipoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntrega);
        }

        // POST: TipoEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEntrega tipoEntrega = db.tipo_entrega.Find(id);
            db.tipo_entrega.Remove(tipoEntrega);
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
