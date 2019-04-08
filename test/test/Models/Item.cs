using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Item
    {
        public int Id { set; get; }
        public string name { set; get; }
        public decimal price { set; get; }
        public string pic { set; get; }
        public byte cate { set; get; }
    }
}