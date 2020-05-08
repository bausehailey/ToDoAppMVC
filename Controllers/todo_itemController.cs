using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using To_Do__MVC;

namespace To_Do__MVC.Controllers
{
    public class todo_itemController : Controller
    {
        //inject repository, add constructor to take in interface so ITodoRepository, create a class called SqlTodoRepository which will implement that interface, in that class have a constructor that takes in the TodoContext
        //add reference to Unity nuget package, make sure its for DI
        private ToDoContext db = new ToDoContext();

        // GET: todo_item
        public ActionResult Index()
        {
            return View(db.todo_item.ToList());
        }

        // GET: todo_item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            todo_item todo_item = db.todo_item.Find(id);
            if (todo_item == null)
            {
                return HttpNotFound();
            }
            return View(todo_item);
        }

        // GET: todo_item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: todo_item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "todo_id,todo_title,todo_description,todo_completed,todo_dateadded")] todo_item todo_item)
        {
            if (ModelState.IsValid)
            {
                db.todo_item.Add(todo_item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todo_item);
        }

        // GET: todo_item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            todo_item todo_item = db.todo_item.Find(id);
            if (todo_item == null)
            {
                return HttpNotFound();
            }
            return View(todo_item);
        }

        // POST: todo_item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "todo_id,todo_title,todo_description,todo_completed,todo_dateadded")] todo_item todo_item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todo_item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo_item);
        }

        // GET: todo_item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            todo_item todo_item = db.todo_item.Find(id);
            if (todo_item == null)
            {
                return HttpNotFound();
            }
            return View(todo_item);
        }

        // POST: todo_item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            todo_item todo_item = db.todo_item.Find(id);
            db.todo_item.Remove(todo_item);
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
