using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test.Models
{
    //継承！
    public class Cart : Product
    {
        //個数
        [NotMapped]
        public byte Number { set; get; }
    }
}