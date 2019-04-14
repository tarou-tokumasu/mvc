using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class ItemsController : Controller
    {
        private MvCContext db = new MvCContext();

        // GET: Items
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: Items/Details/5
        //いわゆるrequest.getparametarをここでやれる testは結果nullでも大丈夫 型違い（文字とか）だとnull扱いになる
        public ActionResult Details(int? id , int?test)
        {
            if (test == null) {
                test = 1234;
            }
            if (id == null)
            {
                //IDが見つからなかったらエラー400バッドリクエストを返す
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //itemsテーブルからidを元にデータ抽出 select * from items where id=1
            Item item = db.Items.Find(id);
            if (item == null)
            {
                //見つからなかったら404
                return HttpNotFound();
            }
            //抽出したものを返す
            ViewBag.test = test;
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。

        //post定義　必須？
        [HttpPost]
        [ValidateAntiForgeryToken]

        //入力したものをItem型に入れる
        public ActionResult Create([Bind(Include = "Id,name,price,pic,cate")] Item item)
        {
            if (ModelState.IsValid)
            {
                //ここで入力されたものをもう一捻りできる？→出来た
                //item.name += "付け足し";

                //dbへ登録・更新　ワンセット？
                db.Items.Add(item);
                db.SaveChanges();

                //sendredirect
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,price,pic,cate")] Item item)
        {
            if (ModelState.IsValid)
            {
                //updateの役割
                db.Entry(item).State = EntityState.Modified;
                //ステート合わせて自動で命令発行
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        //引数が同じで同名メソッド使えないので別名つける
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //パフォ重視なら
            //var m = new Item(Id=id);
            //db.Entry(m).State=EntryState.Deleted;
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
