using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.ApplicationCore.Entities
{
    public class Category
    {
        public int  Id { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Column(TypeName = "varchar(150)")]
        public string CategoryDescription { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
