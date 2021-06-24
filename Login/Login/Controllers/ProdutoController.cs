using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Login.Models;

namespace Login.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private Context db = new Context();


        public ActionResult Index()
        {
            int id = int.Parse(User.Identity.Name);
            var produtos = db.Produtos.Where(p => p.UsuarioID == id);
            return View(produtos.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int idUsu = int.Parse(User.Identity.Name);
            Produto produto = db.Produtos.Where(p => p.ID == id && p.UsuarioID == idUsu).FirstOrDefault();
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.UsuarioID = int.Parse(User.Identity.Name);
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int idUsu = int.Parse(User.Identity.Name);
            Produto produto = db.Produtos.Where(p => p.ID == id && p.UsuarioID == idUsu).FirstOrDefault();
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "Nome", produto.UsuarioID);
            return View(produto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "Nome", produto.UsuarioID);
            return View(produto);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int idUsu = int.Parse(User.Identity.Name);
            Produto produto = db.Produtos.Where(p => p.ID == id && p.UsuarioID == idUsu).FirstOrDefault();
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
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
