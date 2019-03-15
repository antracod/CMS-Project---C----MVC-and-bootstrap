using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMN.Models;
using System.Web.Script.Serialization;

namespace LMN.Controllers
{
    public class CQController : Controller
    {
        // GET: CQ

        public ActionResult Index(string dbaction,string user)
        {

        
            if (String.IsNullOrWhiteSpace(user))
                user = "Unknown user";
            if (String.IsNullOrWhiteSpace(dbaction)) 
                 dbaction = "Unknown dbaction";

            var viewResult = new ViewResult();

            if(dbaction == "add" && user=="admin")
            {
                dbLmn.AddRandomUsers();
                return Content(String.Format("100 Random Entries Added to the database"));
            }
            else if (dbaction == "add_users" && user == "admin")
            {
                dbLmn.AddRandomUsers();
                return Content(String.Format("100 Random Users Added to the database"));
            }
            else if(dbaction == "delete_all" && user =="admin")
            {
                dbLmn.RemoveAllEntries("quizs");
                return Content(String.Format("All Entries were removed from the database"));
            }
            else
            {
                return Content(String.Format("user={0} and dbaction = {1}", user, dbaction));
            }

           
        }

      //  public JsonResult GetUser2(string user, string dbaction)
    //    {

          //  TestUser myTestUser = new TestUser();
         //   myTestUser.Name = "Teodorelul";
         //   myTestUser.Age = 18;

         //   return Json(myTestUser);

    //    }
    }
}