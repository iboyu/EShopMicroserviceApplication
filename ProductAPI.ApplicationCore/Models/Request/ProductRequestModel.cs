using ProductAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.ApplicationCore.Models.Request
{
    public class ProductRequestModel
    {
        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Unit Price is required")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public decimal Quantity { get; set; }
        public int CategoryId { get; set; }
        
    }
}
