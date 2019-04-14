using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    //購入情報　誰がいつ買ったか クラス型使わずやってみる
    public class Buy
    {
        public int Id { set; get; }
        public int UserID { set; get; }
        [DisplayName("購入日")]
        [DisplayFormat(DataFormatString ="{0:yyyy 年 MM 月 dd 日 HH 時 mm 分}")]
        public DateTime BuyDate { set; get; }
    }
}