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
    public class PedidosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Pedidos
        public ActionResult Index()
        {
            var pedido = db.pedido.Include(p => p.Cliente).Include(p => p.CupomDesconto).Include(p => p.TipoEntrega);
            return View(pedido.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.cliente, "IdCliente", "CPF");
            ViewBag.IdCupomDesconto = new SelectList(db.cupom_desconto, "IdCupomDesconto", "Descricao");
            ViewBag.IdTipoEntrega = new SelectList(db.tipo_entrega, "IdTipoEntrega", "TipoDeEntrega");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPedido,IdTipoEntrega,IdCupomDesconto,IdCliente,DataCadastro,ValorPedido,PedidoPago,DataPagamento,PedidoEnviado,DataEnvio,EnvioRastreio,PedidoCancelado,DataCancelamento,PedidoEntregue,DataEntrega")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.cliente, "IdCliente", "CPF", pedido.IdCliente);
            ViewBag.IdCupomDesconto = new SelectList(db.cupom_desconto, "IdCupomDesconto", "Descricao", pedido.IdCupomDesconto);
            ViewBag.IdTipoEntrega = new SelectList(db.tipo_entrega, "IdTipoEntrega", "TipoDeEntrega", pedido.IdTipoEntrega);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.cliente, "IdCliente", "CPF", pedido.IdCliente);
            ViewBag.IdCupomDesconto = new SelectList(db.cupom_desconto, "IdCupomDesconto", "Descricao", pedido.IdCupomDesconto);
            ViewBag.IdTipoEntrega = new SelectList(db.tipo_entrega, "IdTipoEntrega", "TipoDeEntrega", pedido.IdTipoEntrega);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPedido,IdTipoEntrega,IdCupomDesconto,IdCliente,DataCadastro,ValorPedido,PedidoPago,DataPagamento,PedidoEnviado,DataEnvio,EnvioRastreio,PedidoCancelado,DataCancelamento,PedidoEntregue,DataEntrega")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.cliente, "IdCliente", "CPF", pedido.IdCliente);
            ViewBag.IdCupomDesconto = new SelectList(db.cupom_desconto, "IdCupomDesconto", "Descricao", pedido.IdCupomDesconto);
            ViewBag.IdTipoEntrega = new SelectList(db.tipo_entrega, "IdTipoEntrega", "TipoDeEntrega", pedido.IdTipoEntrega);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.pedido.Find(id);
            db.pedido.Remove(pedido);
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
