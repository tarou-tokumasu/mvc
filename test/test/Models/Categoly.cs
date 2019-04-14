using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Categoly
    {
        public int Id { set; get; }
        [Required]
        [DisplayName("カテゴリ")]
        public string Name { set; get; }
    }
}