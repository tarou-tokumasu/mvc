using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test.Models
{
   //何やらこれがないと継承元のクラス使うページでinvalid calumnエラーが出る
    [NotMapped]
    public class Cart : Product //extendsじゃなくて:だけ
    {
        //個数
        [DisplayName("個数")]
        public byte Number{ set; get; }

        public string GetsubTotal()
        {
            var d = this.Price;
            var n = this.Number;
            return string.Format("{0:c}", d * n);
        }
    }
    

}