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
                var insurees = db.Tables.ToList();

                //ViewModel
                var insureeVms = new List<InsureeVM>();
                foreach (var insuree in insurees)
                {
                    var insureeVM = new InsureeVM();
                    insureeVM.Quote = insuree.Quote;
                    insureeVM.FirstName = insuree.FirstName;
                    insureeVM.LastName = insuree.LastName;
                    insureeVM.EmailAddress = insuree.EmailAddress;
                    insureeVms.Add(insureeVM);
                }

                return View(insureeVms);
            }            
        }
    }
}