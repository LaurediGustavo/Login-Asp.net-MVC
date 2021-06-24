using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class Produto
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [MaxLength(100)]
        public string Nome { get; set; }

        public int UsuarioID { get; set; }

        public Usuario usuario { get; set; }
    }
}