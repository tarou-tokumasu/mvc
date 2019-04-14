using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Product
    {
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }
        public decimal Price { set; get; }
        public virtual Categoly Categoly { set; get; }
        public string Pic { set; get; }
    }
}