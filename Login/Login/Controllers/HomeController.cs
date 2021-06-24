using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Login.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario user = context.Usuarios
                    .Where(u => u.Nome == usuario
                    .Nome && u.Senha == usuario.Senha).FirstOrDefault();

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.ID.ToString(), false);
                    return RedirectToAction("Index", "Produto");
                }
            }

            ModelState.AddModelError("", "Usuário ou senha inválido!");
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [Authorize]
        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}