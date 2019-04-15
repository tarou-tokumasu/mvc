﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test.Models
{
    //このbuyidで何をいくついくらで買ったか
    public class BuyDetail
    {
        public int Id { set; get; }
        public int BuyID { set; get; }
        public int ProductID { set; get; }
        public decimal Price { set; get; }
        public byte Number { set; get; }
        
    }
}