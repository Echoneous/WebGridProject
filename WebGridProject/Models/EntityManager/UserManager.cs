using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGridProject.Models.DB;

namespace WebGridProject.Models.EntityManager
{
    public class UserManager
    {
        public void addNewUser(tblWebGrid AddNew)
        {
            using (WebGridDBEntities db = new WebGridDBEntities())
            {
                tblWebGrid TWG = new tblWebGrid();
                TWG.Name = AddNew.Name;
                TWG.DOB = AddNew.DOB;
                TWG.AddressLine1 = AddNew.AddressLine1;
                TWG.AddressLine2 = AddNew.AddressLine2;
                TWG.City = AddNew.City;
                TWG.State = AddNew.State;
                TWG.Zip = AddNew.Zip;
                TWG.Gender = AddNew.Gender;

                db.tblWebGrids.Add(TWG);
                db.SaveChanges();
            }
        }
    }
}