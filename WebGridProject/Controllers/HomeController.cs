using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebGridProject.Models.DB;
using WebGridProject.Models.EntityManager;

namespace WebGridProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region form get and post for adding new user to db


        //Get method
        public ActionResult MyHomePage()
        {
            return View();
        }
        //Post method
        [HttpPost]
        public ActionResult MyHomePage(tblWebGrid TWG)
        {
            if(ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.addNewUser(TWG);
                ModelState.Clear();
                return View();
            }
            return View();
        }


        /// <summary>
        /// To Do:
        /// 1.) Figure out how to have the object dynamically load into the view --- Check
        /// 2.) Figure out how to truncate the table with a reset button
        /// </summary>
        /// <returns></returns>

        #endregion


        // View of rows in db that will show as a partial view list on page.
        public ActionResult WeBGridView()
        {
            using (WebGridDBEntities db = new WebGridDBEntities())
            {
                return View(db.tblWebGrids.ToList());
            }
        }

        // Reset table by deleting all rows
        public ActionResult Reset()
        {
            using (WebGridDBEntities db = new WebGridDBEntities())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [WebGridTable]");
                return RedirectToAction("MyHomePage", "Home");
            }
        }
    }
}