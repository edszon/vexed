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
    public class ProdutosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Produtos
        public ActionResult Index()
        {
            var produto = db.produto.Include(p => p.Fabricante).Include(p => p.Grupo);
            return View(produto.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.IdFabricante = new SelectList(db.fabricante, "IdFabricante", "NomeFabricante");
            ViewBag.IdGrupo = new SelectList(db.grupo, "IdGrupo", "NomeGrupo");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduto,NomeProduto,DescricaoProduto,PrecoProduto,ProdutoEstoque,ProdutoDisponivel,IdGrupo,GeneroProduto,IdFabricante")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFabricante = new SelectList(db.fabricante, "IdFabricante", "NomeFabricante", produto.IdFabricante);
            ViewBag.IdGrupo = new SelectList(db.grupo, "IdGrupo", "NomeGrupo", produto.IdGrupo);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFabricante = new SelectList(db.fabricante, "IdFabricante", "NomeFabricante", produto.IdFabricante);
            ViewBag.IdGrupo = new SelectList(db.grupo, "IdGrupo", "NomeGrupo", produto.IdGrupo);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduto,NomeProduto,DescricaoProduto,PrecoProduto,ProdutoEstoque,ProdutoDisponivel,IdGrupo,GeneroProduto,IdFabricante")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFabricante = new SelectList(db.fabricante, "IdFabricante", "NomeFabricante", produto.IdFabricante);
            ViewBag.IdGrupo = new SelectList(db.grupo, "IdGrupo", "NomeGrupo", produto.IdGrupo);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.produto.Find(id);
            db.produto.Remove(produto);
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
