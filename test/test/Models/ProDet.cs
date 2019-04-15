using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class ProDet
    {

        //この辺も短くまとめられそう
        public int Id { set; get; }
        [DisplayName("商品名")]
        public string Name { set; get; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        [DisplayName("単価")]
        public decimal Price { set; get; }
        [DisplayName("個数")]
        public byte Number { set; get; }

        public string GetsubTotal()
        {
            var d = this.Price;
            var n = this.Number;
            return string.Format("{0:c}", d * n);
        }
    }
}