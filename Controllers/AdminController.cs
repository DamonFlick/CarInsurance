using CarInsurance.Models;
using CarInsurance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (InsuranceEntities db = new InsuranceEntities())
            {
                var insurees = db.Tables.Where(x => x.Removed == null).ToList();

                //ViewModel
                var insureeVms = new List<InsureeVm>();
                foreach (var insuree in insurees)
                {
                    var insureeVm = new InsureeVm();
                    insureeVm.Id = insuree.Id;
                    insureeVm.Quote = insuree.Quote;
                    insureeVm.FirstName = insuree.FirstName;
                    insureeVm.LastName = insuree.LastName;
                    insureeVm.EmailAddress = insuree.EmailAddress;
                    insureeVms.Add(insureeVm);
                }

                return View(insureeVms);
            }            
        }
        public ActionResult Cancel(int Id)
        {
            using (InsuranceEntities db = new InsuranceEntities())
            {
                var signup = db.Tables.Find(Id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}