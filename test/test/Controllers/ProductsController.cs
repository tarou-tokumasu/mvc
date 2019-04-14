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
    public class ProductsController : Controller
    {
        private MvCContext db = new MvCContext();

        //検索
        public ActionResult Search(string keyword)
        {
            //まず全部取得、それから絞る
            //join sqlの内部結合と同じだがon～がちょっと違う？
            var sresult = from a in db.Products
                          join c in db.Categories
                          on a.Categoly equals c //productのcategoryはCategory型だからcそのものという事？
                          select new ProCate //ビューで使うための新しい入れ物を作る
                          {
                              Id = a.Id,
                              Name = a.Name,
                              Price = a.Price,
                              Category = c.Name
                          };
                          
                          //そのまま nullか空判定
            if (!string.IsNullOrEmpty(keyword))
            {                                      //部分一致
                sresult = sresult.Where(a => a.Name.Contains(keyword));
            }


            return View(sresult);
        }
        //カート
        public ActionResult Cart()
        {
            //もうちょっとスマートにできそう
            List<Cart> li = (List<Cart>)Session["cart"];

            if (li == null)
            {
                li = new List<Cart>();
                Session["test"] = "カート作成しました";
                Session["cart"] = li;
            }

            
            return View(li);
        }

        public ActionResult Add(int? id)
        {
            //カートの中身はli
            List<Cart> li = (List<Cart>)Session["cart"];
            byte nu = 0;

            //なかったら作る
            if (li == null)
            {
                li = new List<Cart>();
                Session["test"] = "カート作成しました";
                Session["cart"] = li;
            }

            //商品情報取得
            Product product = db.Products.Find(id);
            
            //その商品が既にカートに入ってるか？
            var query =li.Where(x => x.Id == product.Id);
            if (query.Count() == 0)
            {
                //入ってなかったら
                //Cart cartitem = (Cart)product; これはエラー
                //これは手間だと思う
                Cart c = new Cart();
                    c.Id = product.Id;
                    c.Name = product.Name;
                    c.Price = product.Price;
                    c.Number = 1;
                    nu = 1;
                li.Add(c);
            }
            else
            {
                //入ってたら　これも絶対手間
                foreach(var r in li)
                {
                    foreach(var p in query)
                    {
                        if (r.Id == p.Id)
                        {
                            r.Number++;
                            nu = r.Number;
                        }
                    }
                }

            }
            Session["cart"] = li;
            TempData["system"] = $"カートに{product.Name}を追加しました(累計{nu}個)";
            return RedirectToAction("Index");
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Pic")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Pic")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List < Cart > li = (List<Cart>)Session["cart"];

            //同じIDの要素削除　
            /*foreach(var r in li)
            {
                if(r.Id == id)
                {                        エラー foreach中に変更してはいけない
                    li.Remove(r);
                }
            }*/

            //後ろから消すこと　1つずつ消すなら問題ないが
            for (var i = li.Count() -1 ; 0 <= i; i--)
            {
                if (li[i].Id == id)
                {
                    li.Remove(li[i]);
                }
            }

            TempData["system"] = "カートから商品を削除しました";
            return RedirectToAction("Cart");
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
