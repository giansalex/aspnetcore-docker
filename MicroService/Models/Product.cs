using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Range(1, 100, ErrorMessage = "Value should between 1 and 100")]
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
