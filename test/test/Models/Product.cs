﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Product
    {
        public int Id { set; get; }

        [Required]
        [DisplayName("商品名")]
        public string Name { set; get; }

        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        [DisplayName("単価")]
        public decimal Price { set; get; }

        public virtual Category Categoly { set; get; }
        public string Pic { set; get; }
    }
}