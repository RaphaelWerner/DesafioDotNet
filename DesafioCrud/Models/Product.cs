using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioCrud.Models
{
    public class Product
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Nome é Obrigatório")]
        [StringLength(50, ErrorMessage = "Numero de caracteres do nome não pode ser maior que 50.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preço é Obrigatório")]
        public decimal Price { get; set; }

        [StringLength(50, ErrorMessage = "Numero de caracteres do nome não pode ser maior que 50.")]
        public string Brand { get; set; }

        public DateTime? UpdateAt { get; set; }

        public DateTime? CreatedAt { get; set; }

    }
}