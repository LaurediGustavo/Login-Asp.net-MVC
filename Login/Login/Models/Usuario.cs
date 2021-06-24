using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [MaxLength(12)]
        [MinLength(8, ErrorMessage = "A senha tem que ser maior que 8")]
        public string Senha { get; set; }

        public ICollection<Produto> produtos { get; set; }
    }
}