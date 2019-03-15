using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LMN.Models;
using System.Data;

namespace LMN.Controllers
{

    public class UserController : Controller
    {
        // GET: User
        private dbLmn.QAdminContext _context= new dbLmn.QAdminContext();

        public ActionResult Index(string sortOrder)
        {
            
            var useList = from s in _context.Users
                      select s;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

           switch (sortOrder)
            {
                case "name_desc":
                    useList = useList.OrderByDescending(s => s.userName);
                    break;
                case "Date":
                    useList = useList.OrderBy(s => s.permissionLevel);
                    break;
                case "date_desc":
                    useList = useList.OrderByDescending(s => s.permissionLevel);
                    break;
                default:
                    useList = useList.OrderBy(s => s.passWord);
                    break;
            }

           
            return View(useList.ToList());
        }

        public ActionResult Details(int iD)
        {
            
            User user = _context.Users.Find(iD);
            return View(user);
        }

        [HttpGet]
        [Route("user/create")]
        public ActionResult GetCreateView()
        {
            return View("create");
        }
        
        [HttpPost]
        [Route("user/create")]
        public ActionResult Create([Bind(Include = "userName, passWord, permissionLevel")]User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return RedirectToAction("user/Index");
        
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            
       
                try
                {
                   
                _context.Users.Add(user);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            
            return View(user);
        }



        public ActionResult Delete(int id)
        {
            try
            {
                User student = _context.Users.Find(id);
                _context.Users.Remove(student);
                _context.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

     
        public ActionResult DeleteAll()
        {
            try
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE USERS");
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddRandom()
        {
            try
            {
                dbLmn.AddRandomUsers();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

    }
}