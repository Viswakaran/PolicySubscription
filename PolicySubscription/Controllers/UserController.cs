using WEBREPOSITORY.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PolicySubscription.Controllers
{
    public class UserController : Controller
    {
        public IUser UserInterafce ;

        public UserController(IUser UserInpObj)
        {
            UserInterafce = UserInpObj;
        }
        // GET: User
        public ActionResult GetUser()
        {
            var userVal = UserInterafce.Select();
            return View(userVal);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult InsertUser()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertUser(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    User userObj = new User();
                    userObj.UserID = Convert.ToInt32(collection["UserID"]);
                    userObj.PID = Convert.ToInt32(collection["PID"]);
                    userObj.Name = collection["Name"];
                    userObj.Address = collection["Address"];
                    UserInterafce.Create(userObj);
                }
                return RedirectToAction("GetUser");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult UpdateUser(int id)
        {
           
            User user = UserInterafce.Find(id);
            if(user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    int userid = id;
                    int pid = Convert.ToInt32(collection["PID"]);
                    string name = collection["Name"];
                    string address = collection["Address"];
                    UserInterafce.Update(userid, pid, name, address);
                }
                return RedirectToAction("GetUser");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult DeleteUser(int id)
        {

            User user = UserInterafce.Find(id);
            if(user== null) {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                int userid = id;
                UserInterafce.Delete(userid);
                return RedirectToAction("GetUser");
            }
            catch
            {
                return View();
            }
        }
    }
}
