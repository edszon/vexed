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
    public class CupomDescontoesController : Controller
    {
        private EFContext db = new EFContext();

        // GET: CupomDescontoes
        public ActionResult Index()
        {
            return View(db.cupom_desconto.ToList());
        }

        // GET: CupomDescontoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CupomDesconto cupomDesconto = db.cupom_desconto.Find(id);
            if (cupomDesconto == null)
            {
                return HttpNotFound();
            }
            return View(cupomDesconto);
        }

        // GET: CupomDescontoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CupomDescontoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCupomDesconto,Descricao,PercentualDesconto")] CupomDesconto cupomDesconto)
        {
            if (ModelState.IsValid)
            {
                db.cupom_desconto.Add(cupomDesconto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cupomDesconto);
        }

        // GET: CupomDescontoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CupomDesconto cupomDesconto = db.cupom_desconto.Find(id);
            if (cupomDesconto == null)
            {
                return HttpNotFound();
            }
            return View(cupomDesconto);
        }

        // POST: CupomDescontoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCupomDesconto,Descricao,PercentualDesconto")] CupomDesconto cupomDesconto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cupomDesconto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cupomDesconto);
        }

        // GET: CupomDescontoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CupomDesconto cupomDesconto = db.cupom_desconto.Find(id);
            if (cupomDesconto == null)
            {
                return HttpNotFound();
            }
            return View(cupomDesconto);
        }

        // POST: CupomDescontoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CupomDesconto cupomDesconto = db.cupom_desconto.Find(id);
            db.cupom_desconto.Remove(cupomDesconto);
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
