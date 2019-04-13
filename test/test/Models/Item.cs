using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Item
    {
        public int Id { set; get; }

        [DisplayName("商品名")]
        public string name { set; get; }

        [DisplayName("値段")]
        public decimal price { set; get; }

        [DisplayName("画像")]
        [DataType(DataType.ImageUrl)]
        public string pic { set; get; }

        public byte cate { set; get; }
        public virtual ICollection<Cate>Cates  { set; get; }
    }
}