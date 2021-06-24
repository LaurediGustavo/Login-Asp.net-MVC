using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=BancoLogin") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}