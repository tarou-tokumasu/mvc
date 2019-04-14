using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    //検索するとカテゴリIDからカテゴリ名呼べない為に作ったモデル
    public class ProCate
    {
        public int Id { set; get; }
        [DisplayName("商品名")]
        public string Name { set; get; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        [DisplayName("単価")]
        public decimal Price { set; get; }
        [DisplayName("カテゴリ")]
        public string Category { set; get; }
    }
}