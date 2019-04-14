using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Categoly
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
    }
}