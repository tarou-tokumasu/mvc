using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
//Homeのこと
namespace test.Controllers
{
    public class HomeController : Controller

    {
        private MvCContext db = new MvCContext();

        // "Controller"を排除した local/Homeに関するコントローラー
        //ActionResultはjavaのget
        public ActionResult Index()
        {
            //どれ？ Viewsフォルダの対応したcshtml?
            //その様子　同名ファイルでないとエラー
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index (Item item)
        {
            return View();
        }

        // home/About/
        //_Layout.cshtmlで用意したパラメータ受け取るのはここで
        public ActionResult About(int test)
        {
            //cshtmlで使うための変数用意　cshtmlの方でもできる
            ViewBag.age = test;
            ViewBag.name = "田中";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // home/Contact
        public ActionResult Contact()
        {
            //TODO: これでcshtmlの方でカテゴリ一覧が見れるが複数のテーブル送るには？
            //ToListつけるとここの時点でdbに問い合わせる　省くとforeachで呼んだ時に問い合わせる
            return View(db.Cates.ToList());
        }
    }
}